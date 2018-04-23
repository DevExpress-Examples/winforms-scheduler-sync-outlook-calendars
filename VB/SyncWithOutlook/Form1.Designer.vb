Imports Microsoft.VisualBasic
Imports System
Namespace SyncWithOutlook
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.comboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
			Me.btnSynchronization = New DevExpress.XtraEditors.SimpleButton()
			Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
			Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
			Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.checkEdit1 = New DevExpress.XtraEditors.CheckEdit()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.comboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.checkEdit1)
			Me.layoutControl1.Controls.Add(Me.comboBoxEdit1)
			Me.layoutControl1.Controls.Add(Me.btnSynchronization)
			Me.layoutControl1.Controls.Add(Me.dateNavigator1)
			Me.layoutControl1.Controls.Add(Me.schedulerControl1)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1099, 372, 771, 476)
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(1052, 691)
			Me.layoutControl1.TabIndex = 0
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' comboBoxEdit1
			' 
			Me.comboBoxEdit1.Location = New System.Drawing.Point(785, 239)
			Me.comboBoxEdit1.Name = "comboBoxEdit1"
			Me.comboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.comboBoxEdit1.Size = New System.Drawing.Size(255, 20)
			Me.comboBoxEdit1.StyleController = Me.layoutControl1
			Me.comboBoxEdit1.TabIndex = 9
			' 
			' btnSynchronization
			' 
			Me.btnSynchronization.Appearance.Font = New System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold)
			Me.btnSynchronization.Appearance.Options.UseFont = True
			Me.btnSynchronization.Location = New System.Drawing.Point(785, 263)
			Me.btnSynchronization.Name = "btnSynchronization"
			Me.btnSynchronization.Size = New System.Drawing.Size(255, 26)
			Me.btnSynchronization.StyleController = Me.layoutControl1
			Me.btnSynchronization.TabIndex = 7
			Me.btnSynchronization.Text = "Synchronize appointments"
'			Me.btnSynchronization.Click += New System.EventHandler(Me.btnSchedulerOutlook_Click);
			' 
			' dateNavigator1
			' 
			Me.dateNavigator1.AllowAnimatedContentChange = True
			Me.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.dateNavigator1.CellPadding = New System.Windows.Forms.Padding(2)
			Me.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday
			Me.dateNavigator1.Location = New System.Drawing.Point(785, 12)
			Me.dateNavigator1.Name = "dateNavigator1"
			Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
			Me.dateNavigator1.Size = New System.Drawing.Size(255, 207)
			Me.dateNavigator1.StyleController = Me.layoutControl1
			Me.dateNavigator1.TabIndex = 5
			' 
			' schedulerControl1
			' 
			Me.schedulerControl1.Location = New System.Drawing.Point(12, 12)
			Me.schedulerControl1.Name = "schedulerControl1"
			Me.schedulerControl1.Size = New System.Drawing.Size(769, 667)
			Me.schedulerControl1.Start = New System.DateTime(2013, 9, 2, 0, 0, 0, 0)
			Me.schedulerControl1.Storage = Me.schedulerStorage1
			Me.schedulerControl1.TabIndex = 4
			Me.schedulerControl1.Text = "schedulerControl1"
			Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem6, Me.layoutControlItem4, Me.emptySpaceItem1, Me.layoutControlItem3})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "Root"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(1052, 691)
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.schedulerControl1
			Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(773, 671)
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem1.TextVisible = False
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.dateNavigator1
			Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
			Me.layoutControlItem2.Location = New System.Drawing.Point(773, 0)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(259, 211)
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextVisible = False
			' 
			' layoutControlItem6
			' 
			Me.layoutControlItem6.Control = Me.comboBoxEdit1
			Me.layoutControlItem6.CustomizationFormText = "Outllok folder:"
			Me.layoutControlItem6.Location = New System.Drawing.Point(773, 211)
			Me.layoutControlItem6.Name = "layoutControlItem6"
			Me.layoutControlItem6.Size = New System.Drawing.Size(259, 40)
			Me.layoutControlItem6.Text = "Select Outlook folder:"
			Me.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
			Me.layoutControlItem6.TextSize = New System.Drawing.Size(104, 13)
			' 
			' layoutControlItem4
			' 
			Me.layoutControlItem4.Control = Me.btnSynchronization
			Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
			Me.layoutControlItem4.Location = New System.Drawing.Point(773, 251)
			Me.layoutControlItem4.Name = "layoutControlItem4"
			Me.layoutControlItem4.Size = New System.Drawing.Size(259, 30)
			Me.layoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem4.TextVisible = False
			' 
			' emptySpaceItem1
			' 
			Me.emptySpaceItem1.AllowHotTrack = False
			Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
			Me.emptySpaceItem1.Location = New System.Drawing.Point(773, 304)
			Me.emptySpaceItem1.Name = "emptySpaceItem1"
			Me.emptySpaceItem1.Size = New System.Drawing.Size(259, 367)
			Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
			' 
			' checkEdit1
			' 
			Me.checkEdit1.Location = New System.Drawing.Point(785, 293)
			Me.checkEdit1.Name = "checkEdit1"
			Me.checkEdit1.Properties.Caption = "Initial Synchronization"
			Me.checkEdit1.Size = New System.Drawing.Size(255, 19)
			Me.checkEdit1.StyleController = Me.layoutControl1
			Me.checkEdit1.TabIndex = 10
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.checkEdit1
			Me.layoutControlItem3.Location = New System.Drawing.Point(773, 281)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(259, 23)
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem3.TextVisible = False
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1052, 691)
			Me.Controls.Add(Me.layoutControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.comboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
		Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator
		Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
		Private comboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
		Private WithEvents btnSynchronization As DevExpress.XtraEditors.SimpleButton
		Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
		Private checkEdit1 As DevExpress.XtraEditors.CheckEdit
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
	End Class
End Namespace

