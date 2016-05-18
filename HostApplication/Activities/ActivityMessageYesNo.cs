using HostApplication.Helpers;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication.Activities
{
    public class ActivityMessageYesNo : NativeActivity<String>
    {
        #region Fields & Properties

        //private HostApplication.MainForm _form;

        [Category("Arguments")]
        public InArgument<String> message { get; set; }
        [Category("Arguments")]
        public InArgument<String> status { get; set; }

        #endregion
        

        #region cTor

        public ActivityMessageYesNo()
        {
            this.Result = new Microsoft.VisualBasic.Activities.VisualBasicReference<String>("temp");
        }

        #endregion


        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine("Activity MessageYesNo  (Execute " + context.GetValue(message) + ")  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

            UCInjector(context);

            //Bookmark
            context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));
            Console.WriteLine("Activity MessageYesNo  (Execute " + context.GetValue(message) + ")  thread (after create bookmark): " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }
        //{
        //    HostApplication.Helpers.IReferenceService myservice = context.GetExtension<HostApplication.Helpers.IReferenceService>();
        //    _form = myservice.GetInjectableFormReference() as HostApplication.MainForm;

        //    if (_form.InvokeRequired)
        //    {
        //        _form.Invoke(new Action(() => _form.InjectUC_MessageYesNoButton(context.GetValue(message), context.GetValue(status))));
        //    }
        //    else
        //    {
        //        _form.InjectUC_MessageYesNoButton(context.GetValue(message), context.GetValue(status));
        //    }
        //    context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));

        //}

        private void UCInjector(NativeActivityContext context)
        {
            IReferenceService myservice = context.GetExtension<IReferenceService>();
            IInjectedForm mainForm = myservice.GetInjectableFormReference();
            Console.WriteLine("Activity Msg_3_Buttons (UCInjector " + context.GetValue(message) + ")  thread : " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action(() => mainForm.Inject(typeof(UserControls.UC_MessageYesNoButton), new object[] 
                { 
                    mainForm, 
                    context.GetValue(status), 
                    context.GetValue(message) 
                })), null);
            }
            else
            {
                mainForm.Inject(typeof(UserControls.UC_MessageYesNoButton), new object[] 
                { 
                    mainForm, 
                    context.GetValue(status), 
                    context.GetValue(message) 
                });
            }
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
            Console.WriteLine("Activity  (OnBookmarkCallback)  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString() + " Bookmark Callback - val=" + (string)val);
            if ((String)val == "RESUMED")
            {
                UCInjector(context);
                context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));
                Console.WriteLine("Activity  (OnBookmarkCallback " + context.GetValue(message) + ")  thread (after create bookmark): " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            }
            this.Result.Set(context, (String)val);
        }

        #endregion
    }
}
