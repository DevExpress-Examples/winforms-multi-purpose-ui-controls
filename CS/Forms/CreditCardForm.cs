using System;
using DevExpress.UITemplates.Collection.Utilities;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors.Internal;

namespace DevExpress.UITemplates.Collection.Forms {

    public partial class CreditCardForm : HtmlFormBase {
        public CreditCardForm() {
            InitializeComponent();
            if(!mvvmContext.IsDesignMode) 
                InitializeBinding();
        }
        [System.ComponentModel.Category("Data"), System.ComponentModel.Browsable(false)]
        public PaymentCard Card {
            get { return GetViewModel()?.Card ?? PaymentCard.EmptyCard; }
        }
        [System.ComponentModel.Category("Data"), System.ComponentModel.Browsable(false)]
        public string CardHolder {
            get { return GetViewModel()?.CardHolder ?? string.Empty; }
        }
        ViewModel GetViewModel() {
            return mvvmContext.OfType<ViewModel>().ViewModel;
        }
        void InitializeBinding() {
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, x => x.Validate);
            fluent.SetBinding(this, frm => frm.Text, x => x.Title);
            fluent.SetBinding(btnAdd, btn => btn.Text, x => x.Action);
            fluent.BindCommand(btnAdd, x => x.AddCard);
        }
        public class ViewModel {
            public string Title {
                get { return "Add Card"; }
            }
            public string Action {
                get { return "Add Card"; }
            }
            public string CardNumber {
                get { return Card?.NumberMasked ?? "0000 0000 0000 0000"; }
            }
            public string HolderName {
                get { return !string.IsNullOrEmpty(CardHolder) ? CardHolder : "CARD HOLDER"; }
            }
            public string ValidThru {
                get { return (Card?.ExpirationDate)?.ToString("MM/yy") ?? "MM/YY"; }
            }
            public virtual PaymentCard Card { get; set; }
            public virtual string CardHolder { get; set; }
            public void Validate() {
                this.RaisePropertyChanged(x => x.CardNumber);
                this.RaisePropertyChanged(x => x.HolderName);
                this.RaisePropertyChanged(x => x.ValidThru);
                this.RaiseCanExecuteChanged(x => x.AddCard());
            }
            public bool CanAddCard() {
                var cardType = PaymentCardType.Validate(Card?.Number ?? string.Empty);
                if(cardType == PaymentCard.Type.Invalid)
                    return false;
                if(Card.ExpirationDate < DateTime.Now.Date)
                    return false;
                if((Card.CVC ?? string.Empty).Length != 3)
                    return false;
                return !string.IsNullOrEmpty(CardHolder); ;
            }
            public void AddCard() {
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
            public static HtmlCssAsset Layout = new CreditCardFormLayoutHtmlCssAsset();
            //
            sealed class CreditCardFormLayoutHtmlCssAsset : HtmlCssAsset { }
        }
        #endregion Theme
    }
}
