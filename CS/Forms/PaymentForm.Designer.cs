namespace DevExpress.UITemplates.Collection.Forms {
    partial class PaymentForm {
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
            this.numberBox = new DevExpress.XtraEditors.TextEdit();
            this.nameBox = new DevExpress.XtraEditors.TextEdit();
            this.validThruMonthBox = new DevExpress.XtraEditors.TextEdit();
            this.validThruYearBox = new DevExpress.XtraEditors.TextEdit();
            this.cvcBox = new DevExpress.XtraEditors.TextEdit();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAccept = new DevExpress.UITemplates.Collection.Editors.Button();
            this.btnDecline = new DevExpress.UITemplates.Collection.Editors.Button();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.dxContainer = new DevExpress.XtraEditors.DirectXFormContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).BeginInit();
            this.layoutContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validThruMonthBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validThruYearBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cvcBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.dxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutContainer
            // 
            this.layoutContainer.AllowFocus = false;
            this.layoutContainer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.layoutContainer.Appearance.Options.UseBackColor = true;
            this.layoutContainer.Controls.Add(this.numberBox);
            this.layoutContainer.Controls.Add(this.nameBox);
            this.layoutContainer.Controls.Add(this.validThruMonthBox);
            this.layoutContainer.Controls.Add(this.validThruYearBox);
            this.layoutContainer.Controls.Add(this.cvcBox);
            this.layoutContainer.Controls.Add(this.btnAccept);
            this.layoutContainer.Controls.Add(this.btnDecline);
            this.layoutContainer.DataContext = this.viewModelBindingSource;
            this.layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutContainer.Location = new System.Drawing.Point(0, 0);
            this.layoutContainer.Name = "layoutContainer";
            this.layoutContainer.Size = new System.Drawing.Size(398, 408);
            this.layoutContainer.TabIndex = 0;
            this.layoutContainer.TabStop = false;
            // 
            // numberBox
            // 
            this.numberBox.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "CardNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numberBox.Location = new System.Drawing.Point(35, 109);
            this.numberBox.Name = "numberBox";
            this.numberBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption;
            this.numberBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(79)))), ((int)(((byte)(168)))));
            this.numberBox.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberBox.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.numberBox.Properties.Appearance.Options.UseBackColor = true;
            this.numberBox.Properties.Appearance.Options.UseFont = true;
            this.numberBox.Properties.Appearance.Options.UseForeColor = true;
            this.numberBox.Properties.Appearance.Options.UseTextOptions = true;
            this.numberBox.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.numberBox.Properties.AutoHeight = false;
            this.numberBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.numberBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numberBox.Properties.NullValuePrompt = "0000 0000 0000 0000";
            this.numberBox.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            this.numberBox.Properties.UseMaskAsDisplayFormat = true;
            this.numberBox.Size = new System.Drawing.Size(240, 28);
            this.numberBox.TabIndex = 1;
            // 
            // nameBox
            // 
            this.nameBox.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "CardHolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nameBox.Location = new System.Drawing.Point(35, 109);
            this.nameBox.Name = "nameBox";
            this.nameBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption;
            this.nameBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(79)))), ((int)(((byte)(168)))));
            this.nameBox.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.nameBox.Properties.Appearance.Options.UseBackColor = true;
            this.nameBox.Properties.Appearance.Options.UseFont = true;
            this.nameBox.Properties.Appearance.Options.UseForeColor = true;
            this.nameBox.Properties.Appearance.Options.UseTextOptions = true;
            this.nameBox.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.nameBox.Properties.AutoHeight = false;
            this.nameBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder;
            this.nameBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameBox.Properties.NullValuePrompt = "CARD HOLDER";
            this.nameBox.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            this.nameBox.Properties.UseMaskAsDisplayFormat = true;
            this.nameBox.Size = new System.Drawing.Size(240, 28);
            this.nameBox.TabIndex = 2;
            // 
            // validThruMonthBox
            // 
            this.validThruMonthBox.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "ValidThruMonth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.validThruMonthBox.Location = new System.Drawing.Point(35, 109);
            this.validThruMonthBox.Name = "validThruMonthBox";
            this.validThruMonthBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption;
            this.validThruMonthBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(79)))), ((int)(((byte)(168)))));
            this.validThruMonthBox.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validThruMonthBox.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.validThruMonthBox.Properties.Appearance.Options.UseBackColor = true;
            this.validThruMonthBox.Properties.Appearance.Options.UseFont = true;
            this.validThruMonthBox.Properties.Appearance.Options.UseForeColor = true;
            this.validThruMonthBox.Properties.Appearance.Options.UseTextOptions = true;
            this.validThruMonthBox.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.validThruMonthBox.Properties.AutoHeight = false;
            this.validThruMonthBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.validThruMonthBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder;
            this.validThruMonthBox.Properties.NullValuePrompt = "MM";
            this.validThruMonthBox.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            this.validThruMonthBox.Properties.UseMaskAsDisplayFormat = true;
            this.validThruMonthBox.Size = new System.Drawing.Size(48, 28);
            this.validThruMonthBox.TabIndex = 3;
            // 
            // validThruYearBox
            // 
            this.validThruYearBox.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "ValidThruYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.validThruYearBox.Location = new System.Drawing.Point(35, 109);
            this.validThruYearBox.Name = "validThruYearBox";
            this.validThruYearBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption;
            this.validThruYearBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(79)))), ((int)(((byte)(168)))));
            this.validThruYearBox.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validThruYearBox.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.validThruYearBox.Properties.Appearance.Options.UseBackColor = true;
            this.validThruYearBox.Properties.Appearance.Options.UseFont = true;
            this.validThruYearBox.Properties.Appearance.Options.UseForeColor = true;
            this.validThruYearBox.Properties.Appearance.Options.UseTextOptions = true;
            this.validThruYearBox.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.validThruYearBox.Properties.AutoHeight = false;
            this.validThruYearBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder;
            this.validThruYearBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.validThruYearBox.Properties.NullValuePrompt = "YY";
            this.validThruYearBox.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            this.validThruYearBox.Properties.UseMaskAsDisplayFormat = true;
            this.validThruYearBox.Size = new System.Drawing.Size(48, 28);
            this.validThruYearBox.TabIndex = 4;
            // 
            // cvcBox
            // 
            this.cvcBox.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "CVC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cvcBox.Location = new System.Drawing.Point(35, 109);
            this.cvcBox.Name = "cvcBox";
            this.cvcBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption;
            this.cvcBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(79)))), ((int)(((byte)(168)))));
            this.cvcBox.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cvcBox.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.cvcBox.Properties.Appearance.Options.UseBackColor = true;
            this.cvcBox.Properties.Appearance.Options.UseFont = true;
            this.cvcBox.Properties.Appearance.Options.UseForeColor = true;
            this.cvcBox.Properties.Appearance.Options.UseTextOptions = true;
            this.cvcBox.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.cvcBox.Properties.AutoHeight = false;
            this.cvcBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder;
            this.cvcBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cvcBox.Properties.NullValuePrompt = "000";
            this.cvcBox.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            this.cvcBox.Properties.UseMaskAsDisplayFormat = true;
            this.cvcBox.Size = new System.Drawing.Size(48, 28);
            this.cvcBox.TabIndex = 5;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(DevExpress.UITemplates.Collection.Forms.PaymentForm.ViewModel);
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(119, 299);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(160, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "{Accept}";
            // 
            // btnDecline
            // 
            this.btnDecline.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDecline.Location = new System.Drawing.Point(119, 299);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(160, 23);
            this.btnDecline.TabIndex = 7;
            this.btnDecline.Text = "{Decline}";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(DevExpress.UITemplates.Collection.Forms.PaymentForm.ViewModel);
            // 
            // dxContainer
            // 
            this.dxContainer.Controls.Add(this.layoutContainer);
            this.dxContainer.Location = new System.Drawing.Point(1, 31);
            this.dxContainer.Name = "dxContainer";
            this.dxContainer.Size = new System.Drawing.Size(398, 408);
            this.dxContainer.TabIndex = 0;
            this.dxContainer.TabStop = false;
            // 
            // PaymentForm
            // 
            this.AcceptButton = this.btnAccept;
            this.CancelButton = this.btnDecline;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(550, 410);
            this.Controls.Add(this.dxContainer);
            this.DoubleBuffered = true;
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.Text = "{Title}";
            ((System.ComponentModel.ISupportInitialize)(this.layoutContainer)).EndInit();
            this.layoutContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numberBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validThruMonthBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validThruYearBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cvcBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.dxContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HtmlContentControl layoutContainer;
        private DevExpress.XtraEditors.TextEdit numberBox;
        private DevExpress.XtraEditors.TextEdit nameBox;
        private DevExpress.XtraEditors.TextEdit validThruMonthBox;
        private DevExpress.XtraEditors.TextEdit validThruYearBox;
        private DevExpress.XtraEditors.TextEdit cvcBox;
        private DevExpress.UITemplates.Collection.Editors.Button btnAccept;
        private DevExpress.UITemplates.Collection.Editors.Button btnDecline;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private DevExpress.XtraEditors.DirectXFormContainerControl dxContainer;
    }
}
