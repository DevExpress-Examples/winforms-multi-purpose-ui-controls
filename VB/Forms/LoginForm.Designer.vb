Namespace DevExpress.UITemplates.Collection.Forms
    Partial Class LoginForm
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
            tbPassword = New Collection.Editors.PasswordBox()
            btnLogin = New Collection.Editors.Button()
            mvvmContext = New Utils.MVVM.MVVMContext(components)
            dxContainer = New XtraEditors.DirectXFormContainerControl()
            CType(layoutContainer, ComponentModel.ISupportInitialize).BeginInit()
            layoutContainer.SuspendLayout()
            CType(tbEmail, ComponentModel.ISupportInitialize).BeginInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).BeginInit()
            CType(tbPassword, ComponentModel.ISupportInitialize).BeginInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).BeginInit()
            dxContainer.SuspendLayout()
            SuspendLayout()
            ' 
            ' layoutContainer
            ' 
            layoutContainer.AllowFocus = False
            layoutContainer.Controls.Add(tbEmail)
            layoutContainer.Controls.Add(tbPassword)
            layoutContainer.Controls.Add(btnLogin)
            layoutContainer.Cursor = System.Windows.Forms.Cursors.Default
            layoutContainer.DataContext = viewModelBindingSource
            layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill
            layoutContainer.Location = New System.Drawing.Point(0, 0)
            layoutContainer.Name = "layoutContainer"
            layoutContainer.Size = New System.Drawing.Size(373, 228)
            layoutContainer.TabIndex = 0
            layoutContainer.TabStop = False
            ' 
            ' tbEmail
            ' 
            tbEmail.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "Email", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            tbEmail.EditorSize = XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large
            tbEmail.Location = New System.Drawing.Point(32, 32)
            tbEmail.Name = "tbEmail"
            tbEmail.Placeholder = "Email"
            tbEmail.Size = New System.Drawing.Size(309, 30)
            tbEmail.TabIndex = 0
            tbEmail.WarningTooltipAnchor = XtraEditors.Internal.HtmlTextBoxBase.EditToolTipAnchor.Editor
            tbEmail.WarningToolTipLocation = Utils.ToolTipLocation.TopCenter
            ' 
            ' viewModelBindingSource
            ' 
            viewModelBindingSource.DataSource = GetType(ViewModel)
            ' 
            ' tbPassword
            ' 
            tbPassword.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "Password", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            tbPassword.EditorSize = XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large
            tbPassword.Location = New System.Drawing.Point(32, 70)
            tbPassword.Name = "tbPassword"
            tbPassword.Placeholder = "Password"
            tbPassword.Size = New System.Drawing.Size(309, 30)
            tbPassword.TabIndex = 1
            ' 
            ' btnLogin
            ' 
            btnLogin.ButtonSize = Collection.Editors.ButtonBase.SizeType.Large
            btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK
            btnLogin.Location = New System.Drawing.Point(32, 166)
            btnLogin.Name = "btnLogin"
            btnLogin.Size = New System.Drawing.Size(84, 30)
            btnLogin.TabIndex = 2
            btnLogin.Text = "{Action}"
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
            dxContainer.Size = New System.Drawing.Size(373, 228)
            dxContainer.TabIndex = 0
            dxContainer.TabStop = False
            ' 
            ' LoginForm
            ' 
            AcceptButton = btnLogin
            AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
            ClientSize = New System.Drawing.Size(375, 260)
            Controls.Add(dxContainer)
            DoubleBuffered = True
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "LoginForm"
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "{Title}"
            CType(layoutContainer, ComponentModel.ISupportInitialize).EndInit()
            layoutContainer.ResumeLayout(False)
            CType(tbEmail, ComponentModel.ISupportInitialize).EndInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).EndInit()
            CType(tbPassword, ComponentModel.ISupportInitialize).EndInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).EndInit()
            dxContainer.ResumeLayout(False)
            ResumeLayout(False)

        End Sub

#End Region

        Private layoutContainer As XtraEditors.HtmlContentControl
        Private tbEmail As Collection.Editors.EmailBox
        Private tbPassword As Collection.Editors.PasswordBox
        Private btnLogin As Collection.Editors.Button
        Private mvvmContext As Utils.MVVM.MVVMContext
        Private viewModelBindingSource As System.Windows.Forms.BindingSource
        Private dxContainer As XtraEditors.DirectXFormContainerControl
    End Class
End Namespace
