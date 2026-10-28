using DevExpress.UITemplates.Collection.Utilities;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors.Internal;

namespace DevExpress.UITemplates.Collection.Forms {

    public partial class PasswordForm : HtmlFormBase {
        public PasswordForm() {
            InitializeComponent();
            if(!mvvmContext.IsDesignMode)
                InitializeBinding();
        }
        [System.ComponentModel.Category("Data"), System.ComponentModel.Browsable(false)]
        public string Password {
            get { return mvvmContext.OfType<ViewModel>().ViewModel?.Password ?? string.Empty; }
        }
        void InitializeBinding() {
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, x => x.Validate);
            fluent.SetBinding(this, frm => frm.Text, x => x.Title);
            fluent.SetBinding(btnChange, btn => btn.Text, x => x.Action);
            fluent.SetBinding(tbConfirmPassword, pwd => pwd.ErrorText, x => x.ConfirmedPasswordError);
            fluent.BindCommand(btnChange, x => x.ChangePassword);
        }
        public class ViewModel {
            public string Title {
                get { return "Create Password"; }
            }
            public string Subject {
                get { return "Please create a password you haven't used before."; }
            }
            public string Action {
                get { return "Create Password"; }
            }
            public virtual string Password { get; set; }
            public virtual string ConfirmedPassword { get; set; }
            public virtual string ConfirmedPasswordError { get; set; }
            public void Validate() {
                if(!string.IsNullOrEmpty(ConfirmedPassword) && !string.IsNullOrEmpty(Password) && ConfirmedPassword != Password)
                    ConfirmedPasswordError = "Passwords do not match.";
                else ConfirmedPasswordError = string.Empty;
                this.RaiseCanExecuteChanged(x => x.ChangePassword());
            }
            public bool CanChangePassword() {
                if(string.IsNullOrEmpty(Password))
                    return false;
                if(string.IsNullOrEmpty(ConfirmedPassword))
                    return false;
                if(ConfirmedPassword != Password)
                    return false;
                return Utilities.Password.Check(Password) >= Utilities.Password.Strength.Medium;
            }
            public void ChangePassword() {
                /* do something */
            }
        }
        #region Theme
        protected override object LoadDefaultHtmlImages() {
            return Base.FormAssets.DefaultHtmlImages;
        }
        protected override string LoadDefaultTemplate() {
            return Base.FormAssets.FixedDialog.Html;
        }
        protected override string LoadDefaultStyles() {
            return Base.FormAssets.FixedDialog.Css;
        }
        protected override string LoadDefaultLayoutTemplate() {
            return Assets.Layout.Html;
        }
        protected override string LoadDefaultLayoutStyles() {
            return Assets.Layout.Css;
        }
        public class Assets {
            public static HtmlCssAsset Layout = new PasswordFormLayoutHtmlCssAsset();
            //
            sealed class PasswordFormLayoutHtmlCssAsset : HtmlCssAsset { }
        }
        #endregion Theme
    }
}
