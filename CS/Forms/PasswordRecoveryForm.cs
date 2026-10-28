using DevExpress.Mvvm.POCO;
using DevExpress.UITemplates.Collection.Utilities;
using DevExpress.XtraEditors.Internal;

namespace DevExpress.UITemplates.Collection.Forms {

    public partial class PasswordRecoveryForm : HtmlFormBase {
        public PasswordRecoveryForm() {
            InitializeComponent();
            if(!mvvmContext.IsDesignMode) 
                InitializeBinding();
        }
        [System.ComponentModel.Category("Data"), System.ComponentModel.Browsable(false)]
        public string Email {
            get { return mvvmContext.OfType<ViewModel>().ViewModel?.Email ?? string.Empty; }
        }
        void InitializeBinding() {
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, x=> x.Validate);
            fluent.SetBinding(this, frm => frm.Text, x => x.Title);
            fluent.SetBinding(btnRecover, btn => btn.Text, x => x.Action);
            fluent.BindCommand(btnRecover, x => x.Recover);
        }
        public class ViewModel {
            public string Title {
                get { return "Account Recovery"; }
            }
            public string Subject {
                get { return "Please enter your email to recover your account."; }
            }
            public string Action {
                get { return "Get Password"; }
            }
            public virtual string Email { get; set; }
            bool IsEmailValid;
            public void Validate() {
                IsEmailValid = Utilities.Email.Validate(Email);
                this.RaiseCanExecuteChanged(x => x.Recover());
            }
            public bool CanRecover() {
                return IsEmailValid;
            }
            public void Recover() {
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
            public static HtmlCssAsset Layout = new PasswordRecoveryFormLayoutHtmlCssAsset();
            //
            sealed class PasswordRecoveryFormLayoutHtmlCssAsset : HtmlCssAsset { }
        }
        #endregion Theme
    }
}
