using DevExpress.UITemplates.Collection.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Navigation;

namespace UITemplatesExample {
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public IServiceProvider? Services { get; private set; }

        public MainForm() {
            InitializeComponent();
        }
        public MainForm(IServiceProvider serviceProvider) : this() {
            Services = serviceProvider;
            tabbedView1.DocumentClosed += OnDocumentClosed;
            InitNavigationItems();
            InitAccentColors();
        }
        void OnDocumentClosed(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e) {
            foreach(var item in openedViews.Where(x => x.Value == e.Document.Control).ToList())
                openedViews.Remove(item.Key);
        }

        void InitNavigationItems() {
            // Forms
            addressFormAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.Forms.AddressForm);
            creditCardFormAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.Forms.CreditCardForm);
            loginFormAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.Forms.LoginForm);
            passwordFormAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.Forms.PasswordForm);
            passwordRecoveryFormAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.Forms.PasswordRecoveryForm);
            paymentFormAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.Forms.PaymentForm);

            // User Controls
            contactListAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.UserControls.ContactList);
            contactsViewAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.UserControls.ContactsSimple);
            employeeDetailsAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.UserControls.EmployeeDetailsSimple);
            employeeDetailsMvvmAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.UserControls.EmployeeDetails);
            employeesHierarchyAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.UserControls.EmployeesHierarchySimple);
            employeesHierarchyMvvmAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.UserControls.EmployeesHierarchy);
            employeesMasterDetailAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.UserControls.EmployeesMasterDetailSimple);
            employeesMasterDetailMvvmAccordionControlElement.Tag = typeof(DevExpress.UITemplates.Collection.UserControls.EmployeesMasterDetail);
            
            // Editors
            countryChooserAccordionControlElement.Tag = typeof(Views.CountryChooserView);
            dateRangePickerAccordionControlElement.Tag = typeof(Views.DateRangePickerView);
            editBoxAccordionControlElement.Tag = typeof(Views.EditBoxView);
            emailBoxAccordionControlElement.Tag = typeof(Views.EmailBoxView);
            passwordBoxAccordionControlElement.Tag = typeof(Views.PasswordBoxView);
            paymentCardBoxAccordionControlElement.Tag = typeof(Views.PaymentCardBoxView);
            phoneNumberBoxAccordionControlElement.Tag = typeof(Views.PhoneNumberBoxView);

            // Buttons
            buttonAccordionControlElement.Tag = typeof(Views.ButtonView);
            chipButtonAccordionControlElement.Tag = typeof(Views.ChipButtonView);
            chipGroupAccordionControlElement.Tag = typeof(Views.ChipGroupView);
            multiSelectChipGroupAccordionControlElement.Tag = typeof(Views.MultiSelectChipGroupView);
            radioButtonGroupAccordionControlElement.Tag = typeof(Views.RadioButtonGroupView);
            toggleButtonAccordionControlElement.Tag = typeof(Views.ToggleButtonView);
            toggleButtonGroupAccordionControlElement.Tag = typeof(Views.ToggleButtonGroupView);
            twinButtonAccordionControlElement.Tag = typeof(Views.TwinButtonView);

            // Clear selection
            navigationAccordion.SelectedElement = null;
        }

        readonly System.Collections.Generic.Dictionary<Type, Control> openedViews = new System.Collections.Generic.Dictionary<Type, Control>();
        void OnSelectedAccordionElementChanged(object sender, SelectedElementChangedEventArgs e) {
            if(e.Element?.Tag is not Type viewType)
                return;
            HideOpenForms(viewType);
            if(!typeof(Form).IsAssignableFrom(viewType))
                SetDocumentsVisible(true);
            if(openedViews.TryGetValue(viewType, out var opened)) {
                // Reactivate
                if(opened is Form openedForm) {
                    if(!openedForm.IsDisposed) {
                        if(openedForm.WindowState == FormWindowState.Minimized)
                            openedForm.WindowState = FormWindowState.Normal;
                        openedForm.Show(this);
                        SetDocumentsVisible(false);
                        openedForm.Activate();
                        return;
                    }
                    openedViews.Remove(viewType);
                }
                else { // Reactivate document if it is already added
                    var document = tabbedView1.Documents.FirstOrDefault(d => d.Control == opened);
                    if(document != null) {
                        tabbedView1.Controller.Activate(document);
                        return;
                    }
                    openedViews.Remove(viewType);
                }
            }
            var control = (Control)Services.GetService(viewType);
            openedViews[viewType] = control;
            if(control is Form form) {
                form.FormClosed += (s, args) => {
                    if(openedViews.TryGetValue(viewType, out var current) && current == form)
                        openedViews.Remove(viewType);
                    SetDocumentsVisible(true);
                };
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show(this);
                SetDocumentsVisible(false);
            }
            else {
                var document = tabbedView1.AddDocument(control);
                document.Caption = e.Element.Text;
            }
        }

        void SetDocumentsVisible(bool visible) {
            foreach(Control c in Controls)
                if(c is MdiClient)
                    c.Visible = visible;
        }

        void HideOpenForms(Type exceptViewType) {
            foreach(var item in openedViews)
                if(item.Key != exceptViewType && item.Value is Form f && !f.IsDisposed && f.Visible)
                    f.Hide();
        }

        void InitAccentColors() {
            SkinHelper.InitTrackWindowsAppMode(bciTrackWindowsAppMode);
            bciTrackWindowsAppMode.SuperTip = new SuperToolTip();
            bciTrackWindowsAppMode.SuperTip.Items.Add("This setting is available for WXI, Basic, and Bezier skins.");
            bciTrackWindowsAppMode.SuperTip.Items[0].Appearance.FontStyleDelta = FontStyle.Bold;
            SkinHelper.InitResetToOriginalPalette(bciOriginalPalette);
            SkinHelper.InitTrackWindowsAccentColor(bciTrackWindowsAccentColor);
            SkinHelper.InitCustomAccentColor(Ribbon.Manager, bbiCustomColors);
            bbiCustomColors.SuperTip = new SuperToolTip();
            bbiCustomColors.SuperTip.Items.Add("Custom Accent Color.");
            bbiCustomColors.SuperTip.Items[0].Appearance.FontStyleDelta = FontStyle.Bold;
            SkinHelper.InitCustomAccentColor2(Ribbon.Manager, bbiCustomColors2);
            bbiCustomColors2.SuperTip = new SuperToolTip();
            bbiCustomColors2.SuperTip.Items.Add("Custom Accent Color 2.");
            bbiCustomColors2.SuperTip.Items[0].Appearance.FontStyleDelta = FontStyle.Bold;
        }

    }
}

