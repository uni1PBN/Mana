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
    public class ActivityShow_UC_MessageWith3Buttons :  NativeActivity<String>
    {
        #region Fields & Properties

        //private HostApplication.Helpers.IInjectedForm mainForm;
        //private HostApplication.MainForm mainForm;

        [Category("Arguments")]
        public InArgument<String> message { get; set; }
        [Category("Arguments")]
        public InArgument<String> status { get; set; }

        #endregion
        

        #region cTor

        public ActivityShow_UC_MessageWith3Buttons()
        {
            this.Result = new Microsoft.VisualBasic.Activities.VisualBasicReference<String>("temp");
            Console.WriteLine("Activity Msg_3_Buttons  (Constructor)  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        #endregion


        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine("Activity Msg_3_Buttons  (Execute " + context.GetValue(message) + ")  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            UCInjector(context);
            context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));
            Console.WriteLine("Activity Msg_3_Buttons  (Execute " + context.GetValue(message) + ")  thread (after create bookmark): " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void UCInjector(NativeActivityContext context)
        {
            IReferenceService myservice = context.GetExtension<IReferenceService>();
            IInjectedForm mainForm = myservice.GetInjectableFormReference();
            Console.WriteLine("Activity Msg_3_Buttons (UCInjector " + context.GetValue(message) + ")  thread : " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action(() => mainForm.Inject(typeof(UserControls.MessageWith3Button), new object[] 
                { 
                    mainForm, 
                    context.GetValue(status), 
                    context.GetValue(message) 
                })), null);
            }
            else
            {
                mainForm.Inject(typeof(UserControls.MessageWith3Button), new object[] 
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
