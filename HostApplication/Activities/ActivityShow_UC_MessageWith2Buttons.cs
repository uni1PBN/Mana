﻿using HostApplication.Helpers;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication.Activities
{
    public class ActivityShow_UC_MessageWith2Buttons :  NativeActivity<String>
    {
        #region Fields & Properties

        //private HostApplication.MainForm _form;

        [Category("Arguments")]
        public InArgument<String> message { get; set; }
        [Category("Arguments")]
        public InArgument<String> status { get; set; }

        #endregion
        

        #region cTor

        public ActivityShow_UC_MessageWith2Buttons()
        {
            this.Result = new Microsoft.VisualBasic.Activities.VisualBasicReference<String>("temp");
            Console.WriteLine("Activity  (Constructor)  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        #endregion


        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine("Activity  (Start Execute " + context.GetValue(message) +")  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            
            UCInjector(context);

            Console.WriteLine("Activity  (Setting Bookmark " + context.GetValue(message) + ")  thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));
            Console.WriteLine("Activity  (Execute " + context.GetValue(message) + ")  thread (after create bookmark): " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void UCInjector(NativeActivityContext context)
        {
            IReferenceService myservice = context.GetExtension<IReferenceService>();
            IInjectedForm mainForm = myservice.GetInjectableFormReference();
            Console.WriteLine("Activity Msg_3_Buttons (UCInjector " + context.GetValue(message) + ")  thread : " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action(() => mainForm.Inject(typeof(UserControls.UC_MessageWith2Button), new object[] 
                { 
                    mainForm, 
                    context.GetValue(status), 
                    context.GetValue(message) 
                })), null);
            }
            else
            {
                mainForm.Inject(typeof(UserControls.UC_MessageWith2Button), new object[] 
                { 
                    mainForm, 
                    context.GetValue(status), 
                    context.GetValue(message) 
                });
            }
        }

        //private void UCInjector(NativeActivityContext context)
        //{
        //    HostApplication.Helpers.IReferenceService myservice = context.GetExtension<HostApplication.Helpers.IReferenceService>();
        //    _form = myservice.GetInjectableFormReference() as HostApplication.MainForm;
        //    Console.WriteLine("Activity (UC Injection " + context.GetValue(message) + ")  thread : " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        //    if (_form.InvokeRequired)
        //    {
        //        _form.Invoke(new Action(() => _form.InjectUC_MessageWith2Button(context.GetValue(message), context.GetValue(status))));
        //    }
        //    else
        //    {
        //        _form.InjectUC_MessageWith2Button(context.GetValue(message), context.GetValue(status));
        //    }

        //}
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
                //In case of reloading the activity (Recall a pending WF)
                UCInjector(context);
                context.CreateBookmark("Bookmark", new BookmarkCallback(OnBookmarkCallback));
                Console.WriteLine("Activity  (OnBookmarkCallback " + context.GetValue(message) + ")  thread (after create bookmark): " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            }
            this.Result.Set(context, (String)val);
        }

        #endregion
    }
}
