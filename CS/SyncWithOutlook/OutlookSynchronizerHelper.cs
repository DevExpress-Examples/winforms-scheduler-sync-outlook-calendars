using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Exchange;
using DevExpress.XtraScheduler.Outlook;

namespace SyncWithOutlook {
    public class OutlookSynchronizerHelper {
        private SchedulerStorage _storage;
        private string _calendarFolder;
        private string _outlookEntryIDFieldName;

        private AppointmentExportSynchronizer exportSynchronizer = null;
        private AppointmentImportSynchronizer importSynchronizer = null;

        public OutlookSynchronizerHelper() : this(null, "", "") { }

        private bool isInitialSynchronization = false;
        private bool isSynchronization = false;

        public OutlookSynchronizerHelper(SchedulerStorage storage, string calendarFolder = "", string outlookEntryIDFieldName = "") {
            if(storage != null) Storage = storage;
            if(calendarFolder != null) CalendarFolder = calendarFolder;
            if(outlookEntryIDFieldName != null) OutlookEntryIDFieldName = outlookEntryIDFieldName;
        }

        public string CalendarFolder {
            get { return _calendarFolder; }
            set {
                _calendarFolder = value;
                if(importSynchronizer != null) (importSynchronizer as ISupportCalendarFolders).CalendarFolderName = _calendarFolder;
                if(exportSynchronizer != null) (exportSynchronizer as ISupportCalendarFolders).CalendarFolderName = _calendarFolder;
            }
        }

        public string OutlookEntryIDFieldName {
            get { return _outlookEntryIDFieldName; }
            set {
                _outlookEntryIDFieldName = value;
                if(importSynchronizer != null) importSynchronizer.ForeignIdFieldName = _outlookEntryIDFieldName;
                if(exportSynchronizer != null) exportSynchronizer.ForeignIdFieldName = _outlookEntryIDFieldName;
            }
        }

        public SchedulerStorage Storage {
            get { return _storage; }
            set {
                if(_storage != null) UnsubscribeFromStorageEvents();
                _storage = value;
                exportSynchronizer = _storage.CreateOutlookExportSynchronizer();
                importSynchronizer = _storage.CreateOutlookImportSynchronizer();
                (importSynchronizer as ISupportCalendarFolders).CalendarFolderName = _calendarFolder;
                (exportSynchronizer as ISupportCalendarFolders).CalendarFolderName = _calendarFolder;
                importSynchronizer.ForeignIdFieldName = _outlookEntryIDFieldName;
                importSynchronizer.ForeignIdFieldName = _outlookEntryIDFieldName;

                SubscribeToStorageEvents();
            }
        }

        // an internal cache to store inserted appointments references
        List<Appointment> insertedAppointments = new List<Appointment>();

        // an internal cache to store deleted appointments IDs
        List<string> deletedAppointments = new List<string>();

        // an internal cache to store changed appointments references
        List<Appointment> changedAppointments = new List<Appointment>();

        private void SubscribeToStorageEvents() {
            if(importSynchronizer != null) importSynchronizer.AppointmentSynchronizing += Synchronizer_AppointmentSynchronizing;
            if(exportSynchronizer != null) exportSynchronizer.AppointmentSynchronizing += Synchronizer_AppointmentSynchronizing;

            _storage.AppointmentsInserted += Storage_AppointmentsInserted;
            _storage.AppointmentsChanged += Storage_AppointmentsChanged;
            _storage.AppointmentDeleting += Storage_AppointmentDeleting;
        }

        private void UnsubscribeFromStorageEvents() {
            insertedAppointments.Clear();
            deletedAppointments.Clear();
            changedAppointments.Clear();

            if(importSynchronizer != null) importSynchronizer.AppointmentSynchronizing -= Synchronizer_AppointmentSynchronizing;
            if(exportSynchronizer != null) exportSynchronizer.AppointmentSynchronizing -= Synchronizer_AppointmentSynchronizing;

            _storage.AppointmentsInserted -= Storage_AppointmentsInserted;
            _storage.AppointmentsChanged -= Storage_AppointmentsChanged;
            _storage.AppointmentDeleting -= Storage_AppointmentDeleting;
        }

        void Storage_AppointmentsInserted(object sender, PersistentObjectsEventArgs e) {
            if(isSynchronization) return;

            for(int i = 0; i < e.Objects.Count; i++) {
                Appointment newAppointment = e.Objects[i] as Appointment;
                newAppointment.CustomFields[OutlookEntryIDFieldName] = null;
                insertedAppointments.Add(e.Objects[i] as Appointment);
            }
        }

        void Storage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            if(isSynchronization) return;

            for(int i = 0; i < e.Objects.Count; i++) {
                changedAppointments.Add(e.Objects[i] as Appointment);
            }
        }

        void Storage_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e) {
            if(isSynchronization) return;

            Appointment currentAppointment = e.Object as Appointment;
            if(currentAppointment.CustomFields[OutlookEntryIDFieldName] != null && (currentAppointment.Type == AppointmentType.Normal || currentAppointment.Type == AppointmentType.Pattern)) {
                deletedAppointments.Add(currentAppointment.CustomFields[OutlookEntryIDFieldName].ToString());
            }
        }

        void Synchronizer_AppointmentSynchronizing(object sender, AppointmentSynchronizingEventArgs e) {
            AnalyzeAndHandleCurrentOperation(e as DevExpress.XtraScheduler.Outlook.OutlookAppointmentSynchronizingEventArgs);
        }

        void AnalyzeAndHandleCurrentOperation(DevExpress.XtraScheduler.Outlook.OutlookAppointmentSynchronizingEventArgs eventArgs) {
            switch(eventArgs.Operation) {
                case SynchronizeOperation.Create:
                    eventArgs.Cancel = eventArgs.OutlookAppointment != null && deletedAppointments.Contains(eventArgs.OutlookAppointment.EntryID);
                    break;
                case SynchronizeOperation.Delete:
                    if(isInitialSynchronization)
                        eventArgs.Cancel = true;
                    else
                        eventArgs.Cancel = eventArgs.Appointment != null && insertedAppointments.Contains(eventArgs.Appointment);
                    break;
                case SynchronizeOperation.Replace:
                    eventArgs.Cancel = eventArgs.Appointment != null && changedAppointments.Contains(eventArgs.Appointment);
                    break;
                default:
                    break;
            }
        }

        // synchronization methods
        public void PerformCalendarsSynchronization(bool isInitial) {
            isInitialSynchronization = isInitial;

            isSynchronization = true;

            importSynchronizer.Synchronize();
            changedAppointments.Clear();
            exportSynchronizer.Synchronize();

            insertedAppointments.Clear();
            deletedAppointments.Clear();

            isSynchronization = false;
        }
    }
}
