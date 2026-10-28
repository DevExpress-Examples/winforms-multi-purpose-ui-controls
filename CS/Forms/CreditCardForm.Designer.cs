using DevExpress.UITemplates.Collection.Utilities;

namespace DevExpress.UITemplates.Collection.Forms {
    partial class CreditCardForm {
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
            this.nameBox = new DevExpress.UITemplates.Collection.Editors.EditBox();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cardBox = new DevExpress.UITemplates.Collection.Editors.PaymentCardBox();
            this.btnAdd = new DevExpress.UITemplates.Collection.Editors.Button();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.dxContainer = new DevExpress.XtraEditors.DirectXFormContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).BeginInit();
            this.layoutContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.dxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutContainer
            // 
            this.layoutContainer.AllowFocus = false;
            this.layoutContainer.Controls.Add(this.nameBox);
            this.layoutContainer.Controls.Add(this.cardBox);
            this.layoutContainer.Controls.Add(this.btnAdd);
            this.layoutContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.layoutContainer.DataContext = this.viewModelBindingSource;
            this.layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutContainer.Location = new System.Drawing.Point(0, 0);
            this.layoutContainer.Name = "layoutContainer";
            this.layoutContainer.Size = new System.Drawing.Size(378, 404);
            this.layoutContainer.TabIndex = 0;
            this.layoutContainer.TabStop = false;
            // 
            // nameBox
            // 
            this.nameBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameBox.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "CardHolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nameBox.EditorSize = DevExpress.XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large;
            this.nameBox.Location = new System.Drawing.Point(32, 224);
            this.nameBox.Name = "nameBox";
            this.nameBox.Placeholder = "CARD HOLDER";
            this.nameBox.Size = new System.Drawing.Size(314, 28);
            this.nameBox.TabIndex = 0;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(DevExpress.UITemplates.Collection.Forms.CreditCardForm.ViewModel);
            // 
            // cardBox
            // 
            this.cardBox.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "Card", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cardBox.EditorSize = DevExpress.XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large;
            this.cardBox.Location = new System.Drawing.Point(32, 260);
            this.cardBox.Name = "cardBox";
            this.cardBox.Placeholder = "";
            this.cardBox.Size = new System.Drawing.Size(314, 30);
            this.cardBox.TabIndex = 1;
            this.cardBox.WarningTooltipAnchor = XtraEditors.Internal.HtmlTextBoxBase.EditToolTipAnchor.Editor;
            this.cardBox.WarningToolTipLocation = DevExpress.Utils.ToolTipLocation.BottomCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonSize = DevExpress.UITemplates.Collection.Editors.ButtonBase.SizeType.Large;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(206, 342);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "{Action}";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(DevExpress.UITemplates.Collection.Forms.CreditCardForm.ViewModel);
            // 
            // dxContainer
            // 
            this.dxContainer.Controls.Add(this.layoutContainer);
            this.dxContainer.Location = new System.Drawing.Point(1, 31);
            this.dxContainer.Name = "dxContainer";
            this.dxContainer.Size = new System.Drawing.Size(378, 404);
            this.dxContainer.TabIndex = 0;
            this.dxContainer.TabStop = false;
            // 
            // CreditCardForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(380, 436);
            this.Controls.Add(this.dxContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreditCardForm";
            this.Text = "{Title}";
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).EndInit();
            this.layoutContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.dxContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HtmlContentControl layoutContainer;
        private DevExpress.UITemplates.Collection.Editors.EditBox nameBox;
        private DevExpress.UITemplates.Collection.Editors.PaymentCardBox cardBox;
        private DevExpress.UITemplates.Collection.Editors.Button btnAdd;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private DevExpress.XtraEditors.DirectXFormContainerControl dxContainer;
    }
}
