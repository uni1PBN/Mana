using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DA_Agenda
    {
        public Guid WFInstanceId { get; set; }
        public String Name { get; set; }
        public Data.Dossier Dossier { get; set; }
        public String DossierName { get; set; }
        public String DossierStatus { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DatePause { get; set; }
        public String WorkflowXaml { get; set; }
        public String PendingActivityName { get; set; }
        public String NextActivityName { get; set; }
        public String HandlingUserName { get; set; }
        public String ControlUserName { get; set; }
        public Data.WorkflowRepository Workflow { get; set; }
        public Data.User HandlingUser { get; set; }
        public Data.User ControlUser { get; set; }
    }
}

