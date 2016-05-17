using HostApplication.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication.Helpers
{
    public class InjectionController
    {
        public InjectableUC control { get; set; }

        private System.Windows.Forms.Panel container; 
        private System.Activities.WorkflowApplication wfAppli; 

        public InjectionController(System.Windows.Forms.Panel container, System.Activities.WorkflowApplication wfapp)
        {
            this.container = container;
            this.wfAppli = wfapp;
        }

        public void InjectControl(Type controlType, object[] activityParams)
        {
            if (container != null && controlType != null)
            {
                this.control = (InjectableUC)Activator.CreateInstance(controlType, new object[] { activityParams });
                container.Controls.Add(control);
            }
        }

        public void RemoveControl(System.Activities.Hosting.BookmarkInfo bookmarkinfo, object conrolReturnedValue)
        {
            if (wfAppli != null && bookmarkinfo != null) wfAppli.ResumeBookmark(bookmarkinfo.BookmarkName, conrolReturnedValue);
            container.Controls.Remove(control);
        }
    }
}
