namespace UITemplatesExample.Views {
    partial class PasswordBoxView {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        ///  Required method for Designer support - do not modify 
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            passwordBox1 = new DevExpress.UITemplates.Collection.Editors.PasswordBox();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)passwordBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(passwordBox1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(2857, 49, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(659, 478);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // passwordBox1
            // 
            passwordBox1.FooterLabel = "A password must be at least 8 characters.";
            passwordBox1.HeaderLabel = "Password";
            passwordBox1.Location = new Point(174, 214);
            passwordBox1.Name = "passwordBox1";
            passwordBox1.Placeholder = "e.g., ••••••••";
            passwordBox1.ShowStrengthIndicator = true;
            passwordBox1.Size = new Size(310, 49);
            passwordBox1.StyleController = layoutControl1;
            passwordBox1.TabIndex = 4;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 25D;
            columnDefinition2.SizeType = SizeType.Percent;
            columnDefinition2.Width = 50D;
            columnDefinition3.SizeType = SizeType.Percent;
            columnDefinition3.Width = 25D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2, columnDefinition3 });
            rowDefinition1.Height = 25D;
            rowDefinition1.SizeType = SizeType.Percent;
            rowDefinition2.Height = 50D;
            rowDefinition2.SizeType = SizeType.Percent;
            rowDefinition3.Height = 25D;
            rowDefinition3.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3 });
            Root.Size = new Size(659, 478);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem1.Control = passwordBox1;
            layoutControlItem1.Location = new Point(158, 113);
            layoutControlItem1.MaxSize = new Size(316, 55);
            layoutControlItem1.MinSize = new Size(316, 55);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem1.Size = new Size(316, 226);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // PasswordBoxView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "PasswordBoxView";
            Size = new Size(659, 478);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)passwordBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.UITemplates.Collection.Editors.PasswordBox passwordBox1;
    }
}