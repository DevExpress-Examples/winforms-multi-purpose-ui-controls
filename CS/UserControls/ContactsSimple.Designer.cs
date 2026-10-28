namespace DevExpress.UITemplates.Collection.UserControls {
    partial class ContactsSimple {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.Drawing.StubGlyphOptions stubGlyphOptions1 = new DevExpress.Utils.Drawing.StubGlyphOptions();
            this.dataLayout = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.contactsGrid = new DevExpress.XtraGrid.GridControl();
            this.contactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMobilePhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tePhone = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.icbPrefix = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.icbStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colPhoto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pePhoto = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.actionsBar = new DevExpress.XtraBars.Bar();
            this.beStatusFilter = new DevExpress.XtraBars.BarEditItem();
            this.bicbStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReload = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.actionImages = new DevExpress.Utils.SvgImageCollection(this.components);
            this.rootGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForMasterGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.teMail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).BeginInit();
            this.dataLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbPrefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pePhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bicbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMasterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayout
            // 
            this.dataLayout.AllowCustomization = false;
            this.dataLayout.AllowGeneratingCollectionProperties = DevExpress.Utils.DefaultBoolean.True;
            this.dataLayout.AllowGeneratingNestedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.dataLayout.Controls.Add(this.contactsGrid);
            this.dataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayout.Location = new System.Drawing.Point(0, 24);
            this.dataLayout.Name = "dataLayout";
            this.dataLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 155, 650, 400);
            this.dataLayout.OptionsView.UseParentAutoScaleFactor = true;
            this.dataLayout.Root = this.rootGroup;
            this.dataLayout.Size = new System.Drawing.Size(800, 396);
            this.dataLayout.TabIndex = 0;
            // 
            // contactsGrid
            // 
            this.contactsGrid.DataSource = this.contactsBindingSource;
            this.contactsGrid.Location = new System.Drawing.Point(10, 10);
            this.contactsGrid.MainView = this.contactsGridView;
            this.contactsGrid.MenuManager = this.barManager;
            this.contactsGrid.Name = "contactsGrid";
            this.contactsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.icbPrefix,
            this.icbStatus,
            this.tePhone,
            this.pePhoto});
            this.contactsGrid.Size = new System.Drawing.Size(780, 376);
            this.contactsGrid.TabIndex = 24;
            this.contactsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.contactsGridView});
            // 
            // contactsBindingSource
            // 
            this.contactsBindingSource.DataSource = typeof(DevExpress.UITemplates.Collection.Models.Employee);
            // 
            // contactsGridView
            // 
            this.contactsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colFullName,
            this.colEmail,
            this.colDepartment,
            this.colMobilePhone,
            this.colPrefix,
            this.colStatus,
            this.colPhoto,
            this.colFirstName,
            this.colLastName});
            this.contactsGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.contactsGridView.GridControl = this.contactsGrid;
            this.contactsGridView.GroupCount = 1;
            this.contactsGridView.GroupFormat = "[#image]{1} {2}";
            this.contactsGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", null, "")});
            this.contactsGridView.LevelIndent = 0;
            this.contactsGridView.Name = "contactsGridView";
            this.contactsGridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.contactsGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.contactsGridView.OptionsEditForm.PopupEditFormWidth = 800;
            this.contactsGridView.OptionsEditForm.EditFormColumnCount = 4;
            this.contactsGridView.OptionsFind.AlwaysVisible = true;
            this.contactsGridView.OptionsFind.FindNullPrompt = "Search (Ctrl + F)";
            this.contactsGridView.OptionsFind.ShowClearButton = false;
            this.contactsGridView.OptionsFind.ShowFindButton = false;
            this.contactsGridView.OptionsSelection.MultiSelect = true;
            this.contactsGridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.contactsGridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.contactsGridView.OptionsView.AllowHtmlDrawHeaders = true;
            this.contactsGridView.OptionsView.ShowIndicator = false;
            this.contactsGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.contactsGridView.PreviewIndent = 0;
            this.contactsGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartment, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.contactsGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.OnRowCellClick);
            this.contactsGridView.EditFormShowing += new DevExpress.XtraGrid.Views.Grid.EditFormShowingEventHandler(this.OnEditFormShowing);
            this.contactsGridView.ShowingPopupEditForm += new DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventHandler(this.OnShowingPopupEditForm);
            this.contactsGridView.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.OnCustomRowCellEditForEditing);
            this.contactsGridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.OnFocusedRowObjectChanged);
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsEditForm.ColumnSpan = 2;
            this.colTitle.OptionsEditForm.UseEditorColRowSpan = false;
            this.colTitle.OptionsEditForm.VisibleIndex = 10;
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 2;
            this.colTitle.Width = 144;
            // 
            // colFullName
            // 
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.ReadOnly = true;
            this.colFullName.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 1;
            this.colFullName.Width = 144;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsEditForm.VisibleIndex = 11;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 5;
            this.colEmail.Width = 151;
            // 
            // colDepartment
            // 
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.OptionsEditForm.VisibleIndex = 12;
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 3;
            // 
            // colMobilePhone
            // 
            this.colMobilePhone.ColumnEdit = this.tePhone;
            this.colMobilePhone.FieldName = "MobilePhone";
            this.colMobilePhone.Name = "colMobilePhone";
            this.colMobilePhone.OptionsEditForm.VisibleIndex = 13;
            this.colMobilePhone.Visible = true;
            this.colMobilePhone.VisibleIndex = 4;
            this.colMobilePhone.Width = 144;
            // 
            // tePhone
            // 
            this.tePhone.AutoHeight = false;
            this.tePhone.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.tePhone.MaskSettings.Set("mask", "(999) 000-0000");
            this.tePhone.Name = "tePhone";
            this.tePhone.UseMaskAsDisplayFormat = true;
            // 
            // colPrefix
            // 
            this.colPrefix.ColumnEdit = this.icbPrefix;
            this.colPrefix.FieldName = "Prefix";
            this.colPrefix.Name = "colPrefix";
            this.colPrefix.OptionsEditForm.VisibleIndex = 2;
            this.colPrefix.Visible = true;
            this.colPrefix.VisibleIndex = 0;
            this.colPrefix.Width = 51;
            // 
            // icbPrefix
            // 
            this.icbPrefix.AutoHeight = false;
            this.icbPrefix.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbPrefix.Name = "icbPrefix";
            // 
            // colStatus
            // 
            stubGlyphOptions1.Type = DevExpress.Utils.Drawing.GlyphBackgroundType.Ellipse;
            this.behaviorManager1.SetBehaviors(this.colStatus, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.Behaviors.Common.StubGlyphBehavior.Create(typeof(DevExpress.XtraGrid.Views.Grid.BehaviorSource.StubGlyphBehaviorSourceForGridColumn), stubGlyphOptions1, new System.Drawing.Size(16, 16))))});
            this.colStatus.ColumnEdit = this.icbStatus;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsEditForm.VisibleIndex = 4;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            this.colStatus.Width = 144;
            // 
            // icbStatus
            // 
            this.icbStatus.AutoHeight = false;
            this.icbStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbStatus.Name = "icbStatus";
            // 
            // colPhoto
            // 
            this.colPhoto.ColumnEdit = this.pePhoto;
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.OptionsEditForm.CaptionLocation = DevExpress.XtraGrid.EditForm.EditFormColumnCaptionLocation.None;
            this.colPhoto.OptionsEditForm.RowSpan = 3;
            this.colPhoto.OptionsEditForm.UseEditorColRowSpan = false;
            this.colPhoto.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colPhoto.Width = 60;
            // 
            // pePhoto
            // 
            this.pePhoto.Name = "pePhoto";
            this.pePhoto.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // colFirstName
            // 
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colFirstName.OptionsEditForm.VisibleIndex = 2;
            // 
            // colLastName
            // 
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colLastName.OptionsEditForm.VisibleIndex = 3;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.actionsBar});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.actionImages;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.beStatusFilter,
            this.bbiNew,
            this.bbiReload,
            this.bbiDelete,
            this.bbiPrint});
            this.barManager.MainMenu = this.actionsBar;
            this.barManager.MaxItemId = 7;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bicbStatus});
            // 
            // actionsBar
            // 
            this.actionsBar.BarName = "Actions";
            this.actionsBar.DockCol = 0;
            this.actionsBar.DockRow = 0;
            this.actionsBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.actionsBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beStatusFilter, "", false, true, true, 91),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiReload),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)});
            this.actionsBar.OptionsBar.AllowQuickCustomization = false;
            this.actionsBar.OptionsBar.DisableCustomization = true;
            this.actionsBar.OptionsBar.DrawDragBorder = false;
            this.actionsBar.OptionsBar.MultiLine = true;
            this.actionsBar.OptionsBar.UseWholeRow = true;
            this.actionsBar.Text = "Actions";
            // 
            // beStatusFilter
            // 
            this.beStatusFilter.Caption = "Filter by Status:";
            this.beStatusFilter.Edit = this.bicbStatus;
            this.beStatusFilter.Id = 1;
            this.beStatusFilter.Name = "beStatusFilter";
            this.beStatusFilter.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            this.beStatusFilter.EditValueChanged += new System.EventHandler(this.OnStatusFilterChanged);
            // 
            // bicbStatus
            // 
            this.bicbStatus.AutoHeight = false;
            this.bicbStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bicbStatus.Name = "bicbStatus";
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "Add New";
            this.bbiNew.Id = 2;
            this.bbiNew.ImageOptions.ImageIndex = 0;
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnNew);
            // 
            // bbiReload
            // 
            this.bbiReload.Caption = "Reload Data";
            this.bbiReload.Id = 3;
            this.bbiReload.ImageOptions.ImageIndex = 1;
            this.bbiReload.Name = "bbiReload";
            this.bbiReload.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnReload);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 4;
            this.bbiDelete.ImageOptions.ImageIndex = 2;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnDelete);
            // 
            // bbiPrint
            // 
            this.bbiPrint.Caption = "Print";
            this.bbiPrint.Id = 5;
            this.bbiPrint.ImageOptions.ImageIndex = 3;
            this.bbiPrint.Name = "bbiPrint";
            this.bbiPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnPrint);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 420);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 396);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 396);
            // 
            // actionImages
            // 
            this.actionImages.Add("addnew", "image://svgimages/outlook inspired/newemployee.svg");
            this.actionImages.Add("refresh", "image://svgimages/outlook inspired/resetview.svg");
            this.actionImages.Add("delete", "image://svgimages/outlook inspired/delete.svg");
            this.actionImages.Add("print", "image://svgimages/outlook inspired/print.svg");
            // 
            // rootGroup
            // 
            this.rootGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.rootGroup.GroupBordersVisible = false;
            this.rootGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMasterGrid});
            this.rootGroup.Name = "rootGroup";
            this.rootGroup.Size = new System.Drawing.Size(800, 396);
            this.rootGroup.TextVisible = false;
            // 
            // ItemForMasterGrid
            // 
            this.ItemForMasterGrid.Control = this.contactsGrid;
            this.ItemForMasterGrid.Location = new System.Drawing.Point(0, 0);
            this.ItemForMasterGrid.Name = "ItemForMasterGrid";
            this.ItemForMasterGrid.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.ItemForMasterGrid.Size = new System.Drawing.Size(780, 376);
            this.ItemForMasterGrid.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForMasterGrid.TextVisible = false;
            // 
            // teMail
            // 
            this.teMail.AutoHeight = false;
            this.teMail.Name = "teMail";
            // 
            // ContactsSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.dataLayout);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ContactsSimple";
            this.Size = new System.Drawing.Size(800, 420);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).EndInit();
            this.dataLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contactsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbPrefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pePhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bicbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMasterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayout;
        private DevExpress.XtraLayout.LayoutControlGroup rootGroup;
        private Utils.SvgImageCollection actionImages;
        private XtraBars.BarManager barManager;
        private XtraBars.BarButtonItem bbiReload;
        private XtraBars.Bar actionsBar;
        private XtraBars.BarDockControl barDockControlTop;
        private XtraBars.BarDockControl barDockControlBottom;
        private XtraBars.BarDockControl barDockControlLeft;
        private XtraBars.BarDockControl barDockControlRight;
        private XtraGrid.GridControl contactsGrid;
        private XtraGrid.Views.Grid.GridView contactsGridView;
        private System.Windows.Forms.BindingSource contactsBindingSource;
        private XtraGrid.Columns.GridColumn colTitle;
        private XtraGrid.Columns.GridColumn colFullName;
        private XtraGrid.Columns.GridColumn colEmail;
        private XtraEditors.Repository.RepositoryItemTextEdit teMail;
        private XtraBars.BarButtonItem bbiNew;
        private XtraBars.BarButtonItem bbiDelete;
        private XtraLayout.LayoutControlItem ItemForMasterGrid;
        private XtraGrid.Columns.GridColumn colDepartment;
        private XtraGrid.Columns.GridColumn colMobilePhone;
        private XtraGrid.Columns.GridColumn colPrefix;
        private XtraGrid.Columns.GridColumn colStatus;
        private XtraGrid.Columns.GridColumn colPhoto;
        private XtraEditors.Repository.RepositoryItemImageComboBox icbPrefix;
        private XtraEditors.Repository.RepositoryItemImageComboBox icbStatus;
        private XtraBars.BarEditItem beStatusFilter;
        private XtraEditors.Repository.RepositoryItemImageComboBox bicbStatus;
        private XtraBars.BarButtonItem bbiPrint;
        private Utils.Behaviors.BehaviorManager behaviorManager1;
        private XtraGrid.Columns.GridColumn colFirstName;
        private XtraGrid.Columns.GridColumn colLastName;
        private XtraEditors.Repository.RepositoryItemTextEdit tePhone;
        private XtraEditors.Repository.RepositoryItemPictureEdit pePhoto;
    }
}

