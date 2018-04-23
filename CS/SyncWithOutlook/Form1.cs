using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Exchange;
using DevExpress.XtraScheduler.Outlook;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SyncWithOutlook {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private const string OutlookEntryIDFieldName = "OutlookID";

        public static Random RandomInstance = new Random();
        private BindingList<CustomAppointment> CustomEventList = new BindingList<CustomAppointment>();


        OutlookSynchronizerHelper synchronizerHelper;
        private void Form1_Load(object sender, EventArgs e) {
            InitAppointments();
            schedulerControl1.Start = DateTime.Now;
            schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.None;
            schedulerControl1.ActiveViewType = SchedulerViewType.Month;

            // Obtain the names of MS Outlook calendars. 
            comboBoxEdit1.Properties.Items.AddRange(OutlookExchangeHelper.GetOutlookCalendarPaths());
            synchronizerHelper = new OutlookSynchronizerHelper(schedulerControl1.Storage, "", OutlookEntryIDFieldName);
            checkEdit1.Checked = true;
        }

        // Scheduler --> Outlook
        private void btnSchedulerOutlook_Click(object sender, EventArgs e) {
            if(comboBoxEdit1.EditValue != null) {
                synchronizerHelper.CalendarFolder = comboBoxEdit1.EditValue.ToString();
                synchronizerHelper.PerformCalendarsSynchronization(checkEdit1.Checked);
                checkEdit1.Checked = false;
            }
            else {
                MessageBox.Show("Please select Outlook Calendar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Initialization
        private void InitAppointments() {
            AppointmentMappingInfo aptmappings = this.schedulerStorage1.Appointments.Mappings;
            aptmappings.Start = "StartTime";
            aptmappings.End = "EndTime";
            aptmappings.Subject = "Subject";
            aptmappings.AllDay = "AllDay";
            aptmappings.Description = "Description";
            aptmappings.Label = "Label";
            aptmappings.Location = "Location";
            aptmappings.RecurrenceInfo = "RecurrenceInfo";
            aptmappings.ReminderInfo = "ReminderInfo";
            aptmappings.Status = "Status";
            aptmappings.Type = "EventType";
            aptmappings.ResourceId = "OwnerId";

            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping(OutlookEntryIDFieldName, OutlookEntryIDFieldName, FieldValueType.String));
            this.schedulerStorage1.Appointments.DataSource = CustomEventList;
        }
        #endregion Initialization
    }
}
