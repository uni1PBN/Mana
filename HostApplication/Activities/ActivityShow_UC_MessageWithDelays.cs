using HostApplication.Helpers;
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

        //private HostApplication.MainForm _form;

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
            Console.WriteLine("Activity Delay  (Constructor)  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        #endregion


        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine("Activity Delay  (Execute " + context.GetValue(message) + ")  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

            UCInjector(context);

            //Bookmark
            context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));
            Console.WriteLine("Activity Dalay  (Execute " + context.GetValue(message) + ")  thread (after create bookmark): " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void UCInjector(NativeActivityContext context)
        {
            IReferenceService myservice = context.GetExtension<IReferenceService>();
            IInjectedForm mainForm = myservice.GetInjectableFormReference();
            Console.WriteLine("Activity Delay (UCInjector " + context.GetValue(message) + ")  thread : " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action(() => mainForm.Inject(typeof(UserControls.UC_MessageWithDelays), new object[] 
                { 
                    mainForm, 
                    context.GetValue(status), 
                    context.GetValue(message) 
                })), null);
            }
            else
            {
                mainForm.Inject(typeof(UserControls.UC_MessageWithDelays), new object[] 
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
