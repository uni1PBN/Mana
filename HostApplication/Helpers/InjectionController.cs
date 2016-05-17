using System;
using System.Activities;
using System.Activities.Hosting;
using System.Windows.Forms;

namespace HostApplication.Helpers
{
    public class InjectionController
    {
        public Control control { get; set; }

        private Panel container; 
        private WorkflowApplication wfAppli; 

        public InjectionController(Panel container, WorkflowApplication wfapp)
        {
            this.container = container;
            this.wfAppli = wfapp;
        }

        public void InjectControl(Type controlType, object[] activityParams)
        {
            if (container != null && controlType != null)
            {
                this.control = (Control)Activator.CreateInstance(controlType, new object[] { activityParams });
                container.Controls.Add(control);
            }
        }

        public void RemoveControl(BookmarkInfo bookmarkinfo, object conrolReturnedValue)
        {
            if (wfAppli != null && bookmarkinfo != null) wfAppli.ResumeBookmark(bookmarkinfo.BookmarkName, conrolReturnedValue);
            container.Controls.Remove(control);
        }
    }
}
