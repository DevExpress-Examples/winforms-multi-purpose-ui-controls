namespace UITemplatesExample.Views {
    partial class RadioButtonGroupView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadioButtonGroupView));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            radioButtonGroup1 = new DevExpress.UITemplates.Collection.Editors.RadioButtonGroup();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(radioButtonGroup1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(2857, 49, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(659, 478);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // radioButtonGroup1
            // 
            radioButtonGroup1.HtmlTemplate.Styles = resources.GetString("radioButtonGroup1.HtmlTemplate.Styles");
            radioButtonGroup1.Items.AddRange(new DevExpress.UITemplates.Collection.Editors.ButtonGroupItem[] { new DevExpress.UITemplates.Collection.Editors.ButtonGroupItem(1, "Option A"), new DevExpress.UITemplates.Collection.Editors.ButtonGroupItem(2, "Option B"), new DevExpress.UITemplates.Collection.Editors.ButtonGroupItem(3, "Option C") });
            radioButtonGroup1.ItemSize = DevExpress.UITemplates.Collection.Components.ItemsSelector.Size.Large;
            radioButtonGroup1.Location = new Point(174, 224);
            radioButtonGroup1.Name = "radioButtonGroup1";
            radioButtonGroup1.Size = new Size(310, 30);
            radioButtonGroup1.StyleController = layoutControl1;
            radioButtonGroup1.TabIndex = 4;
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
            layoutControlItem1.Control = radioButtonGroup1;
            layoutControlItem1.Location = new Point(158, 113);
            layoutControlItem1.MaxSize = new Size(316, 36);
            layoutControlItem1.MinSize = new Size(316, 36);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem1.Size = new Size(316, 226);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // RadioButtonGroupView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "RadioButtonGroupView";
            Size = new Size(659, 478);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.UITemplates.Collection.Editors.RadioButtonGroup radioButtonGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}