namespace DevExpress.UITemplates.Collection.Forms {
    partial class AddressForm {
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
            this.components = new System.ComponentModel.Container();
            this.layoutContainer = new DevExpress.XtraEditors.HtmlContentControl();
            this.ccCountry = new DevExpress.UITemplates.Collection.Editors.CountryChooser();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ebAddressLine1 = new DevExpress.UITemplates.Collection.Editors.EditBox();
            this.ebAddressLine2 = new DevExpress.UITemplates.Collection.Editors.EditBox();
            this.ebZipCode = new DevExpress.UITemplates.Collection.Editors.EditBox();
            this.ebCity = new DevExpress.UITemplates.Collection.Editors.EditBox();
            this.ebState = new DevExpress.UITemplates.Collection.Editors.EditBox();
            this.btnAccept = new DevExpress.UITemplates.Collection.Editors.Button();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.dxContainer = new DevExpress.XtraEditors.DirectXFormContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).BeginInit();
            this.layoutContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebAddressLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebAddressLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebZipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.dxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutContainer
            // 
            this.layoutContainer.AllowFocus = false;
            this.layoutContainer.Controls.Add(this.ccCountry);
            this.layoutContainer.Controls.Add(this.ebAddressLine1);
            this.layoutContainer.Controls.Add(this.ebAddressLine2);
            this.layoutContainer.Controls.Add(this.ebZipCode);
            this.layoutContainer.Controls.Add(this.ebCity);
            this.layoutContainer.Controls.Add(this.ebState);
            this.layoutContainer.Controls.Add(this.btnAccept);
            this.layoutContainer.DataContext = this.viewModelBindingSource;
            this.layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutContainer.Location = new System.Drawing.Point(0, 0);
            this.layoutContainer.Name = "layoutContainer";
            this.layoutContainer.Size = new System.Drawing.Size(396, 218);
            this.layoutContainer.TabIndex = 0;
            this.layoutContainer.TabStop = false;
            // 
            // ccCountry
            // 
            this.ccCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "Country", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ccCountry.Location = new System.Drawing.Point(36, 20);
            this.ccCountry.Name = "ccCountry";
            this.ccCountry.Placeholder = "Country*";
            this.ccCountry.Size = new System.Drawing.Size(324, 23);
            this.ccCountry.TabIndex = 0;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(DevExpress.UITemplates.Collection.Forms.AddressForm.Address);
            // 
            // ebAddressLine1
            // 
            this.ebAddressLine1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "AddressLine1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ebAddressLine1.Location = new System.Drawing.Point(36, 51);
            this.ebAddressLine1.Name = "ebAddressLine1";
            this.ebAddressLine1.Placeholder = "Address Line 1*";
            this.ebAddressLine1.Size = new System.Drawing.Size(324, 20);
            this.ebAddressLine1.TabIndex = 1;
            // 
            // ebAddressLine2
            // 
            this.ebAddressLine2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "AddressLine2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ebAddressLine2.Location = new System.Drawing.Point(36, 79);
            this.ebAddressLine2.Name = "ebAddressLine2";
            this.ebAddressLine2.Placeholder = "Address Line 2";
            this.ebAddressLine2.Size = new System.Drawing.Size(324, 20);
            this.ebAddressLine2.TabIndex = 2;
            // 
            // ebZipCode
            // 
            this.ebZipCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "ZipCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ebZipCode.Location = new System.Drawing.Point(260, 107);
            this.ebZipCode.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.ebZipCode.MaskSettings.Set("MaskManagerSignature", "isOptimistic=False");
            this.ebZipCode.MaskSettings.Set("mask", "\\d+");
            this.ebZipCode.Name = "ebZipCode";
            this.ebZipCode.Placeholder = "ZIP Code";
            this.ebZipCode.Size = new System.Drawing.Size(100, 20);
            this.ebZipCode.TabIndex = 5;
            // 
            // ebCity
            // 
            this.ebCity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ebCity.Location = new System.Drawing.Point(36, 107);
            this.ebCity.Name = "ebCity";
            this.ebCity.Placeholder = "City*";
            this.ebCity.Size = new System.Drawing.Size(108, 20);
            this.ebCity.TabIndex = 3;
            // 
            // ebState
            // 
            this.ebState.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "State", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ebState.Location = new System.Drawing.Point(152, 107);
            this.ebState.Name = "ebState";
            this.ebState.Placeholder = "State";
            this.ebState.Size = new System.Drawing.Size(100, 20);
            this.ebState.TabIndex = 4;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(260, 166);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 32);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "{Action}";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(DevExpress.UITemplates.Collection.Forms.AddressForm.ViewModel);
            // 
            // dxContainer
            // 
            this.dxContainer.Controls.Add(this.layoutContainer);
            this.dxContainer.Location = new System.Drawing.Point(1, 31);
            this.dxContainer.Name = "dxContainer";
            this.dxContainer.Size = new System.Drawing.Size(396, 218);
            this.dxContainer.TabIndex = 0;
            this.dxContainer.TabStop = false;
            // 
            // AddressForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(398, 250);
            this.Controls.Add(this.dxContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddressForm";
            this.Text = "{Title}";
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).EndInit();
            this.layoutContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ccCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebAddressLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebAddressLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebZipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.dxContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HtmlContentControl layoutContainer;
        private DevExpress.UITemplates.Collection.Editors.CountryChooser ccCountry;
        private DevExpress.UITemplates.Collection.Editors.EditBox ebAddressLine1;
        private DevExpress.UITemplates.Collection.Editors.EditBox ebAddressLine2;
        private DevExpress.UITemplates.Collection.Editors.EditBox ebZipCode;
        private DevExpress.UITemplates.Collection.Editors.EditBox ebCity;
        private DevExpress.UITemplates.Collection.Editors.EditBox ebState;
        private DevExpress.UITemplates.Collection.Editors.Button btnAccept;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private DevExpress.XtraEditors.DirectXFormContainerControl dxContainer;
    }
}
