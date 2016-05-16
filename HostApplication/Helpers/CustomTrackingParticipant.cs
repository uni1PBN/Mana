using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities.Tracking;
using System.IO;
using Data;
using Data.Controllers;

namespace HostApplication.Helper
{
    /// <summary>
    /// Workflow Tracking Participant - Custom Implementation
    /// </summary>
    public class CustomTrackingParticipant : TrackingParticipant
    {
        #region Fields & Properties

        Data.User user;
        Data.WFInstancesLog wfInstanceLog;
        Data.ActivityLog ActivityLog;
        Data.Controllers.WorkflowInstanceLogController wfLogController = new WorkflowInstanceLogController();
        Data.Controllers.ActivityLogController ActivityLogController = new ActivityLogController();
        Data.Controllers.UserController userCtrl = new UserController();

        public Dossier dossier { get; set; }

        public String Console { get; set; }

        #endregion

        #region cTor

        public CustomTrackingParticipant(Data.WorkflowRepository wfRepoItem, Guid wfInstanceID, string wfUserID, Dossier _dossier)
        {
            Console = String.Empty;
            user = userCtrl.GetItem(wfUserID);
            dossier = _dossier;
            if (wfRepoItem != null)
            {
                if (wfInstanceID == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    wfInstanceLog = new WFInstancesLog();
                    wfInstanceLog.Status = "Started";
                    wfInstanceLog.StartTime = DateTime.Now;
                    wfInstanceLog.FK_TaskRepo = wfRepoItem.PK;
                    wfInstanceLog.Dossier.Add(dossier);
                    wfLogController.AddNewItem(wfInstanceLog);
                }
                else
                {
                    wfInstanceLog = wfLogController.GetItemPending(wfInstanceID);
                    if (dossier != null) UpdateDossier();
                    LoadConsole();
                }
            }
        }

        #endregion

        /// <summary>
        /// Appends the current TrackingRecord data to the Workflow Execution Log
        /// </summary>
        /// <param name="trackRecord">Tracking Record Data</param>
        /// <param name="timeStamp">Timestamp</param>
        protected override void Track(TrackingRecord trackRecord, TimeSpan timeStamp)
        {
            ActivityStateRecord recordEntry = trackRecord as ActivityStateRecord;

            if (recordEntry != null)// && recordEntry.Activity.Name != "Persist")
            {
                UpdateConsole(recordEntry);
                if (dossier != null) UpdateDossier();
                UpdateWFData(recordEntry);
            }
        }

        #region Private Methods

        private void UpdateWFData(ActivityStateRecord recordEntry)
        {
            try
            {
                wfInstanceLog.EndTime = DateTime.Now;
                wfInstanceLog.Handler_User = user;
                wfInstanceLog.FK_WFInstanceID = recordEntry.InstanceId;
                //wfLogController.Save();

                if (recordEntry.Activity.Name != "Persist")
                {
                    ActivityLog = new ActivityLog();
                    ActivityLog.ActivityID = recordEntry.Activity.Id;
                    ActivityLog.FK_WFInstanceID = recordEntry.InstanceId;
                    ActivityLog.ActivityName = recordEntry.Activity.Name;
                    ActivityLog.ActivityStatus = recordEntry.State;
                    ActivityLog.StartTime = recordEntry.EventTime;
                    ActivityLog.FK_TaskLog = wfInstanceLog.PK;
                    ActivityLog.FK_ExecutedBy = user.PK;
                    ActivityLogController.AddNewItem(ActivityLog);

                    if (ActivityLog.ActivityName == "DynamicActivity" && ActivityLog.ActivityStatus == "Closed")
                    {
                        wfInstanceLog.Status = "Closed";
                        wfInstanceLog.Dossier.First().CloseDate = DateTime.Now;
                    }
                    else
                        wfInstanceLog.Status = "Running";
                    // wfLogController.Save();
                }
                wfLogController.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR Tracking " + ex.Message, ex);
            }
        }

        private void UpdateDossier()
        {
            //
            //Put your own Application domain Data here 
            //(i.e. for order processing, use the data related to Orders)
            //
            wfInstanceLog.Dossier.First().Name = dossier.Name;
            wfInstanceLog.Dossier.First().Status = dossier.Status;
            wfInstanceLog.Dossier.First().OpenDate = dossier.OpenDate;
            wfInstanceLog.Dossier.First().CloseDate = dossier.CloseDate;
            wfInstanceLog.Dossier.First().FK_WFInstanceLog = dossier.FK_WFInstanceLog;
        }

        private String UpdateConsole(ActivityStateRecord recordEntry)
        {
            String trackLine = String.Format("  [{0}] -- {1} -- [{2}]" +
                    Environment.NewLine, recordEntry.EventTime.ToLocalTime().ToString(),
                //recordEntry.RecordNumber.ToString(),
                    recordEntry.Activity.Name,
                    recordEntry.State
                //recordEntry.InstanceId.ToString(),
                //recordEntry.Activity.Id
                    );
            Console = trackLine + Console;
            return Console;
        }

        private void LoadConsole()
        {
            foreach (Data.ActivityLog actItem in wfInstanceLog.ActivityLogItems.ToList())
            {
                String trackLine = String.Format("  [{0}] -- {1} -- [{2}]" +
                    Environment.NewLine, actItem.StartTime.ToString(),
                    actItem.ActivityName,
                    actItem.ActivityStatus
                    );
                Console = trackLine + Console;
            }
        }

        #endregion

    }
}
