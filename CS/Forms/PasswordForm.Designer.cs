namespace DevExpress.UITemplates.Collection.Forms {
    partial class PasswordForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
            this.layoutContainer = new DevExpress.XtraEditors.HtmlContentControl();
            this.tbPassword = new DevExpress.UITemplates.Collection.Editors.PasswordBox();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbConfirmPassword = new DevExpress.UITemplates.Collection.Editors.PasswordBox();
            this.btnChange = new DevExpress.UITemplates.Collection.Editors.Button();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.dxContainer = new DevExpress.XtraEditors.DirectXFormContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).BeginInit();
            this.layoutContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.dxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutContainer
            // 
            this.layoutContainer.AllowFocus = false;
            this.layoutContainer.Controls.Add(this.tbPassword);
            this.layoutContainer.Controls.Add(this.tbConfirmPassword);
            this.layoutContainer.Controls.Add(this.btnChange);
            this.layoutContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.layoutContainer.DataContext = this.viewModelBindingSource;
            this.layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutContainer.Location = new System.Drawing.Point(0, 0);
            this.layoutContainer.Name = "layoutContainer";
            this.layoutContainer.Size = new System.Drawing.Size(356, 248);
            this.layoutContainer.TabIndex = 0;
            this.layoutContainer.TabStop = false;
            // 
            // tbPassword
            // 
            this.tbPassword.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPassword.EditorSize = DevExpress.XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large;
            this.tbPassword.Location = new System.Drawing.Point(32, 61);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Placeholder = "New Password";
            this.tbPassword.ShowStrengthIndicator = true;
            this.tbPassword.Size = new System.Drawing.Size(292, 32);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.WarningTooltipAnchor = XtraEditors.Internal.HtmlTextBoxBase.EditToolTipAnchor.Editor;
            this.tbPassword.WarningToolTipLocation = DevExpress.Utils.ToolTipLocation.TopCenter;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(DevExpress.UITemplates.Collection.Forms.PasswordForm.ViewModel);
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "ConfirmedPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbConfirmPassword.EditorSize = DevExpress.XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large;
            this.tbConfirmPassword.Location = new System.Drawing.Point(32, 101);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Placeholder = "Confirm New Password";
            this.tbConfirmPassword.Size = new System.Drawing.Size(292, 30);
            this.tbConfirmPassword.ShowCapsLockWarningToolTip = false;
            this.tbConfirmPassword.ShowPasswordWeaknessWarningToolTip = false;
            this.tbConfirmPassword.TabIndex = 2;
            // 
            // btnChange
            // 
            this.btnChange.ButtonSize = DevExpress.UITemplates.Collection.Editors.ButtonBase.SizeType.Large;
            this.btnChange.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChange.Location = new System.Drawing.Point(184, 186);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(140, 30);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "{Action}";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(DevExpress.UITemplates.Collection.Forms.PasswordForm.ViewModel);
            // 
            // dxContainer
            // 
            this.dxContainer.Controls.Add(this.layoutContainer);
            this.dxContainer.Location = new System.Drawing.Point(1, 31);
            this.dxContainer.Name = "dxContainer";
            this.dxContainer.Size = new System.Drawing.Size(356, 248);
            this.dxContainer.TabIndex = 0;
            this.dxContainer.TabStop = false;
            // 
            // PasswordForm
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(358, 280);
            this.Controls.Add(this.dxContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.Text = "{Title}";
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).EndInit();
            this.layoutContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.dxContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HtmlContentControl layoutContainer;
        private DevExpress.UITemplates.Collection.Editors.PasswordBox tbPassword;
        private DevExpress.UITemplates.Collection.Editors.PasswordBox tbConfirmPassword;
        private DevExpress.UITemplates.Collection.Editors.Button btnChange;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private DevExpress.XtraEditors.DirectXFormContainerControl dxContainer;
    }
}
