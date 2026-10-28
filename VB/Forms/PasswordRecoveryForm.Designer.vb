Namespace DevExpress.UITemplates.Collection.Forms
    Partial Class PasswordRecoveryForm
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
            tbEmail = New Collection.Editors.EmailBox()
            viewModelBindingSource = New System.Windows.Forms.BindingSource(components)
            btnRecover = New Collection.Editors.Button()
            mvvmContext = New Utils.MVVM.MVVMContext(components)
            dxContainer = New XtraEditors.DirectXFormContainerControl()
            CType(layoutContainer, ComponentModel.ISupportInitialize).BeginInit()
            layoutContainer.SuspendLayout()
            CType(tbEmail, ComponentModel.ISupportInitialize).BeginInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).BeginInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).BeginInit()
            dxContainer.SuspendLayout()
            SuspendLayout()
            ' 
            ' layoutContainer
            ' 
            layoutContainer.AllowFocus = False
            layoutContainer.Controls.Add(tbEmail)
            layoutContainer.Controls.Add(btnRecover)
            layoutContainer.Cursor = System.Windows.Forms.Cursors.Default
            layoutContainer.DataContext = viewModelBindingSource
            layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill
            layoutContainer.Location = New System.Drawing.Point(0, 0)
            layoutContainer.Name = "layoutContainer"
            layoutContainer.Size = New System.Drawing.Size(448, 188)
            layoutContainer.TabIndex = 0
            layoutContainer.TabStop = False
            ' 
            ' tbEmail
            ' 
            tbEmail.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "Email", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            tbEmail.EditorSize = XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large
            tbEmail.Location = New System.Drawing.Point(32, 61)
            tbEmail.Name = "tbEmail"
            tbEmail.Placeholder = "Email"
            tbEmail.Size = New System.Drawing.Size(384, 30)
            tbEmail.TabIndex = 0
            tbEmail.WarningTooltipAnchor = XtraEditors.Internal.HtmlTextBoxBase.EditToolTipAnchor.Editor
            tbEmail.WarningToolTipLocation = Utils.ToolTipLocation.TopCenter
            ' 
            ' viewModelBindingSource
            ' 
            viewModelBindingSource.DataSource = GetType(ViewModel)
            ' 
            ' btnRecover
            ' 
            btnRecover.ButtonSize = Collection.Editors.ButtonBase.SizeType.Large
            btnRecover.DialogResult = System.Windows.Forms.DialogResult.OK
            btnRecover.Location = New System.Drawing.Point(276, 126)
            btnRecover.Name = "btnRecover"
            btnRecover.Size = New System.Drawing.Size(140, 30)
            btnRecover.TabIndex = 1
            btnRecover.Text = "{Action}"
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
            dxContainer.Size = New System.Drawing.Size(448, 188)
            dxContainer.TabIndex = 0
            dxContainer.TabStop = False
            ' 
            ' PasswordRecoveryForm
            ' 
            AcceptButton = btnRecover
            AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
            ClientSize = New System.Drawing.Size(450, 220)
            Controls.Add(dxContainer)
            DoubleBuffered = True
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "PasswordRecoveryForm"
            Text = "{Title}"
            CType(layoutContainer, ComponentModel.ISupportInitialize).EndInit()
            layoutContainer.ResumeLayout(False)
            CType(tbEmail, ComponentModel.ISupportInitialize).EndInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).EndInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).EndInit()
            dxContainer.ResumeLayout(False)
            ResumeLayout(False)

        End Sub

#End Region

        Private layoutContainer As XtraEditors.HtmlContentControl
        Private tbEmail As Collection.Editors.EmailBox
        Private btnRecover As Collection.Editors.Button
        Private mvvmContext As Utils.MVVM.MVVMContext
        Private viewModelBindingSource As System.Windows.Forms.BindingSource
        Private dxContainer As XtraEditors.DirectXFormContainerControl
    End Class
End Namespace
