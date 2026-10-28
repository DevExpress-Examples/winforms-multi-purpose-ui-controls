Imports DevExpress.UITemplates.Collection.Utilities

Namespace DevExpress.UITemplates.Collection.Forms
    Partial Class CreditCardForm
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
            layoutContainer = New XtraEditors.HtmlContentControl()
            nameBox = New Collection.Editors.EditBox()
            viewModelBindingSource = New System.Windows.Forms.BindingSource(components)
            cardBox = New Collection.Editors.PaymentCardBox()
            btnAdd = New Collection.Editors.Button()
            mvvmContext = New Utils.MVVM.MVVMContext(components)
            dxContainer = New XtraEditors.DirectXFormContainerControl()
            CType(layoutContainer, ComponentModel.ISupportInitialize).BeginInit()
            layoutContainer.SuspendLayout()
            CType(nameBox, ComponentModel.ISupportInitialize).BeginInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).BeginInit()
            CType(cardBox, ComponentModel.ISupportInitialize).BeginInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).BeginInit()
            dxContainer.SuspendLayout()
            SuspendLayout()
            ' 
            ' layoutContainer
            ' 
            layoutContainer.AllowFocus = False
            layoutContainer.Controls.Add(nameBox)
            layoutContainer.Controls.Add(cardBox)
            layoutContainer.Controls.Add(btnAdd)
            layoutContainer.Cursor = System.Windows.Forms.Cursors.Default
            layoutContainer.DataContext = viewModelBindingSource
            layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill
            layoutContainer.Location = New System.Drawing.Point(0, 0)
            layoutContainer.Name = "layoutContainer"
            layoutContainer.Size = New System.Drawing.Size(378, 404)
            layoutContainer.TabIndex = 0
            layoutContainer.TabStop = False
            ' 
            ' nameBox
            ' 
            nameBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            nameBox.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "CardHolder", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            nameBox.EditorSize = XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large
            nameBox.Location = New System.Drawing.Point(32, 224)
            nameBox.Name = "nameBox"
            nameBox.Placeholder = "CARD HOLDER"
            nameBox.Size = New System.Drawing.Size(314, 28)
            nameBox.TabIndex = 0
            ' 
            ' viewModelBindingSource
            ' 
            viewModelBindingSource.DataSource = GetType(ViewModel)
            ' 
            ' cardBox
            ' 
            cardBox.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "Card", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            cardBox.EditorSize = XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large
            cardBox.Location = New System.Drawing.Point(32, 260)
            cardBox.Name = "cardBox"
            cardBox.Placeholder = ""
            cardBox.Size = New System.Drawing.Size(314, 30)
            cardBox.TabIndex = 1
            cardBox.WarningTooltipAnchor = XtraEditors.Internal.HtmlTextBoxBase.EditToolTipAnchor.Editor
            cardBox.WarningToolTipLocation = Utils.ToolTipLocation.BottomCenter
            ' 
            ' btnAdd
            ' 
            btnAdd.ButtonSize = Collection.Editors.ButtonBase.SizeType.Large
            btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK
            btnAdd.Location = New System.Drawing.Point(206, 342)
            btnAdd.Name = "btnAdd"
            btnAdd.Size = New System.Drawing.Size(140, 30)
            btnAdd.TabIndex = 2
            btnAdd.Text = "{Action}"
            ' 
            ' mvvmContext
            ' 
            mvvmContext.ContainerControl = Me
            mvvmContext.ViewModelType = GetType(ViewModel)
            ' 
            ' dxContainer
            ' 
            dxContainer.Controls.Add(layoutContainer)
            dxContainer.Location = New System.Drawing.Point(1, 31)
            dxContainer.Name = "dxContainer"
            dxContainer.Size = New System.Drawing.Size(378, 404)
            dxContainer.TabIndex = 0
            dxContainer.TabStop = False
            ' 
            ' CreditCardForm
            ' 
            AcceptButton = btnAdd
            AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
            ClientSize = New System.Drawing.Size(380, 436)
            Controls.Add(dxContainer)
            DoubleBuffered = True
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "CreditCardForm"
            Text = "{Title}"
            CType(layoutContainer, ComponentModel.ISupportInitialize).EndInit()
            layoutContainer.ResumeLayout(False)
            CType(nameBox, ComponentModel.ISupportInitialize).EndInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).EndInit()
            CType(cardBox, ComponentModel.ISupportInitialize).EndInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).EndInit()
            dxContainer.ResumeLayout(False)
            ResumeLayout(False)

        End Sub

#End Region

        Private layoutContainer As XtraEditors.HtmlContentControl
        Private nameBox As Collection.Editors.EditBox
        Private cardBox As Collection.Editors.PaymentCardBox
        Private btnAdd As Collection.Editors.Button
        Private mvvmContext As Utils.MVVM.MVVMContext
        Private viewModelBindingSource As System.Windows.Forms.BindingSource
        Private dxContainer As XtraEditors.DirectXFormContainerControl
    End Class
End Namespace
