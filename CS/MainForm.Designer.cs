namespace UITemplatesExample {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteRibbonGalleryBarItem = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            bciOriginalPalette = new DevExpress.XtraBars.BarCheckItem();
            bciTrackWindowsAccentColor = new DevExpress.XtraBars.BarCheckItem();
            bbiCustomColors = new DevExpress.XtraBars.BarButtonItem();
            bbiCustomColors2 = new DevExpress.XtraBars.BarButtonItem();
            bciTrackWindowsAppMode = new DevExpress.XtraBars.BarCheckItem();
            ribbonPageAppearance = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroupAppearance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupAccentColors = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            navigationAccordion = new DevExpress.XtraBars.Navigation.AccordionControl();
            formsGroupAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            addressFormAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            creditCardFormAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            loginFormAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            passwordFormAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            passwordRecoveryFormAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            paymentFormAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            userControlsGroupAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            contactListAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            contactsViewAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            employeeDetailsAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            employeeDetailsMvvmAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            employeesHierarchyAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            employeesHierarchyMvvmAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            employeesMasterDetailAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            employeesMasterDetailMvvmAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            editorsGroupAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            countryChooserAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            dateRangePickerAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            editBoxAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            emailBoxAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            passwordBoxAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            paymentCardBoxAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            phoneNumberBoxAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            buttonsGroupsAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            buttonAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            chipButtonAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            chipGroupAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            multiSelectChipGroupAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            radioButtonGroupAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            toggleButtonAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            toggleButtonGroupAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            twinButtonAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)navigationAccordion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)documentManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ApplicationButtonText = "File";
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, skinDropDownButtonItem1, skinPaletteRibbonGalleryBarItem, bciOriginalPalette, bciTrackWindowsAccentColor, bbiCustomColors, bbiCustomColors2, bciTrackWindowsAppMode });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 8;
            ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPageAppearance });
            ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            ribbonControl1.ShowToolbarCustomizeItem = false;
            ribbonControl1.Size = new Size(1099, 201);
            ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // skinDropDownButtonItem1
            // 
            skinDropDownButtonItem1.Id = 1;
            skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // skinPaletteRibbonGalleryBarItem
            // 
            skinPaletteRibbonGalleryBarItem.Caption = "skinPaletteRibbonGalleryBarItem";
            skinPaletteRibbonGalleryBarItem.Id = 8;
            skinPaletteRibbonGalleryBarItem.Name = "skinPaletteRibbonGalleryBarItem";
            // 
            // bciOriginalPalette
            // 
            bciOriginalPalette.Caption = "Original Palette";
            bciOriginalPalette.Id = 3;
            bciOriginalPalette.ImageOptions.ImageUri.Uri = "arrows/stop";
            bciOriginalPalette.Name = "bciOriginalPalette";
            // 
            // bciTrackWindowsAccentColor
            // 
            bciTrackWindowsAccentColor.Caption = "Track Window Accent Color";
            bciTrackWindowsAccentColor.Id = 4;
            bciTrackWindowsAccentColor.ImageOptions.ImageUri.Uri = "arrows/stop";
            bciTrackWindowsAccentColor.Name = "bciTrackWindowsAccentColor";
            // 
            // bbiCustomColors
            // 
            bbiCustomColors.Caption = "Custom Colors";
            bbiCustomColors.Id = 5;
            bbiCustomColors.ImageOptions.ImageUri.Uri = "arrows/stop";
            bbiCustomColors.Name = "bbiCustomColors";
            // 
            // bbiCustomColors2
            // 
            bbiCustomColors2.Caption = "Custom Colors 2";
            bbiCustomColors2.Id = 6;
            bbiCustomColors2.ImageOptions.ImageUri.Uri = "arrows/stop";
            bbiCustomColors2.Name = "bbiCustomColors2";
            // 
            // bciTrackWindowsAppMode
            // 
            bciTrackWindowsAppMode.Caption = "Track Window App Mode";
            bciTrackWindowsAppMode.Id = 7;
            bciTrackWindowsAppMode.ImageOptions.ImageUri.Uri = "arrows/stop";
            bciTrackWindowsAppMode.Name = "bciTrackWindowsAppMode";
            // 
            // ribbonPageAppearance
            // 
            ribbonPageAppearance.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupAppearance, ribbonPageGroupAccentColors });
            ribbonPageAppearance.Name = "ribbonPageAppearance";
            ribbonPageAppearance.Text = "Appearance";
            // 
            // ribbonPageGroupAppearance
            // 
            ribbonPageGroupAppearance.ItemLinks.Add(skinDropDownButtonItem1);
            ribbonPageGroupAppearance.ItemLinks.Add(skinPaletteRibbonGalleryBarItem);
            ribbonPageGroupAppearance.Name = "ribbonPageGroupAppearance";
            ribbonPageGroupAppearance.Text = "Appearance";
            // 
            // ribbonPageGroupAccentColors
            // 
            ribbonPageGroupAccentColors.ItemLinks.Add(bciTrackWindowsAppMode);
            ribbonPageGroupAccentColors.ItemLinks.Add(bciOriginalPalette);
            ribbonPageGroupAccentColors.ItemLinks.Add(bciTrackWindowsAccentColor);
            ribbonPageGroupAccentColors.ItemLinks.Add(bbiCustomColors);
            ribbonPageGroupAccentColors.ItemLinks.Add(bbiCustomColors2);
            ribbonPageGroupAccentColors.Name = "ribbonPageGroupAccentColors";
            ribbonPageGroupAccentColors.Text = "Accent Colors";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // navigationAccordion
            // 
            navigationAccordion.AllowItemSelection = true;
            navigationAccordion.Dock = DockStyle.Left;
            navigationAccordion.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { formsGroupAccordionControlElement, userControlsGroupAccordionControlElement, editorsGroupAccordionControlElement, buttonsGroupsAccordionControlElement });
            navigationAccordion.Location = new Point(0, 49);
            navigationAccordion.Margin = new Padding(2);
            navigationAccordion.MinimumSize = new Size(0, 751);
            navigationAccordion.Name = "navigationAccordion";
            navigationAccordion.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            navigationAccordion.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            navigationAccordion.Size = new Size(255, 751);
            navigationAccordion.TabIndex = 2;
            navigationAccordion.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            navigationAccordion.SelectedElementChanged += OnSelectedAccordionElementChanged;
            // 
            // formsGroupAccordionControlElement
            // 
            formsGroupAccordionControlElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { addressFormAccordionControlElement, creditCardFormAccordionControlElement, loginFormAccordionControlElement, passwordFormAccordionControlElement, passwordRecoveryFormAccordionControlElement, paymentFormAccordionControlElement });
            formsGroupAccordionControlElement.Expanded = true;
            formsGroupAccordionControlElement.Name = "formsGroupAccordionControlElement";
            formsGroupAccordionControlElement.Text = "Forms";
            // 
            // addressFormAccordionControlElement
            // 
            addressFormAccordionControlElement.Name = "addressFormAccordionControlElement";
            addressFormAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            addressFormAccordionControlElement.Text = "Address Form";
            // 
            // creditCardFormAccordionControlElement
            // 
            creditCardFormAccordionControlElement.Name = "creditCardFormAccordionControlElement";
            creditCardFormAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            creditCardFormAccordionControlElement.Text = "Credit Card Form";
            // 
            // loginFormAccordionControlElement
            // 
            loginFormAccordionControlElement.Name = "loginFormAccordionControlElement";
            loginFormAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            loginFormAccordionControlElement.Text = "Login Form";
            // 
            // passwordFormAccordionControlElement
            // 
            passwordFormAccordionControlElement.Name = "passwordFormAccordionControlElement";
            passwordFormAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            passwordFormAccordionControlElement.Text = "Password Form";
            // 
            // passwordRecoveryFormAccordionControlElement
            // 
            passwordRecoveryFormAccordionControlElement.Name = "passwordRecoveryFormAccordionControlElement";
            passwordRecoveryFormAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            passwordRecoveryFormAccordionControlElement.Text = "Password Recovery Form";
            // 
            // paymentFormAccordionControlElement
            // 
            paymentFormAccordionControlElement.Name = "paymentFormAccordionControlElement";
            paymentFormAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            paymentFormAccordionControlElement.Text = "Payment Form";
            // 
            // userControlsGroupAccordionControlElement
            // 
            userControlsGroupAccordionControlElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { contactListAccordionControlElement, contactsViewAccordionControlElement, employeeDetailsAccordionControlElement, employeeDetailsMvvmAccordionControlElement, employeesHierarchyAccordionControlElement, employeesHierarchyMvvmAccordionControlElement, employeesMasterDetailAccordionControlElement, employeesMasterDetailMvvmAccordionControlElement });
            userControlsGroupAccordionControlElement.Name = "userControlsGroupAccordionControlElement";
            userControlsGroupAccordionControlElement.Text = "User Controls";
            // 
            // contactListAccordionControlElement
            // 
            contactListAccordionControlElement.Name = "contactListAccordionControlElement";
            contactListAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            contactListAccordionControlElement.Text = "Contact List";
            // 
            // contactsViewAccordionControlElement
            // 
            contactsViewAccordionControlElement.Name = "contactsViewAccordionControlElement";
            contactsViewAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            contactsViewAccordionControlElement.Text = "Contacts View";
            // 
            // employeeDetailsAccordionControlElement
            // 
            employeeDetailsAccordionControlElement.Name = "employeeDetailsAccordionControlElement";
            employeeDetailsAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            employeeDetailsAccordionControlElement.Text = "Employee Details";
            // 
            // employeeDetailsMvvmAccordionControlElement
            // 
            employeeDetailsMvvmAccordionControlElement.Name = "employeeDetailsMvvmAccordionControlElement";
            employeeDetailsMvvmAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            employeeDetailsMvvmAccordionControlElement.Text = "Employee Details (MVVM)";
            // 
            // employeesHierarchyAccordionControlElement
            // 
            employeesHierarchyAccordionControlElement.Name = "employeesHierarchyAccordionControlElement";
            employeesHierarchyAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            employeesHierarchyAccordionControlElement.Text = "Employees Hierarchy";
            // 
            // employeesHierarchyMvvmAccordionControlElement
            // 
            employeesHierarchyMvvmAccordionControlElement.Name = "employeesHierarchyMvvmAccordionControlElement";
            employeesHierarchyMvvmAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            employeesHierarchyMvvmAccordionControlElement.Text = "Employees Hierarchy (MVVM)";
            // 
            // employeesMasterDetailAccordionControlElement
            // 
            employeesMasterDetailAccordionControlElement.Name = "employeesMasterDetailAccordionControlElement";
            employeesMasterDetailAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            employeesMasterDetailAccordionControlElement.Text = "Employees Master-Detail";
            // 
            // employeesMasterDetailMvvmAccordionControlElement
            // 
            employeesMasterDetailMvvmAccordionControlElement.Name = "employeesMasterDetailMvvmAccordionControlElement";
            employeesMasterDetailMvvmAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            employeesMasterDetailMvvmAccordionControlElement.Text = "Employees Master-Detail (MVVM)";
            // 
            // editorsGroupAccordionControlElement
            // 
            editorsGroupAccordionControlElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { countryChooserAccordionControlElement, dateRangePickerAccordionControlElement, editBoxAccordionControlElement, emailBoxAccordionControlElement, passwordBoxAccordionControlElement, paymentCardBoxAccordionControlElement, phoneNumberBoxAccordionControlElement });
            editorsGroupAccordionControlElement.Name = "editorsGroupAccordionControlElement";
            editorsGroupAccordionControlElement.Text = "Editors";
            // 
            // countryChooserAccordionControlElement
            // 
            countryChooserAccordionControlElement.Name = "countryChooserAccordionControlElement";
            countryChooserAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            countryChooserAccordionControlElement.Text = "Country Chooser";
            // 
            // dateRangePickerAccordionControlElement
            // 
            dateRangePickerAccordionControlElement.Name = "dateRangePickerAccordionControlElement";
            dateRangePickerAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            dateRangePickerAccordionControlElement.Text = "Date Range Picker";
            // 
            // editBoxAccordionControlElement
            // 
            editBoxAccordionControlElement.Name = "editBoxAccordionControlElement";
            editBoxAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            editBoxAccordionControlElement.Text = "Edit Box";
            // 
            // emailBoxAccordionControlElement
            // 
            emailBoxAccordionControlElement.Name = "emailBoxAccordionControlElement";
            emailBoxAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            emailBoxAccordionControlElement.Text = "Email Box";
            // 
            // passwordBoxAccordionControlElement
            // 
            passwordBoxAccordionControlElement.Name = "passwordBoxAccordionControlElement";
            passwordBoxAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            passwordBoxAccordionControlElement.Text = "Password Box";
            // 
            // paymentCardBoxAccordionControlElement
            // 
            paymentCardBoxAccordionControlElement.Name = "paymentCardBoxAccordionControlElement";
            paymentCardBoxAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            paymentCardBoxAccordionControlElement.Text = "Payment Card Box";
            // 
            // phoneNumberBoxAccordionControlElement
            // 
            phoneNumberBoxAccordionControlElement.Name = "phoneNumberBoxAccordionControlElement";
            phoneNumberBoxAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            phoneNumberBoxAccordionControlElement.Text = "Phone Number Box";
            // 
            // buttonsGroupsAccordionControlElement
            // 
            buttonsGroupsAccordionControlElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { buttonAccordionControlElement, chipButtonAccordionControlElement, chipGroupAccordionControlElement, multiSelectChipGroupAccordionControlElement, radioButtonGroupAccordionControlElement, toggleButtonAccordionControlElement, toggleButtonGroupAccordionControlElement, twinButtonAccordionControlElement });
            buttonsGroupsAccordionControlElement.Name = "buttonsGroupsAccordionControlElement";
            buttonsGroupsAccordionControlElement.Text = "Buttons";
            // 
            // buttonAccordionControlElement
            // 
            buttonAccordionControlElement.Name = "buttonAccordionControlElement";
            buttonAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            buttonAccordionControlElement.Text = "Button";
            // 
            // chipButtonAccordionControlElement
            // 
            chipButtonAccordionControlElement.Name = "chipButtonAccordionControlElement";
            chipButtonAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            chipButtonAccordionControlElement.Text = "Chip Button";
            // 
            // chipGroupAccordionControlElement
            // 
            chipGroupAccordionControlElement.Name = "chipGroupAccordionControlElement";
            chipGroupAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            chipGroupAccordionControlElement.Text = "Chip Group";
            // 
            // multiSelectChipGroupAccordionControlElement
            // 
            multiSelectChipGroupAccordionControlElement.Name = "multiSelectChipGroupAccordionControlElement";
            multiSelectChipGroupAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            multiSelectChipGroupAccordionControlElement.Text = "Multi-select Chip Group";
            // 
            // radioButtonGroupAccordionControlElement
            // 
            radioButtonGroupAccordionControlElement.Name = "radioButtonGroupAccordionControlElement";
            radioButtonGroupAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            radioButtonGroupAccordionControlElement.Text = "Radio Button Group";
            // 
            // toggleButtonAccordionControlElement
            // 
            toggleButtonAccordionControlElement.Name = "toggleButtonAccordionControlElement";
            toggleButtonAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            toggleButtonAccordionControlElement.Text = "Toggle Button";
            // 
            // toggleButtonGroupAccordionControlElement
            // 
            toggleButtonGroupAccordionControlElement.Name = "toggleButtonGroupAccordionControlElement";
            toggleButtonGroupAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            toggleButtonGroupAccordionControlElement.Text = "Toggle Button Group";
            // 
            // twinButtonAccordionControlElement
            // 
            twinButtonAccordionControlElement.Name = "twinButtonAccordionControlElement";
            twinButtonAccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            twinButtonAccordionControlElement.Text = "Twin Button";
            // 
            // documentManager
            // 
            documentManager.MdiParent = this;
            documentManager.View = tabbedView1;
            documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { tabbedView1 });
            // 
            // tabbedView1
            // 
            tabbedView1.DocumentGroupProperties.ShowTabHeader = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 799);
            Controls.Add(navigationAccordion);
            Controls.Add(ribbonControl1);
            IsMdiContainer = true;
            Name = "MainForm";
            NavigationControl = navigationAccordion;
            NavigationControlLayoutMode = DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle;
            Ribbon = ribbonControl1;
            Text = "UI Templates Example";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)navigationAccordion).EndInit();
            ((System.ComponentModel.ISupportInitialize)documentManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Navigation.AccordionControl navigationAccordion;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageAppearance;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAppearance;
        private DevExpress.XtraBars.BarCheckItem bciOriginalPalette;
        private DevExpress.XtraBars.BarCheckItem bciTrackWindowsAccentColor;
        private DevExpress.XtraBars.BarButtonItem bbiCustomColors;
        private DevExpress.XtraBars.BarButtonItem bbiCustomColors2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAccentColors;
        private DevExpress.XtraBars.BarCheckItem bciTrackWindowsAppMode;
        private DevExpress.XtraBars.Navigation.AccordionControlElement formsGroupAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement userControlsGroupAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement editorsGroupAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement buttonsGroupsAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement buttonAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement chipButtonAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement chipGroupAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement multiSelectChipGroupAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement radioButtonGroupAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement toggleButtonAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement toggleButtonGroupAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement twinButtonAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement countryChooserAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement dateRangePickerAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement editBoxAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement emailBoxAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement passwordBoxAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement paymentCardBoxAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement phoneNumberBoxAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement contactListAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement contactsViewAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement employeeDetailsAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement employeeDetailsMvvmAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement employeesHierarchyAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement employeesHierarchyMvvmAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement employeesMasterDetailAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement employeesMasterDetailMvvmAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement addressFormAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement creditCardFormAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement loginFormAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement passwordFormAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement passwordRecoveryFormAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement paymentFormAccordionControlElement;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
    }
}
