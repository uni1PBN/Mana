using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Controllers
{
    public class AgendaController
    {
        private DBManaEntities _dbcontext = DBManaEntitiesSingleton.Instance;
       private WorkflowInstanceLogController wfLogController = new WorkflowInstanceLogController();
        private InstancesTableController instanceTableCtrl = new InstancesTableController();

        public DA_Agenda AgendaCurrent { get; set; }
        public List<DA_Agenda> AgendaCollection { get; set; }

        public AgendaController() {AgendaCollection = new List<DA_Agenda>(); }

        public List<DA_Agenda> GetAllPending()
        {
            foreach (InstancesTable item in instanceTableCtrl.GetAll())
            {
                WFInstancesLog wflog = wfLogController.GetItemPending(item.Id);
                AgendaCurrent = new DA_Agenda();
                AgendaCurrent.Dossier = wflog.Dossier.FirstOrDefault();
                AgendaCurrent.DossierName = wflog.Dossier.FirstOrDefault() != null ? wflog.Dossier.FirstOrDefault().Name : "";
                AgendaCurrent.DossierStatus = wflog.Dossier.FirstOrDefault() != null ? wflog.Dossier.FirstOrDefault().Status : "";
                AgendaCurrent.ControlUser = wflog.Controler_User;
                AgendaCurrent.ControlUserName = wflog.Controler_User != null ? wflog.Controler_User.Name : "";
                AgendaCurrent.DatePause = wflog.EndTime;
                AgendaCurrent.DateStart = wflog.StartTime;
                AgendaCurrent.HandlingUser = wflog.Handler_User;
                AgendaCurrent.HandlingUserName = wflog.Handler_User != null ? wflog.Handler_User.Name : ""; 
                AgendaCurrent.PendingActivityName = wflog.ActivityLogItems.OrderBy(x => x.StartTime).LastOrDefault(x => x.ActivityStatus == "Executing").ActivityName;
                AgendaCurrent.Name = wflog.WorkflowRepository.Name;
                AgendaCurrent.WFInstanceId = (Guid)wflog.FK_WFInstanceID;
                AgendaCurrent.Workflow = wflog.WorkflowRepository;
                AgendaCurrent.WorkflowXaml = wflog.WorkflowRepository.WorkFlow;
                AgendaCollection.Add(AgendaCurrent);
            } 
            return AgendaCollection;
        }
    }
}
