Namespace Views

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PasswordBoxView

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
            passwordBox1 = New DevExpress.UITemplates.Collection.Editors.PasswordBox()
            Root = New DevExpress.XtraLayout.LayoutControlGroup()
            layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            CType(layoutControl1, ComponentModel.ISupportInitialize).BeginInit()
            layoutControl1.SuspendLayout()
            CType(passwordBox1, ComponentModel.ISupportInitialize).BeginInit()
            CType(Root, ComponentModel.ISupportInitialize).BeginInit()
            CType(layoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' layoutControl1
            ' 
            layoutControl1.Controls.Add(passwordBox1)
            layoutControl1.Dock = DockStyle.Fill
            layoutControl1.Location = New Point(0, 0)
            layoutControl1.Name = "layoutControl1"
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New Rectangle(2857, 49, 650, 400)
            layoutControl1.Root = Root
            layoutControl1.Size = New Size(659, 478)
            layoutControl1.TabIndex = 0
            layoutControl1.Text = "layoutControl1"
            ' 
            ' passwordBox1
            ' 
            passwordBox1.FooterLabel = "A password must be at least 8 characters."
            passwordBox1.HeaderLabel = "Password"
            passwordBox1.Location = New Point(174, 214)
            passwordBox1.Name = "passwordBox1"
            passwordBox1.Placeholder = "e.g., ••••••••"
            passwordBox1.ShowStrengthIndicator = True
            passwordBox1.Size = New Size(310, 49)
            passwordBox1.StyleController = layoutControl1
            passwordBox1.TabIndex = 4
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
            Root.Size = New Size(659, 478)
            Root.TextVisible = False
            ' 
            ' layoutControlItem1
            ' 
            layoutControlItem1.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center
            layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center
            layoutControlItem1.Control = passwordBox1
            layoutControlItem1.Location = New Point(158, 113)
            layoutControlItem1.MaxSize = New Size(316, 55)
            layoutControlItem1.MinSize = New Size(316, 55)
            layoutControlItem1.Name = "layoutControlItem1"
            layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 1
            layoutControlItem1.Size = New Size(316, 226)
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
            layoutControlItem1.TextVisible = False
            ' 
            ' PasswordBoxView
            ' 
            AutoScaleDimensions = New SizeF(6F, 13F)
            AutoScaleMode = AutoScaleMode.Font
            Controls.Add(layoutControl1)
            Name = "PasswordBoxView"
            Size = New Size(659, 478)
            CType(layoutControl1, ComponentModel.ISupportInitialize).EndInit()
            layoutControl1.ResumeLayout(False)
            CType(passwordBox1, ComponentModel.ISupportInitialize).EndInit()
            CType(Root, ComponentModel.ISupportInitialize).EndInit()
            CType(layoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
        End Sub

        Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
        Private Root As DevExpress.XtraLayout.LayoutControlGroup
        Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
        Private passwordBox1 As DevExpress.UITemplates.Collection.Editors.PasswordBox

End Class

End Namespace
