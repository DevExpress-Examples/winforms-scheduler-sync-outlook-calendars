Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace SyncWithOutlook
	#Region "#customappointment"
	Public Class CustomAppointment
		Private privateStartTime As DateTime
		Public Property StartTime() As DateTime
			Get
				Return privateStartTime
			End Get
			Set(ByVal value As DateTime)
				privateStartTime = value
			End Set
		End Property
		Private privateEndTime As DateTime
		Public Property EndTime() As DateTime
			Get
				Return privateEndTime
			End Get
			Set(ByVal value As DateTime)
				privateEndTime = value
			End Set
		End Property
		Private privateSubject As String
		Public Property Subject() As String
			Get
				Return privateSubject
			End Get
			Set(ByVal value As String)
				privateSubject = value
			End Set
		End Property
		Private privateStatus As Integer
		Public Property Status() As Integer
			Get
				Return privateStatus
			End Get
			Set(ByVal value As Integer)
				privateStatus = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
		Private privateLabel As Integer
		Public Property Label() As Integer
			Get
				Return privateLabel
			End Get
			Set(ByVal value As Integer)
				privateLabel = value
			End Set
		End Property
		Private privateLocation As String
		Public Property Location() As String
			Get
				Return privateLocation
			End Get
			Set(ByVal value As String)
				privateLocation = value
			End Set
		End Property
		Private privateAllDay As Boolean
		Public Property AllDay() As Boolean
			Get
				Return privateAllDay
			End Get
			Set(ByVal value As Boolean)
				privateAllDay = value
			End Set
		End Property
		Private privateEventType As Integer
		Public Property EventType() As Integer
			Get
				Return privateEventType
			End Get
			Set(ByVal value As Integer)
				privateEventType = value
			End Set
		End Property
		Private privateRecurrenceInfo As String
		Public Property RecurrenceInfo() As String
			Get
				Return privateRecurrenceInfo
			End Get
			Set(ByVal value As String)
				privateRecurrenceInfo = value
			End Set
		End Property
		Private privateReminderInfo As String
		Public Property ReminderInfo() As String
			Get
				Return privateReminderInfo
			End Get
			Set(ByVal value As String)
				privateReminderInfo = value
			End Set
		End Property
		Private privateOwnerId As Object
		Public Property OwnerId() As Object
			Get
				Return privateOwnerId
			End Get
			Set(ByVal value As Object)
				privateOwnerId = value
			End Set
		End Property
		Private privateOutlookID As Object
		Public Property OutlookID() As Object
			Get
				Return privateOutlookID
			End Get
			Set(ByVal value As Object)
				privateOutlookID = value
			End Set
		End Property

		Public Sub New()
		End Sub
	End Class
	#End Region '  #customappointment

	#Region "#customresource"
	Public Class CustomResource
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateResID As Integer
		Public Property ResID() As Integer
			Get
				Return privateResID
			End Get
			Set(ByVal value As Integer)
				privateResID = value
			End Set
		End Property
		Private privateResColor As System.Drawing.Color
		Public Property ResColor() As System.Drawing.Color
			Get
				Return privateResColor
			End Get
			Set(ByVal value As System.Drawing.Color)
				privateResColor = value
			End Set
		End Property

		Public Sub New()
		End Sub
	End Class
	#End Region ' #customresource
End Namespace
