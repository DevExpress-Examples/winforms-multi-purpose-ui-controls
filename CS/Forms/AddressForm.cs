using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevExpress.UITemplates.Collection.Utilities;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors.Internal;

namespace DevExpress.UITemplates.Collection.Forms {

    public partial class AddressForm : HtmlFormBase {
        public AddressForm() {
            InitializeComponent();
            if(!mvvmContext.IsDesignMode)
                InitializeBinding();
        }
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Data")]
        public Address Result {
            get { return mvvmContext.OfType<ViewModel>().ViewModel?.Address; }
        }
        void InitializeBinding() {
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, x => x.Address, x => x.Validate);
            fluent.SetBinding(this, frm => frm.Text, x => x.Title);
            fluent.SetBinding(btnAccept, btn => btn.Text, x => x.Action);
            fluent.BindCommand(btnAccept, x => x.Accept);
        }
        public class Address {
            [Required(AllowEmptyStrings = false)]
            public virtual string Country { get; set; }
            [Required(AllowEmptyStrings = false)]
            public virtual string AddressLine1 { get; set; }
            public virtual string AddressLine2 { get; set; }
            [Required(AllowEmptyStrings = false)]
            public virtual string City { get; set; }
            public virtual string ZipCode { get; set; }
            public virtual string State { get; set; }
        }
        public class ViewModel {
            readonly ValidationContext validationContext;
            readonly List<ValidationResult> validationResults;
            public ViewModel() {
                Address = new Address();
                validationContext = new ValidationContext(Address);
                validationResults = new List<ValidationResult>();
            }
            public string Title {
                get { return "New Address"; }
            }
            public string Action {
                get { return "Accept"; }
            }
            public Address Address {
                get;
                private set;
            }
            public void Validate() {
                bool wasValid = validationResults.Count == 0;
                if(wasValid != ValidateAddress())
                    this.RaiseCanExecuteChanged(x => x.Accept());
            }
            bool ValidateAddress() {
                validationResults.Clear();
                return Validator.TryValidateObject(Address, validationContext, validationResults) && validationResults.Count == 0;
            }
            public bool CanAccept() {
                return ValidateAddress();
            }
            public void Accept() {
                /* do something if required */
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
            public static HtmlCssAsset Layout = new AddressFormLayoutHtmlCssAsset();
            //
            sealed class AddressFormLayoutHtmlCssAsset : HtmlCssAsset { }
        }
        #endregion Theme
    }
}
