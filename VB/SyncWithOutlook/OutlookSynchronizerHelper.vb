Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Exchange
Imports DevExpress.XtraScheduler.Outlook

Namespace SyncWithOutlook
	Public Class OutlookSynchronizerHelper
		Private _storage As SchedulerStorage
		Private _calendarFolder As String
		Private _outlookEntryIDFieldName As String

		Private exportSynchronizer As AppointmentExportSynchronizer = Nothing
		Private importSynchronizer As AppointmentImportSynchronizer = Nothing

		Public Sub New()
			Me.New(Nothing, "", "")
		End Sub

		Private isInitialSynchronization As Boolean = False
		Private isSynchronization As Boolean = False

		Public Sub New(ByVal storage As SchedulerStorage, Optional ByVal calendarFolder As String = "", Optional ByVal outlookEntryIDFieldName As String = "")
			If storage IsNot Nothing Then
				Me.Storage = storage
			End If
			If calendarFolder IsNot Nothing Then
				Me.CalendarFolder = calendarFolder
			End If
			If outlookEntryIDFieldName IsNot Nothing Then
				Me.OutlookEntryIDFieldName = outlookEntryIDFieldName
			End If
		End Sub

		Public Property CalendarFolder() As String
			Get
				Return _calendarFolder
			End Get
			Set(ByVal value As String)
				_calendarFolder = value
				If importSynchronizer IsNot Nothing Then
					TryCast(importSynchronizer, ISupportCalendarFolders).CalendarFolderName = _calendarFolder
				End If
				If exportSynchronizer IsNot Nothing Then
					TryCast(exportSynchronizer, ISupportCalendarFolders).CalendarFolderName = _calendarFolder
				End If
			End Set
		End Property

		Public Property OutlookEntryIDFieldName() As String
			Get
				Return _outlookEntryIDFieldName
			End Get
			Set(ByVal value As String)
				_outlookEntryIDFieldName = value
				If importSynchronizer IsNot Nothing Then
					importSynchronizer.ForeignIdFieldName = _outlookEntryIDFieldName
				End If
				If exportSynchronizer IsNot Nothing Then
					exportSynchronizer.ForeignIdFieldName = _outlookEntryIDFieldName
				End If
			End Set
		End Property

		Public Property Storage() As SchedulerStorage
			Get
				Return _storage
			End Get
			Set(ByVal value As SchedulerStorage)
				If _storage IsNot Nothing Then
					UnsubscribeFromStorageEvents()
				End If
				_storage = value
				exportSynchronizer = _storage.CreateOutlookExportSynchronizer()
				importSynchronizer = _storage.CreateOutlookImportSynchronizer()
				TryCast(importSynchronizer, ISupportCalendarFolders).CalendarFolderName = _calendarFolder
				TryCast(exportSynchronizer, ISupportCalendarFolders).CalendarFolderName = _calendarFolder
				importSynchronizer.ForeignIdFieldName = _outlookEntryIDFieldName
				importSynchronizer.ForeignIdFieldName = _outlookEntryIDFieldName

				SubscribeToStorageEvents()
			End Set
		End Property

		' an internal cache to store inserted appointments references
		Private insertedAppointments As New List(Of Appointment)()

		' an internal cache to store deleted appointments IDs
		Private deletedAppointments As New List(Of String)()

		' an internal cache to store changed appointments references
		Private changedAppointments As New List(Of Appointment)()

		Private Sub SubscribeToStorageEvents()
			If importSynchronizer IsNot Nothing Then
				AddHandler importSynchronizer.AppointmentSynchronizing, AddressOf Synchronizer_AppointmentSynchronizing
			End If
			If exportSynchronizer IsNot Nothing Then
				AddHandler exportSynchronizer.AppointmentSynchronizing, AddressOf Synchronizer_AppointmentSynchronizing
			End If

			AddHandler _storage.AppointmentsInserted, AddressOf Storage_AppointmentsInserted
			AddHandler _storage.AppointmentsChanged, AddressOf Storage_AppointmentsChanged
			AddHandler _storage.AppointmentDeleting, AddressOf Storage_AppointmentDeleting
		End Sub

		Private Sub UnsubscribeFromStorageEvents()
			insertedAppointments.Clear()
			deletedAppointments.Clear()
			changedAppointments.Clear()

			If importSynchronizer IsNot Nothing Then
				RemoveHandler importSynchronizer.AppointmentSynchronizing, AddressOf Synchronizer_AppointmentSynchronizing
			End If
			If exportSynchronizer IsNot Nothing Then
				RemoveHandler exportSynchronizer.AppointmentSynchronizing, AddressOf Synchronizer_AppointmentSynchronizing
			End If

			RemoveHandler _storage.AppointmentsInserted, AddressOf Storage_AppointmentsInserted
			RemoveHandler _storage.AppointmentsChanged, AddressOf Storage_AppointmentsChanged
			RemoveHandler _storage.AppointmentDeleting, AddressOf Storage_AppointmentDeleting
		End Sub

		Private Sub Storage_AppointmentsInserted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
			If isSynchronization Then
				Return
			End If

			For i As Integer = 0 To e.Objects.Count - 1
				Dim newAppointment As Appointment = TryCast(e.Objects(i), Appointment)
				newAppointment.CustomFields(OutlookEntryIDFieldName) = Nothing
				insertedAppointments.Add(TryCast(e.Objects(i), Appointment))
			Next i
		End Sub

		Private Sub Storage_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
			If isSynchronization Then
				Return
			End If

			For i As Integer = 0 To e.Objects.Count - 1
				changedAppointments.Add(TryCast(e.Objects(i), Appointment))
			Next i
		End Sub

		Private Sub Storage_AppointmentDeleting(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)
			If isSynchronization Then
				Return
			End If

			Dim currentAppointment As Appointment = TryCast(e.Object, Appointment)
			If currentAppointment.CustomFields(OutlookEntryIDFieldName) IsNot Nothing AndAlso (currentAppointment.Type = AppointmentType.Normal OrElse currentAppointment.Type = AppointmentType.Pattern) Then
				deletedAppointments.Add(currentAppointment.CustomFields(OutlookEntryIDFieldName).ToString())
			End If
		End Sub

		Private Sub Synchronizer_AppointmentSynchronizing(ByVal sender As Object, ByVal e As AppointmentSynchronizingEventArgs)
			AnalyzeAndHandleCurrentOperation(TryCast(e, DevExpress.XtraScheduler.Outlook.OutlookAppointmentSynchronizingEventArgs))
		End Sub

		Private Sub AnalyzeAndHandleCurrentOperation(ByVal eventArgs As DevExpress.XtraScheduler.Outlook.OutlookAppointmentSynchronizingEventArgs)
			Select Case eventArgs.Operation
				Case SynchronizeOperation.Create
					eventArgs.Cancel = eventArgs.OutlookAppointment IsNot Nothing AndAlso deletedAppointments.Contains(eventArgs.OutlookAppointment.EntryID)
				Case SynchronizeOperation.Delete
					If isInitialSynchronization Then
						eventArgs.Cancel = True
					Else
						eventArgs.Cancel = eventArgs.Appointment IsNot Nothing AndAlso insertedAppointments.Contains(eventArgs.Appointment)
					End If
				Case SynchronizeOperation.Replace
					eventArgs.Cancel = eventArgs.Appointment IsNot Nothing AndAlso changedAppointments.Contains(eventArgs.Appointment)
				Case Else
			End Select
		End Sub

		' synchronization methods
		Public Sub PerformCalendarsSynchronization(ByVal isInitial As Boolean)
			isInitialSynchronization = isInitial

			isSynchronization = True

			importSynchronizer.Synchronize()
			changedAppointments.Clear()
			exportSynchronizer.Synchronize()

			insertedAppointments.Clear()
			deletedAppointments.Clear()

			isSynchronization = False
		End Sub
	End Class
End Namespace
