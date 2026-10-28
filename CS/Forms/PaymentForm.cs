using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.UITemplates.Collection.Utilities;
using DevExpress.XtraEditors.Internal;
using DevExpress.XtraEditors.Mask;

namespace DevExpress.UITemplates.Collection.Forms {

    public partial class PaymentForm : HtmlFormBase {
        public PaymentForm() {
            InitializeComponent();
            if(!mvvmContext.IsDesignMode) {
                InitializeStyles();
                InitializeEditors();
                InitializeBinding();
            }
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
        void InitializeStyles() {
            Assets.Button.Apply(btnAccept.HtmlTemplate);
            Assets.Button.Apply(btnDecline.HtmlTemplate);
        }
        void InitializeEditors() {
            var nullValuePromptForeColor = Color.FromArgb(55, 102, 191);
            numberBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor;
            nameBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor;
            validThruMonthBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor;
            validThruYearBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor;
            cvcBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor;

            numberBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(new Padding(6, 3, 0, 0));
            nameBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(new Padding(8, 1, 0, 0));
            validThruMonthBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(new Padding(8, 1, 0, 0));
            validThruYearBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(new Padding(8, 1, 0, 0));
            cvcBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(new Padding(5, 2, 0, 0));

            numberBox.Properties.MaskSettings.Configure<MaskSettings.Simple>(x => {
                x.MaskExpression = "0000 0000 0000 0000";
                x.Placeholder = '0';
            });
            validThruMonthBox.Properties.MaskSettings.Configure<MaskSettings.DateTime>(x => x.MaskExpression = "MM");
            validThruYearBox.Properties.MaskSettings.Configure<MaskSettings.DateTime>(x => x.MaskExpression = "yy");
            cvcBox.Properties.MaskSettings.Configure<MaskSettings.Simple>(x => {
                x.MaskExpression = "000";
                x.Placeholder = '0';
            });
        }
        void InitializeBinding() {
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, x => x.Validate);
            fluent.SetBinding(this, frm => frm.Text, x => x.Title);
            fluent.SetBinding(btnAccept, btn => btn.Text, x => x.AcceptCaption);
            fluent.SetBinding(btnDecline, btn => btn.Text, x => x.DeclineCaption);
            fluent.BindCommand(btnAccept, x => x.Accept);
            fluent.BindCommand(btnDecline, x => x.Decline);
        }
        public class ViewModel : ISupportParameter {
            public ViewModel() {
                Card = new PaymentCard(null, DateTime.Now, string.Empty); 
            }
            public string Title {
                get { return "PAYMENT DETAILS"; }
            }
            public string AcceptCaption {
                get { return "Confirm and Pay"; }
            }
            public string DeclineCaption {
                get { return "Cancel"; }
            }
            object ISupportParameter.Parameter {
                get { return Card; }
                set { Card = value as PaymentCard; }
            }
            public virtual PaymentCard Card {
                get;
                protected set;
            }
            public virtual string CardNumber {
                get;
                set;
            }
            public virtual string CardHolder { 
                get; 
                set; 
            }
            public virtual string ValidThruMonth {
                get;
                set;
            }
            public virtual string ValidThruYear {
                get;
                set;
            }
            public virtual string CVC {
                get;
                set;
            }
            public void Validate() {
                Card = new PaymentCard(CardNumber, ValidThruMonth, ValidThruYear, CVC);
                this.RaiseCanExecuteChanged(x => x.Accept());
            }
            public bool CanAccept() {
                var cardType = PaymentCardType.Validate(Card?.Number ?? string.Empty);
                if(cardType == PaymentCard.Type.Invalid)
                    return false;
                if(Card.ExpirationDate < DateTime.Now.Date)
                    return false;
                if((Card.CVC ?? string.Empty).Length != 3)
                    return false;
                return !string.IsNullOrEmpty(CardHolder);
            }
            public void Accept() {
                /* do start payment procedure with current PaymentCard data */
            }
            public void Decline() {
                /* do some cleanup here */
            }
        }
        #region Theme
        protected override string LoadDefaultTemplate() {
            return Assets.Form.Html;
        }
        protected override string LoadDefaultStyles() {
            return Assets.Form.Css;
        }
        protected override string LoadDefaultLayoutTemplate() {
            return Assets.Layout.Html;
        }
        protected override string LoadDefaultLayoutStyles() {
            return Assets.Layout.Css;
        }
        public class Assets {
            public static HtmlCssAsset Form = new PaymentFormHtmlCssAsset();
            public static HtmlCssAsset Layout = new PaymentFormLayoutHtmlCssAsset();
            public static HtmlCssAsset Button = new PaymentFormButtonHtmlCssAsset();
            //
            sealed class PaymentFormHtmlCssAsset : HtmlCssAsset { }
            sealed class PaymentFormLayoutHtmlCssAsset : HtmlCssAsset { }
            sealed class PaymentFormButtonHtmlCssAsset : HtmlCssAsset { }
        }
        #endregion Theme
    }
}
