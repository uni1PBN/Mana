using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication.Activities
{
    public class ActivityShow_UC_MessageWith2Buttons_OLD : NativeActivity<String>
    {
        #region Fields & Properties

        private String _buttonResult;
        private String _status;
        private HostApplication.MainForm _form;
        private HostApplication.UserControls.UC_MessageWith2Button _uc;

        [Category("Arguments")]
        public InArgument<String> message { get; set; }
        [Category("Arguments")]
        public InArgument<String> status { get; set; }

        public InArgument<System.Windows.Forms.Form> mainForm { get; set; }

        #endregion
        

        #region cTor

        public ActivityShow_UC_MessageWith2Buttons_OLD()
        {
            this.mainForm = new Microsoft.VisualBasic.Activities.VisualBasicValue<System.Windows.Forms.Form>("hostForm");
            this.Result = new Microsoft.VisualBasic.Activities.VisualBasicReference<String>("temp");
        }

        #endregion


        protected override void Execute(NativeActivityContext context)
        {
            _status = context.GetValue(status);
            _uc = new HostApplication.UserControls.UC_MessageWith2Button(context.GetValue(message));
            _uc.Dock = System.Windows.Forms.DockStyle.Fill;
            _uc.Location = new System.Drawing.Point(0, 0);
            _uc.Name = "activity1";
            _uc.TabIndex = 0;

            _form = context.GetValue(mainForm) as HostApplication.MainForm;
            InvokeInjectActivity();

            context.CreateBookmark("PushButtonBookmark", new BookmarkCallback(OnBookmarkCallback));

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
            _buttonResult = (String)val;
            System.Windows.Forms.MessageBox.Show(_buttonResult);
            this.Result.Set(context, _buttonResult);
            InvokeInjectStatus();

            InvokeRemoveActivity();
            _uc = null;
        }

        #endregion


        #region Invoke Host Application

        private void InvokeInjectActivity()
        {
            if (_form.InvokeRequired)
            {
                _form.Invoke(new Action(() => _form.panel1.Controls.Add(_uc)));
            }
            else
            {
                _form.panel1.Controls.Add(_uc);
            }
        }

        private void InvokeRemoveActivity()
        {
            if (_form.InvokeRequired)
            {
                _form.Invoke(new Action(() => _form.panel1.Controls.Remove(_uc)));
            }
            else
            {
                _form.panel1.Controls.Remove(_uc);
            }
        }

        private void InvokeInjectStatus()
        {
            if (_form.InvokeRequired)
            {
                _form.Invoke(new Action(() => _form.Statuslabel.Text = _status));
            }
            else
            {
                _form.Statuslabel.Text = _status;
            }
        }

        #endregion

    }
}
