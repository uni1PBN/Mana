using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HostApplication.Activities
{
    public class ActivityShow_UC_MessageWithDelays : NativeActivity<String>
    {

        #region Fields & Properties

        private HostApplication.MainForm _form;

        [Category("Arguments")]
        public InArgument<String> message { get; set; }
        [Category("Arguments")]
        public InArgument<String> status { get; set; }
        [Category("Arguments")]
        public InArgument<Int32> delay { get; set; }

        #endregion


        #region cTor

        public ActivityShow_UC_MessageWithDelays()
        {
            this.Result = new Microsoft.VisualBasic.Activities.VisualBasicReference<String>("temp");
        }

        #endregion


        protected override void Execute(NativeActivityContext context)
        {
            HostApplication.Helpers.IReferenceService myservice = context.GetExtension<HostApplication.Helpers.IReferenceService>();
            _form = myservice.GetInjectableFormReference() as HostApplication.MainForm;
            if (_form.InvokeRequired)
            {
                _form.Invoke(new Action(() => _form.InjectUC_MessageWithDelays(context.GetValue(message), context.GetValue(delay), context.GetValue(status))));
            }
            else
            {
                _form.InjectUC_MessageWithDelays(context.GetValue(message), context.GetValue(delay), context.GetValue(status));
            }
            context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));
        }


        #region Bookmarks

        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }

        private void OnBookmarkCallback(NativeActivityContext context, Bookmark bookmark, object val)
        {
            this.Result.Set(context, (string)val);
        }

        #endregion
    }
}
