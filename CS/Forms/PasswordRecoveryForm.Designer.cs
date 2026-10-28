namespace DevExpress.UITemplates.Collection.Forms {
    partial class PasswordRecoveryForm {
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
            this.tbEmail = new DevExpress.UITemplates.Collection.Editors.EmailBox();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRecover = new DevExpress.UITemplates.Collection.Editors.Button();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.dxContainer = new DevExpress.XtraEditors.DirectXFormContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).BeginInit();
            this.layoutContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.dxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutContainer
            // 
            this.layoutContainer.AllowFocus = false;
            this.layoutContainer.Controls.Add(this.tbEmail);
            this.layoutContainer.Controls.Add(this.btnRecover);
            this.layoutContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.layoutContainer.DataContext = this.viewModelBindingSource;
            this.layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutContainer.Location = new System.Drawing.Point(0, 0);
            this.layoutContainer.Name = "layoutContainer";
            this.layoutContainer.Size = new System.Drawing.Size(448, 188);
            this.layoutContainer.TabIndex = 0;
            this.layoutContainer.TabStop = false;
            // 
            // tbEmail
            // 
            this.tbEmail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "Email", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbEmail.EditorSize = DevExpress.XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large;
            this.tbEmail.Location = new System.Drawing.Point(32, 61);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Placeholder = "Email";
            this.tbEmail.Size = new System.Drawing.Size(384, 30);
            this.tbEmail.TabIndex = 0;
            this.tbEmail.WarningTooltipAnchor = XtraEditors.Internal.HtmlTextBoxBase.EditToolTipAnchor.Editor;
            this.tbEmail.WarningToolTipLocation = DevExpress.Utils.ToolTipLocation.TopCenter;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(DevExpress.UITemplates.Collection.Forms.PasswordRecoveryForm.ViewModel);
            // 
            // btnRecover
            // 
            this.btnRecover.ButtonSize = DevExpress.UITemplates.Collection.Editors.ButtonBase.SizeType.Large;
            this.btnRecover.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRecover.Location = new System.Drawing.Point(276, 126);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(140, 30);
            this.btnRecover.TabIndex = 1;
            this.btnRecover.Text = "{Action}";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(DevExpress.UITemplates.Collection.Forms.PasswordRecoveryForm.ViewModel);
            // 
            // dxContainer
            // 
            this.dxContainer.Controls.Add(this.layoutContainer);
            this.dxContainer.Location = new System.Drawing.Point(1, 31);
            this.dxContainer.Name = "dxContainer";
            this.dxContainer.Size = new System.Drawing.Size(448, 188);
            this.dxContainer.TabIndex = 0;
            this.dxContainer.TabStop = false;
            // 
            // PasswordRecoveryForm
            // 
            this.AcceptButton = this.btnRecover;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(450, 220);
            this.Controls.Add(this.dxContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordRecoveryForm";
            this.Text = "{Title}";
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).EndInit();
            this.layoutContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.dxContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HtmlContentControl layoutContainer;
        private DevExpress.UITemplates.Collection.Editors.EmailBox tbEmail;
        private DevExpress.UITemplates.Collection.Editors.Button btnRecover;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private DevExpress.XtraEditors.DirectXFormContainerControl dxContainer;
    }
}
