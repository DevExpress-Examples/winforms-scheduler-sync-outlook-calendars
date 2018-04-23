Imports Microsoft.VisualBasic
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Exchange
Imports DevExpress.XtraScheduler.Outlook
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections.Generic

Namespace SyncWithOutlook
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Const OutlookEntryIDFieldName As String = "OutlookID"

		Public Shared RandomInstance As New Random()
		Private CustomEventList As New BindingList(Of CustomAppointment)()


		Private synchronizerHelper As OutlookSynchronizerHelper
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			InitAppointments()
			schedulerControl1.Start = DateTime.Now
			schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.None
			schedulerControl1.ActiveViewType = SchedulerViewType.Month

			' Obtain the names of MS Outlook calendars. 
			comboBoxEdit1.Properties.Items.AddRange(OutlookExchangeHelper.GetOutlookCalendarPaths())
            synchronizerHelper = New OutlookSynchronizerHelper(schedulerControl1.Storage, "", OutlookEntryIDFieldName)
            checkEdit1.Checked = True
		End Sub

		' Scheduler --> Outlook
		Private Sub btnSchedulerOutlook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSynchronization.Click
			If comboBoxEdit1.EditValue IsNot Nothing Then
				synchronizerHelper.CalendarFolder = comboBoxEdit1.EditValue.ToString()
				synchronizerHelper.PerformCalendarsSynchronization(checkEdit1.Checked)
				checkEdit1.Checked = False
			Else
				MessageBox.Show("Please select Outlook Calendar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End If
		End Sub

		#Region "Initialization"
		Private Sub InitAppointments()
			Dim aptmappings As AppointmentMappingInfo = Me.schedulerStorage1.Appointments.Mappings
			aptmappings.Start = "StartTime"
			aptmappings.End = "EndTime"
			aptmappings.Subject = "Subject"
			aptmappings.AllDay = "AllDay"
			aptmappings.Description = "Description"
			aptmappings.Label = "Label"
			aptmappings.Location = "Location"
			aptmappings.RecurrenceInfo = "RecurrenceInfo"
			aptmappings.ReminderInfo = "ReminderInfo"
			aptmappings.Status = "Status"
			aptmappings.Type = "EventType"
			aptmappings.ResourceId = "OwnerId"

			Me.schedulerStorage1.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping(OutlookEntryIDFieldName, OutlookEntryIDFieldName, FieldValueType.String))
			Me.schedulerStorage1.Appointments.DataSource = CustomEventList
		End Sub
		#End Region ' Initialization
	End Class
End Namespace
