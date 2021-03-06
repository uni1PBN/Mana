//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class WFInstancesLog
    {
        public WFInstancesLog()
        {
            this.ActivityLogItems = new HashSet<ActivityLog>();
            this.Dossier = new HashSet<Dossier>();
        }
    
        public int PK { get; set; }
        public Nullable<int> FK_TaskRepo { get; set; }
        public Nullable<int> FK_UserExec { get; set; }
        public string Status { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public Nullable<int> FK_UserCtrl { get; set; }
        public Nullable<System.Guid> FK_WFInstanceID { get; set; }
        public string Topic { get; set; }
    
        public virtual ICollection<ActivityLog> ActivityLogItems { get; set; }
        public virtual User Handler_User { get; set; }
        public virtual User Controler_User { get; set; }
        public virtual WorkflowRepository WorkflowRepository { get; set; }
        public virtual ICollection<Dossier> Dossier { get; set; }
    }
}
