Namespace Views

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChipGroupView

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim ColumnDefinition1 As DevExpress.XtraLayout.ColumnDefinition = New DevExpress.XtraLayout.ColumnDefinition()
            Dim ColumnDefinition2 As DevExpress.XtraLayout.ColumnDefinition = New DevExpress.XtraLayout.ColumnDefinition()
            Dim ColumnDefinition3 As DevExpress.XtraLayout.ColumnDefinition = New DevExpress.XtraLayout.ColumnDefinition()
            Dim RowDefinition1 As DevExpress.XtraLayout.RowDefinition = New DevExpress.XtraLayout.RowDefinition()
            Dim RowDefinition2 As DevExpress.XtraLayout.RowDefinition = New DevExpress.XtraLayout.RowDefinition()
            Dim RowDefinition3 As DevExpress.XtraLayout.RowDefinition = New DevExpress.XtraLayout.RowDefinition()
            layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
            chipGroup1 = New DevExpress.UITemplates.Collection.Editors.ChipGroup()
            Root = New DevExpress.XtraLayout.LayoutControlGroup()
            layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            CType(layoutControl1, ComponentModel.ISupportInitialize).BeginInit()
            layoutControl1.SuspendLayout()
            CType(Root, ComponentModel.ISupportInitialize).BeginInit()
            CType(layoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' layoutControl1
            ' 
            layoutControl1.Controls.Add(chipGroup1)
            layoutControl1.Dock = DockStyle.Fill
            layoutControl1.Location = New Point(0, 0)
            layoutControl1.Name = "layoutControl1"
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New Rectangle(2857, 49, 650, 400)
            layoutControl1.Root = Root
            layoutControl1.Size = New Size(659, 478)
            layoutControl1.TabIndex = 0
            layoutControl1.Text = "layoutControl1"
            ' 
            ' chipGroup1
            ' 
            chipGroup1.AutoSizeMode = DevExpress.UITemplates.Collection.Editors.ChipGroupBase.GroupAutoSizeMode.Vertical
            chipGroup1.Items.AddRange(New DevExpress.UITemplates.Collection.Editors.Chip() {New DevExpress.UITemplates.Collection.Editors.Chip(1, "Red"), New DevExpress.UITemplates.Collection.Editors.Chip(2, "Green"), New DevExpress.UITemplates.Collection.Editors.Chip(3, "Blue"), New DevExpress.UITemplates.Collection.Editors.Chip(4, "Yellow"), New DevExpress.UITemplates.Collection.Editors.Chip(5, "White"), New DevExpress.UITemplates.Collection.Editors.Chip(6, "Orange"), New DevExpress.UITemplates.Collection.Editors.Chip(7, "Pink")})
            chipGroup1.ItemSize = DevExpress.UITemplates.Collection.Components.ItemsSelector.Size.Large
            chipGroup1.Location = New Point(176, 190)
            chipGroup1.Name = "chipGroup1"
            chipGroup1.Size = New Size(315, 80)
            chipGroup1.StyleController = layoutControl1
            chipGroup1.TabIndex = 4
            ' 
            ' Root
            ' 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
            Root.GroupBordersVisible = False
            Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {layoutControlItem1})
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table
            Root.Name = "Root"
            ColumnDefinition1.SizeType = SizeType.Percent
            ColumnDefinition1.Width = 25R
            ColumnDefinition2.SizeType = SizeType.Percent
            ColumnDefinition2.Width = 50R
            ColumnDefinition3.SizeType = SizeType.Percent
            ColumnDefinition3.Width = 25R
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(New DevExpress.XtraLayout.ColumnDefinition() {ColumnDefinition1, ColumnDefinition2, ColumnDefinition3})
            RowDefinition1.Height = 25R
            RowDefinition1.SizeType = SizeType.Percent
            RowDefinition2.Height = 50R
            RowDefinition2.SizeType = SizeType.Percent
            RowDefinition3.Height = 25R
            RowDefinition3.SizeType = SizeType.Percent
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(New DevExpress.XtraLayout.RowDefinition() {RowDefinition1, RowDefinition2, RowDefinition3})
            Root.Size = New Size(667, 461)
            Root.TextVisible = False
            ' 
            ' layoutControlItem1
            ' 
            layoutControlItem1.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center
            layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center
            layoutControlItem1.Control = chipGroup1
            layoutControlItem1.Location = New Point(160, 109)
            layoutControlItem1.MaxSize = New Size(321, 86)
            layoutControlItem1.MinSize = New Size(321, 86)
            layoutControlItem1.Name = "layoutControlItem1"
            layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 1
            layoutControlItem1.Size = New Size(321, 217)
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
            layoutControlItem1.TextVisible = False
            ' 
            ' ChipGroupView
            ' 
            AutoScaleDimensions = New SizeF(6F, 13F)
            AutoScaleMode = AutoScaleMode.Font
            Controls.Add(layoutControl1)
            Name = "ChipGroupView"
            Size = New Size(659, 478)
            CType(layoutControl1, ComponentModel.ISupportInitialize).EndInit()
            layoutControl1.ResumeLayout(False)
            CType(Root, ComponentModel.ISupportInitialize).EndInit()
            CType(layoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
        End Sub

        Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
        Private Root As DevExpress.XtraLayout.LayoutControlGroup
        Private chipGroup1 As DevExpress.UITemplates.Collection.Editors.ChipGroup
        Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem

End Class

End Namespace
