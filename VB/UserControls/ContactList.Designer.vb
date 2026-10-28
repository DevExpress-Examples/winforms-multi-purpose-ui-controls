Namespace DevExpress.UITemplates.Collection.UserControls
    Partial Class ContactList
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

#Region "Windows Form Designer generated code"
        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New ComponentModel.Container()
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(ContactList))
            tablePanel = New Utils.Layout.TablePanel()
            searchPanel = New XtraEditors.HtmlContentControl()
            searchControl = New XtraEditors.SearchControl()
            gridControl = New XtraGrid.GridControl()
            contactsTileView = New XtraGrid.Views.Tile.TileView()
            mvvmContext = New Utils.MVVM.MVVMContext(components)
            CType(tablePanel, ComponentModel.ISupportInitialize).BeginInit()
            tablePanel.SuspendLayout()
            CType(searchPanel, ComponentModel.ISupportInitialize).BeginInit()
            searchPanel.SuspendLayout()
            CType(searchControl.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(gridControl, ComponentModel.ISupportInitialize).BeginInit()
            CType(contactsTileView, ComponentModel.ISupportInitialize).BeginInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' tablePanel
            ' 
            tablePanel.Columns.AddRange(New Utils.Layout.TablePanelColumn() {New Utils.Layout.TablePanelColumn(Utils.Layout.TablePanelEntityStyle.Relative, 1F)})
            tablePanel.Controls.Add(searchPanel)
            tablePanel.Controls.Add(gridControl)
            tablePanel.Dock = System.Windows.Forms.DockStyle.Fill
            tablePanel.Location = New System.Drawing.Point(0, 0)
            tablePanel.Margin = New System.Windows.Forms.Padding(0)
            tablePanel.Name = "tablePanel"
            tablePanel.Rows.AddRange(New Utils.Layout.TablePanelRow() {New Utils.Layout.TablePanelRow(Utils.Layout.TablePanelEntityStyle.Absolute, 49F), New Utils.Layout.TablePanelRow(Utils.Layout.TablePanelEntityStyle.Relative, 1F)})
            tablePanel.Size = New System.Drawing.Size(270, 600)
            tablePanel.TabIndex = 1
            ' 
            ' searchPanel
            ' 
            tablePanel.SetColumn(searchPanel, 0)
            searchPanel.Controls.Add(searchControl)
            searchPanel.Dock = System.Windows.Forms.DockStyle.Fill
            searchPanel.Location = New System.Drawing.Point(0, 0)
            searchPanel.Margin = New System.Windows.Forms.Padding(0)
            searchPanel.Name = "searchPanel"
            tablePanel.SetRow(searchPanel, 0)
            searchPanel.Size = New System.Drawing.Size(270, 49)
            searchPanel.TabIndex = 3
            ' 
            ' searchControl
            ' 
            searchControl.Client = gridControl
            searchControl.Location = New System.Drawing.Point(76, 15)
            searchControl.Margin = New System.Windows.Forms.Padding(0)
            searchControl.Name = "searchControl"
            searchControl.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
            searchControl.Properties.Buttons.AddRange(New XtraEditors.Controls.EditorButton() {New XtraEditors.Repository.ClearButton()})
            searchControl.Properties.Client = gridControl
            searchControl.Properties.ShowSearchButton = False
            searchControl.Size = New System.Drawing.Size(179, 18)
            searchControl.TabIndex = 0
            ' 
            ' gridControl
            ' 
            tablePanel.SetColumn(gridControl, 0)
            gridControl.Dock = System.Windows.Forms.DockStyle.Fill
            gridControl.Location = New System.Drawing.Point(0, 49)
            gridControl.MainView = contactsTileView
            gridControl.Margin = New System.Windows.Forms.Padding(0)
            gridControl.Name = "gridControl"
            tablePanel.SetRow(gridControl, 1)
            gridControl.Size = New System.Drawing.Size(270, 551)
            gridControl.TabIndex = 0
            gridControl.ViewCollection.AddRange(New XtraGrid.Views.Base.BaseView() {contactsTileView})
            ' 
            ' contactsTileView
            ' 
            contactsTileView.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
            contactsTileView.GridControl = gridControl
            contactsTileView.Name = "contactsTileView"
            contactsTileView.OptionsList.DrawItemSeparators = XtraGrid.Views.Tile.DrawItemSeparatorsMode.None
            contactsTileView.OptionsTiles.AllowPressAnimation = False
            contactsTileView.OptionsTiles.GroupTextPadding = New System.Windows.Forms.Padding(0)
            contactsTileView.OptionsTiles.HighlightFocusedTileStyle = XtraGrid.Views.Tile.HighlightFocusedTileStyle.None
            contactsTileView.OptionsTiles.IndentBetweenGroups = 0
            contactsTileView.OptionsTiles.IndentBetweenItems = 0
            contactsTileView.OptionsTiles.ItemPadding = New System.Windows.Forms.Padding(0)
            contactsTileView.OptionsTiles.ItemSize = New System.Drawing.Size(248, 72)
            contactsTileView.OptionsTiles.LayoutMode = XtraGrid.Views.Tile.TileViewLayoutMode.List
            contactsTileView.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
            contactsTileView.OptionsTiles.Padding = New System.Windows.Forms.Padding(0)
            contactsTileView.OptionsTiles.RowCount = 0
            AddHandler contactsTileView.ItemCustomize, New XtraGrid.Views.Tile.TileViewItemCustomizeEventHandler(AddressOf OnContactItemTemplateCustomize)
            AddHandler contactsTileView.CustomItemTemplate, New XtraGrid.Views.Tile.TileViewCustomItemTemplateEventHandler(AddressOf OnContactItemTemplate)
            ' 
            ' mvvmContext
            ' 
            mvvmContext.ContainerControl = Me
            mvvmContext.ViewModelType = GetType(ViewModel)
            ' 
            ' ContactsView
            ' 
            AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Controls.Add(tablePanel)
            Margin = New System.Windows.Forms.Padding(0)
            Name = "ContactsView"
            Size = New System.Drawing.Size(270, 600)
            CType(tablePanel, ComponentModel.ISupportInitialize).EndInit()
            tablePanel.ResumeLayout(False)
            CType(searchPanel, ComponentModel.ISupportInitialize).EndInit()
            searchPanel.ResumeLayout(False)
            CType(searchControl.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(gridControl, ComponentModel.ISupportInitialize).EndInit()
            CType(contactsTileView, ComponentModel.ISupportInitialize).EndInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)

        End Sub
#End Region

        Private tablePanel As Utils.Layout.TablePanel
        Private searchPanel As XtraEditors.HtmlContentControl
        Private searchControl As XtraEditors.SearchControl
        Private gridControl As XtraGrid.GridControl
        Private contactsTileView As XtraGrid.Views.Tile.TileView
        Private mvvmContext As Utils.MVVM.MVVMContext
    End Class
End Namespace
