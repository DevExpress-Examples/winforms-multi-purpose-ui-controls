Namespace DevExpress.UITemplates.Collection.UserControls
    Partial Class ContactsSimple
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New ComponentModel.Container()
            Dim stubGlyphOptions1 As Utils.Drawing.StubGlyphOptions = New Utils.Drawing.StubGlyphOptions()
            dataLayout = New XtraDataLayout.DataLayoutControl()
            contactsGrid = New XtraGrid.GridControl()
            contactsBindingSource = New System.Windows.Forms.BindingSource(components)
            contactsGridView = New XtraGrid.Views.Grid.GridView()
            colTitle = New XtraGrid.Columns.GridColumn()
            colFullName = New XtraGrid.Columns.GridColumn()
            colEmail = New XtraGrid.Columns.GridColumn()
            colDepartment = New XtraGrid.Columns.GridColumn()
            colMobilePhone = New XtraGrid.Columns.GridColumn()
            tePhone = New XtraEditors.Repository.RepositoryItemTextEdit()
            colPrefix = New XtraGrid.Columns.GridColumn()
            icbPrefix = New XtraEditors.Repository.RepositoryItemImageComboBox()
            colStatus = New XtraGrid.Columns.GridColumn()
            icbStatus = New XtraEditors.Repository.RepositoryItemImageComboBox()
            colPhoto = New XtraGrid.Columns.GridColumn()
            pePhoto = New XtraEditors.Repository.RepositoryItemPictureEdit()
            colFirstName = New XtraGrid.Columns.GridColumn()
            colLastName = New XtraGrid.Columns.GridColumn()
            barManager = New XtraBars.BarManager(components)
            actionsBar = New XtraBars.Bar()
            beStatusFilter = New XtraBars.BarEditItem()
            bicbStatus = New XtraEditors.Repository.RepositoryItemImageComboBox()
            bbiNew = New XtraBars.BarButtonItem()
            bbiReload = New XtraBars.BarButtonItem()
            bbiDelete = New XtraBars.BarButtonItem()
            bbiPrint = New XtraBars.BarButtonItem()
            barDockControlTop = New XtraBars.BarDockControl()
            barDockControlBottom = New XtraBars.BarDockControl()
            barDockControlLeft = New XtraBars.BarDockControl()
            barDockControlRight = New XtraBars.BarDockControl()
            actionImages = New Utils.SvgImageCollection(components)
            rootGroup = New XtraLayout.LayoutControlGroup()
            ItemForMasterGrid = New XtraLayout.LayoutControlItem()
            teMail = New XtraEditors.Repository.RepositoryItemTextEdit()
            behaviorManager1 = New Utils.Behaviors.BehaviorManager(components)
            CType(dataLayout, ComponentModel.ISupportInitialize).BeginInit()
            dataLayout.SuspendLayout()
            CType(contactsGrid, ComponentModel.ISupportInitialize).BeginInit()
            CType(contactsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
            CType(contactsGridView, ComponentModel.ISupportInitialize).BeginInit()
            CType(tePhone, ComponentModel.ISupportInitialize).BeginInit()
            CType(icbPrefix, ComponentModel.ISupportInitialize).BeginInit()
            CType(icbStatus, ComponentModel.ISupportInitialize).BeginInit()
            CType(pePhoto, ComponentModel.ISupportInitialize).BeginInit()
            CType(barManager, ComponentModel.ISupportInitialize).BeginInit()
            CType(bicbStatus, ComponentModel.ISupportInitialize).BeginInit()
            CType(actionImages, ComponentModel.ISupportInitialize).BeginInit()
            CType(rootGroup, ComponentModel.ISupportInitialize).BeginInit()
            CType(ItemForMasterGrid, ComponentModel.ISupportInitialize).BeginInit()
            CType(teMail, ComponentModel.ISupportInitialize).BeginInit()
            CType(behaviorManager1, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' dataLayout
            ' 
            dataLayout.AllowCustomization = False
            dataLayout.AllowGeneratingCollectionProperties = Utils.DefaultBoolean.True
            dataLayout.AllowGeneratingNestedGroups = Utils.DefaultBoolean.True
            dataLayout.Controls.Add(contactsGrid)
            dataLayout.Dock = System.Windows.Forms.DockStyle.Fill
            dataLayout.Location = New System.Drawing.Point(0, 24)
            dataLayout.Name = "dataLayout"
            dataLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1270, 155, 650, 400)
            dataLayout.OptionsView.UseParentAutoScaleFactor = True
            dataLayout.Root = rootGroup
            dataLayout.Size = New System.Drawing.Size(800, 396)
            dataLayout.TabIndex = 0
            ' 
            ' contactsGrid
            ' 
            contactsGrid.DataSource = contactsBindingSource
            contactsGrid.Location = New System.Drawing.Point(10, 10)
            contactsGrid.MainView = contactsGridView
            contactsGrid.MenuManager = barManager
            contactsGrid.Name = "contactsGrid"
            contactsGrid.RepositoryItems.AddRange(New XtraEditors.Repository.RepositoryItem() {icbPrefix, icbStatus, tePhone, pePhoto})
            contactsGrid.Size = New System.Drawing.Size(780, 376)
            contactsGrid.TabIndex = 24
            contactsGrid.ViewCollection.AddRange(New XtraGrid.Views.Base.BaseView() {contactsGridView})
            ' 
            ' contactsBindingSource
            ' 
            contactsBindingSource.DataSource = GetType(Collection.Models.Employee)
            ' 
            ' contactsGridView
            ' 
            contactsGridView.Columns.AddRange(New XtraGrid.Columns.GridColumn() {colTitle, colFullName, colEmail, colDepartment, colMobilePhone, colPrefix, colStatus, colPhoto, colFirstName, colLastName})
            contactsGridView.FocusRectStyle = XtraGrid.Views.Grid.DrawFocusRectStyle.None
            contactsGridView.GridControl = contactsGrid
            contactsGridView.GroupCount = 1
            contactsGridView.GroupFormat = "[#image]{1} {2}"
            contactsGridView.GroupSummary.AddRange(New XtraGrid.GridSummaryItem() {New XtraGrid.GridGroupSummaryItem(Data.SummaryItemType.Count, "Id", Nothing, "")})
            contactsGridView.LevelIndent = 0
            contactsGridView.Name = "contactsGridView"
            contactsGridView.OptionsBehavior.AutoExpandAllGroups = True
            contactsGridView.OptionsBehavior.EditingMode = XtraGrid.Views.Grid.GridEditingMode.EditForm
            contactsGridView.OptionsEditForm.PopupEditFormWidth = 800
            contactsGridView.OptionsEditForm.EditFormColumnCount = 4
            contactsGridView.OptionsFind.AlwaysVisible = True
            contactsGridView.OptionsFind.FindNullPrompt = "Search (Ctrl + F)"
            contactsGridView.OptionsFind.ShowClearButton = False
            contactsGridView.OptionsFind.ShowFindButton = False
            contactsGridView.OptionsSelection.MultiSelect = True
            contactsGridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = Utils.DefaultBoolean.True
            contactsGridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = Utils.DefaultBoolean.False
            contactsGridView.OptionsView.AllowHtmlDrawHeaders = True
            contactsGridView.OptionsView.ShowIndicator = False
            contactsGridView.OptionsView.ShowVerticalLines = Utils.DefaultBoolean.False
            contactsGridView.PreviewIndent = 0
            contactsGridView.SortInfo.AddRange(New XtraGrid.Columns.GridColumnSortInfo() {New XtraGrid.Columns.GridColumnSortInfo(colDepartment, Data.ColumnSortOrder.Ascending)})
            AddHandler contactsGridView.RowCellClick, New XtraGrid.Views.Grid.RowCellClickEventHandler(AddressOf OnRowCellClick)
            AddHandler contactsGridView.EditFormShowing, New XtraGrid.Views.Grid.EditFormShowingEventHandler(AddressOf OnEditFormShowing)
            AddHandler contactsGridView.ShowingPopupEditForm, New XtraGrid.Views.Grid.ShowingPopupEditFormEventHandler(AddressOf OnShowingPopupEditForm)
            AddHandler contactsGridView.CustomRowCellEditForEditing, New XtraGrid.Views.Grid.CustomRowCellEditEventHandler(AddressOf OnCustomRowCellEditForEditing)
            AddHandler contactsGridView.FocusedRowObjectChanged, New XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(AddressOf OnFocusedRowObjectChanged)
            ' 
            ' colTitle
            ' 
            colTitle.FieldName = "Title"
            colTitle.Name = "colTitle"
            colTitle.OptionsEditForm.ColumnSpan = 2
            colTitle.OptionsEditForm.UseEditorColRowSpan = False
            colTitle.OptionsEditForm.VisibleIndex = 10
            colTitle.Visible = True
            colTitle.VisibleIndex = 2
            colTitle.Width = 144
            ' 
            ' colFullName
            ' 
            colFullName.FieldName = "FullName"
            colFullName.Name = "colFullName"
            colFullName.OptionsColumn.ReadOnly = True
            colFullName.OptionsEditForm.Visible = Utils.DefaultBoolean.False
            colFullName.Visible = True
            colFullName.VisibleIndex = 1
            colFullName.Width = 144
            ' 
            ' colEmail
            ' 
            colEmail.FieldName = "Email"
            colEmail.Name = "colEmail"
            colEmail.OptionsEditForm.VisibleIndex = 11
            colEmail.Visible = True
            colEmail.VisibleIndex = 5
            colEmail.Width = 151
            ' 
            ' colDepartment
            ' 
            colDepartment.FieldName = "Department"
            colDepartment.Name = "colDepartment"
            colDepartment.OptionsEditForm.VisibleIndex = 12
            colDepartment.Visible = True
            colDepartment.VisibleIndex = 3
            ' 
            ' colMobilePhone
            ' 
            colMobilePhone.ColumnEdit = tePhone
            colMobilePhone.FieldName = "MobilePhone"
            colMobilePhone.Name = "colMobilePhone"
            colMobilePhone.OptionsEditForm.VisibleIndex = 13
            colMobilePhone.Visible = True
            colMobilePhone.VisibleIndex = 4
            colMobilePhone.Width = 144
            ' 
            ' tePhone
            ' 
            tePhone.AutoHeight = False
            tePhone.MaskSettings.Set("MaskManagerType", GetType(Data.Mask.SimpleMaskManager))
            tePhone.MaskSettings.Set("mask", "(999) 000-0000")
            tePhone.Name = "tePhone"
            tePhone.UseMaskAsDisplayFormat = True
            ' 
            ' colPrefix
            ' 
            colPrefix.ColumnEdit = icbPrefix
            colPrefix.FieldName = "Prefix"
            colPrefix.Name = "colPrefix"
            colPrefix.OptionsEditForm.VisibleIndex = 2
            colPrefix.Visible = True
            colPrefix.VisibleIndex = 0
            colPrefix.Width = 51
            ' 
            ' icbPrefix
            ' 
            icbPrefix.AutoHeight = False
            icbPrefix.Buttons.AddRange(New XtraEditors.Controls.EditorButton() {New XtraEditors.Controls.EditorButton(XtraEditors.Controls.ButtonPredefines.Combo)})
            icbPrefix.Name = "icbPrefix"
            ' 
            ' colStatus
            ' 
            stubGlyphOptions1.Type = Utils.Drawing.GlyphBackgroundType.Ellipse
            behaviorManager1.SetBehaviors(colStatus, New Utils.Behaviors.Behavior() {CType((Utils.Behaviors.Common.StubGlyphBehavior.Create(GetType(XtraGrid.Views.Grid.BehaviorSource.StubGlyphBehaviorSourceForGridColumn), stubGlyphOptions1, New System.Drawing.Size(16, 16))), Utils.Behaviors.Behavior)})
            colStatus.ColumnEdit = icbStatus
            colStatus.FieldName = "Status"
            colStatus.Name = "colStatus"
            colStatus.OptionsEditForm.VisibleIndex = 4
            colStatus.Visible = True
            colStatus.VisibleIndex = 3
            colStatus.Width = 144
            ' 
            ' icbStatus
            ' 
            icbStatus.AutoHeight = False
            icbStatus.Buttons.AddRange(New XtraEditors.Controls.EditorButton() {New XtraEditors.Controls.EditorButton(XtraEditors.Controls.ButtonPredefines.Combo)})
            icbStatus.Name = "icbStatus"
            ' 
            ' colPhoto
            ' 
            colPhoto.ColumnEdit = pePhoto
            colPhoto.FieldName = "Photo"
            colPhoto.Name = "colPhoto"
            colPhoto.OptionsEditForm.CaptionLocation = XtraGrid.EditForm.EditFormColumnCaptionLocation.None
            colPhoto.OptionsEditForm.RowSpan = 3
            colPhoto.OptionsEditForm.UseEditorColRowSpan = False
            colPhoto.OptionsEditForm.Visible = Utils.DefaultBoolean.True
            colPhoto.Width = 60
            ' 
            ' pePhoto
            ' 
            pePhoto.Name = "pePhoto"
            pePhoto.SizeMode = XtraEditors.Controls.PictureSizeMode.Zoom
            ' 
            ' colFirstName
            ' 
            colFirstName.FieldName = "FirstName"
            colFirstName.Name = "colFirstName"
            colFirstName.OptionsEditForm.Visible = Utils.DefaultBoolean.True
            colFirstName.OptionsEditForm.VisibleIndex = 2
            ' 
            ' colLastName
            ' 
            colLastName.FieldName = "LastName"
            colLastName.Name = "colLastName"
            colLastName.OptionsEditForm.Visible = Utils.DefaultBoolean.True
            colLastName.OptionsEditForm.VisibleIndex = 3
            ' 
            ' barManager
            ' 
            barManager.Bars.AddRange(New XtraBars.Bar() {actionsBar})
            barManager.DockControls.Add(barDockControlTop)
            barManager.DockControls.Add(barDockControlBottom)
            barManager.DockControls.Add(barDockControlLeft)
            barManager.DockControls.Add(barDockControlRight)
            barManager.Form = Me
            barManager.Images = actionImages
            barManager.Items.AddRange(New XtraBars.BarItem() {beStatusFilter, bbiNew, bbiReload, bbiDelete, bbiPrint})
            barManager.MainMenu = actionsBar
            barManager.MaxItemId = 7
            barManager.RepositoryItems.AddRange(New XtraEditors.Repository.RepositoryItem() {bicbStatus})
            ' 
            ' actionsBar
            ' 
            actionsBar.BarName = "Actions"
            actionsBar.DockCol = 0
            actionsBar.DockRow = 0
            actionsBar.DockStyle = XtraBars.BarDockStyle.Top
            actionsBar.LinksPersistInfo.AddRange(New XtraBars.LinkPersistInfo() {New XtraBars.LinkPersistInfo(XtraBars.BarLinkUserDefines.Width, beStatusFilter, "", False, True, True, 91), New XtraBars.LinkPersistInfo(bbiNew), New XtraBars.LinkPersistInfo(bbiReload), New XtraBars.LinkPersistInfo(bbiDelete), New XtraBars.LinkPersistInfo(bbiPrint)})
            actionsBar.OptionsBar.AllowQuickCustomization = False
            actionsBar.OptionsBar.DisableCustomization = True
            actionsBar.OptionsBar.DrawDragBorder = False
            actionsBar.OptionsBar.MultiLine = True
            actionsBar.OptionsBar.UseWholeRow = True
            actionsBar.Text = "Actions"
            ' 
            ' beStatusFilter
            ' 
            beStatusFilter.Caption = "Filter by Status:"
            beStatusFilter.Edit = bicbStatus
            beStatusFilter.Id = 1
            beStatusFilter.Name = "beStatusFilter"
            beStatusFilter.PaintStyle = XtraBars.BarItemPaintStyle.Caption
            AddHandler beStatusFilter.EditValueChanged, New EventHandler(AddressOf OnStatusFilterChanged)
            ' 
            ' bicbStatus
            ' 
            bicbStatus.AutoHeight = False
            bicbStatus.Buttons.AddRange(New XtraEditors.Controls.EditorButton() {New XtraEditors.Controls.EditorButton(XtraEditors.Controls.ButtonPredefines.Combo)})
            bicbStatus.Name = "bicbStatus"
            ' 
            ' bbiNew
            ' 
            bbiNew.Caption = "Add New"
            bbiNew.Id = 2
            bbiNew.ImageOptions.ImageIndex = 0
            bbiNew.Name = "bbiNew"
            bbiNew.PaintStyle = XtraBars.BarItemPaintStyle.CaptionGlyph
            AddHandler bbiNew.ItemClick, New XtraBars.ItemClickEventHandler(AddressOf OnNew)
            ' 
            ' bbiReload
            ' 
            bbiReload.Caption = "Reload Data"
            bbiReload.Id = 3
            bbiReload.ImageOptions.ImageIndex = 1
            bbiReload.Name = "bbiReload"
            bbiReload.PaintStyle = XtraBars.BarItemPaintStyle.CaptionGlyph
            AddHandler bbiReload.ItemClick, New XtraBars.ItemClickEventHandler(AddressOf OnReload)
            ' 
            ' bbiDelete
            ' 
            bbiDelete.Caption = "Delete"
            bbiDelete.Id = 4
            bbiDelete.ImageOptions.ImageIndex = 2
            bbiDelete.Name = "bbiDelete"
            bbiDelete.PaintStyle = XtraBars.BarItemPaintStyle.CaptionGlyph
            AddHandler bbiDelete.ItemClick, New XtraBars.ItemClickEventHandler(AddressOf OnDelete)
            ' 
            ' bbiPrint
            ' 
            bbiPrint.Caption = "Print"
            bbiPrint.Id = 5
            bbiPrint.ImageOptions.ImageIndex = 3
            bbiPrint.Name = "bbiPrint"
            bbiPrint.PaintStyle = XtraBars.BarItemPaintStyle.CaptionGlyph
            AddHandler bbiPrint.ItemClick, New XtraBars.ItemClickEventHandler(AddressOf OnPrint)
            ' 
            ' barDockControlTop
            ' 
            barDockControlTop.CausesValidation = False
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
            barDockControlTop.Location = New System.Drawing.Point(0, 0)
            barDockControlTop.Manager = barManager
            barDockControlTop.Size = New System.Drawing.Size(800, 24)
            ' 
            ' barDockControlBottom
            ' 
            barDockControlBottom.CausesValidation = False
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            barDockControlBottom.Location = New System.Drawing.Point(0, 420)
            barDockControlBottom.Manager = barManager
            barDockControlBottom.Size = New System.Drawing.Size(800, 0)
            ' 
            ' barDockControlLeft
            ' 
            barDockControlLeft.CausesValidation = False
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
            barDockControlLeft.Location = New System.Drawing.Point(0, 24)
            barDockControlLeft.Manager = barManager
            barDockControlLeft.Size = New System.Drawing.Size(0, 396)
            ' 
            ' barDockControlRight
            ' 
            barDockControlRight.CausesValidation = False
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
            barDockControlRight.Location = New System.Drawing.Point(800, 24)
            barDockControlRight.Manager = barManager
            barDockControlRight.Size = New System.Drawing.Size(0, 396)
            ' 
            ' actionImages
            ' 
            actionImages.Add("addnew", "image://svgimages/outlook inspired/newemployee.svg")
            actionImages.Add("refresh", "image://svgimages/outlook inspired/resetview.svg")
            actionImages.Add("delete", "image://svgimages/outlook inspired/delete.svg")
            actionImages.Add("print", "image://svgimages/outlook inspired/print.svg")
            ' 
            ' rootGroup
            ' 
            rootGroup.EnableIndentsWithoutBorders = Utils.DefaultBoolean.True
            rootGroup.GroupBordersVisible = False
            rootGroup.Items.AddRange(New XtraLayout.BaseLayoutItem() {ItemForMasterGrid})
            rootGroup.Name = "rootGroup"
            rootGroup.Size = New System.Drawing.Size(800, 396)
            rootGroup.TextVisible = False
            ' 
            ' ItemForMasterGrid
            ' 
            ItemForMasterGrid.Control = contactsGrid
            ItemForMasterGrid.Location = New System.Drawing.Point(0, 0)
            ItemForMasterGrid.Name = "ItemForMasterGrid"
            ItemForMasterGrid.Padding = New XtraLayout.Utils.Padding(0, 0, 0, 0)
            ItemForMasterGrid.Size = New System.Drawing.Size(780, 376)
            ItemForMasterGrid.TextSize = New System.Drawing.Size(0, 0)
            ItemForMasterGrid.TextVisible = False
            ' 
            ' teMail
            ' 
            teMail.AutoHeight = False
            teMail.Name = "teMail"
            ' 
            ' ContactsSimple
            ' 
            AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
            Controls.Add(dataLayout)
            Controls.Add(barDockControlLeft)
            Controls.Add(barDockControlRight)
            Controls.Add(barDockControlBottom)
            Controls.Add(barDockControlTop)
            Name = "ContactsSimple"
            Size = New System.Drawing.Size(800, 420)
            CType(dataLayout, ComponentModel.ISupportInitialize).EndInit()
            dataLayout.ResumeLayout(False)
            CType(contactsGrid, ComponentModel.ISupportInitialize).EndInit()
            CType(contactsBindingSource, ComponentModel.ISupportInitialize).EndInit()
            CType(contactsGridView, ComponentModel.ISupportInitialize).EndInit()
            CType(tePhone, ComponentModel.ISupportInitialize).EndInit()
            CType(icbPrefix, ComponentModel.ISupportInitialize).EndInit()
            CType(icbStatus, ComponentModel.ISupportInitialize).EndInit()
            CType(pePhoto, ComponentModel.ISupportInitialize).EndInit()
            CType(barManager, ComponentModel.ISupportInitialize).EndInit()
            CType(bicbStatus, ComponentModel.ISupportInitialize).EndInit()
            CType(actionImages, ComponentModel.ISupportInitialize).EndInit()
            CType(rootGroup, ComponentModel.ISupportInitialize).EndInit()
            CType(ItemForMasterGrid, ComponentModel.ISupportInitialize).EndInit()
            CType(teMail, ComponentModel.ISupportInitialize).EndInit()
            CType(behaviorManager1, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
            PerformLayout()

        End Sub

#End Region

        Private dataLayout As XtraDataLayout.DataLayoutControl
        Private rootGroup As XtraLayout.LayoutControlGroup
        Private actionImages As Utils.SvgImageCollection
        Private barManager As XtraBars.BarManager
        Private bbiReload As XtraBars.BarButtonItem
        Private actionsBar As XtraBars.Bar
        Private barDockControlTop As XtraBars.BarDockControl
        Private barDockControlBottom As XtraBars.BarDockControl
        Private barDockControlLeft As XtraBars.BarDockControl
        Private barDockControlRight As XtraBars.BarDockControl
        Private contactsGrid As XtraGrid.GridControl
        Private contactsGridView As XtraGrid.Views.Grid.GridView
        Private contactsBindingSource As System.Windows.Forms.BindingSource
        Private colTitle As XtraGrid.Columns.GridColumn
        Private colFullName As XtraGrid.Columns.GridColumn
        Private colEmail As XtraGrid.Columns.GridColumn
        Private teMail As XtraEditors.Repository.RepositoryItemTextEdit
        Private bbiNew As XtraBars.BarButtonItem
        Private bbiDelete As XtraBars.BarButtonItem
        Private ItemForMasterGrid As XtraLayout.LayoutControlItem
        Private colDepartment As XtraGrid.Columns.GridColumn
        Private colMobilePhone As XtraGrid.Columns.GridColumn
        Private colPrefix As XtraGrid.Columns.GridColumn
        Private colStatus As XtraGrid.Columns.GridColumn
        Private colPhoto As XtraGrid.Columns.GridColumn
        Private icbPrefix As XtraEditors.Repository.RepositoryItemImageComboBox
        Private icbStatus As XtraEditors.Repository.RepositoryItemImageComboBox
        Private beStatusFilter As XtraBars.BarEditItem
        Private bicbStatus As XtraEditors.Repository.RepositoryItemImageComboBox
        Private bbiPrint As XtraBars.BarButtonItem
        Private behaviorManager1 As Utils.Behaviors.BehaviorManager
        Private colFirstName As XtraGrid.Columns.GridColumn
        Private colLastName As XtraGrid.Columns.GridColumn
        Private tePhone As XtraEditors.Repository.RepositoryItemTextEdit
        Private pePhoto As XtraEditors.Repository.RepositoryItemPictureEdit
    End Class
End Namespace
