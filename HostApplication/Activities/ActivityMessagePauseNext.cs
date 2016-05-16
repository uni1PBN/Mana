using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication.Activities
{
    public class ActivityMessagePauseNext :  NativeActivity<String>
    {
        #region Fields & Properties

        private HostApplication.MainForm _form;

        [Category("Arguments")]
        public InArgument<String> message { get; set; }
        [Category("Arguments")]
        public InArgument<String> status { get; set; }

        #endregion
        

        #region cTor

        public ActivityMessagePauseNext()
        {
            this.Result = new Microsoft.VisualBasic.Activities.VisualBasicReference<String>("temp");
        }

        #endregion


        protected override void Execute(NativeActivityContext context)
        {
            //HostApplication.Helpers.IReferenceService myservice = context.GetExtension<HostApplication.Helpers.IReferenceService>();
            //_form = myservice.GetMainFormReference() as HostApplication.MainForm;

            //if (_form.InvokeRequired)
            //{
            //    _form.Invoke(new Action(() => _form.InjectUC_MessagePauseNext(context.GetValue(message), context.GetValue(status))));
            //}
            //else
            //{
            //    _form.InjectUC_MessagePauseNext(context.GetValue(message), context.GetValue(status));
            //}
            //context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));
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
            this.Result.Set(context, (String)val);
        }

        #endregion
    }
}
