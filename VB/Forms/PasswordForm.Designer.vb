Namespace DevExpress.UITemplates.Collection.Forms
    Partial Class PasswordForm
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
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(PasswordForm))
            layoutContainer = New XtraEditors.HtmlContentControl()
            tbPassword = New Collection.Editors.PasswordBox()
            viewModelBindingSource = New System.Windows.Forms.BindingSource(components)
            tbConfirmPassword = New Collection.Editors.PasswordBox()
            btnChange = New Collection.Editors.Button()
            mvvmContext = New Utils.MVVM.MVVMContext(components)
            dxContainer = New XtraEditors.DirectXFormContainerControl()
            CType(layoutContainer, ComponentModel.ISupportInitialize).BeginInit()
            layoutContainer.SuspendLayout()
            CType(tbPassword, ComponentModel.ISupportInitialize).BeginInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).BeginInit()
            CType(tbConfirmPassword, ComponentModel.ISupportInitialize).BeginInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).BeginInit()
            dxContainer.SuspendLayout()
            SuspendLayout()
            ' 
            ' layoutContainer
            ' 
            layoutContainer.AllowFocus = False
            layoutContainer.Controls.Add(tbPassword)
            layoutContainer.Controls.Add(tbConfirmPassword)
            layoutContainer.Controls.Add(btnChange)
            layoutContainer.Cursor = System.Windows.Forms.Cursors.Default
            layoutContainer.DataContext = viewModelBindingSource
            layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill
            layoutContainer.Location = New System.Drawing.Point(0, 0)
            layoutContainer.Name = "layoutContainer"
            layoutContainer.Size = New System.Drawing.Size(356, 248)
            layoutContainer.TabIndex = 0
            layoutContainer.TabStop = False
            ' 
            ' tbPassword
            ' 
            tbPassword.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "Password", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            tbPassword.EditorSize = XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large
            tbPassword.Location = New System.Drawing.Point(32, 61)
            tbPassword.Name = "tbPassword"
            tbPassword.Placeholder = "New Password"
            tbPassword.ShowStrengthIndicator = True
            tbPassword.Size = New System.Drawing.Size(292, 32)
            tbPassword.TabIndex = 1
            tbPassword.WarningTooltipAnchor = XtraEditors.Internal.HtmlTextBoxBase.EditToolTipAnchor.Editor
            tbPassword.WarningToolTipLocation = Utils.ToolTipLocation.TopCenter
            ' 
            ' viewModelBindingSource
            ' 
            viewModelBindingSource.DataSource = GetType(ViewModel)
            ' 
            ' tbConfirmPassword
            ' 
            tbConfirmPassword.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "ConfirmedPassword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            tbConfirmPassword.EditorSize = XtraEditors.Internal.HtmlTextBoxBase.EditSize.Large
            tbConfirmPassword.Location = New System.Drawing.Point(32, 101)
            tbConfirmPassword.Name = "tbConfirmPassword"
            tbConfirmPassword.Placeholder = "Confirm New Password"
            tbConfirmPassword.Size = New System.Drawing.Size(292, 30)
            tbConfirmPassword.ShowCapsLockWarningToolTip = False
            tbConfirmPassword.ShowPasswordWeaknessWarningToolTip = False
            tbConfirmPassword.TabIndex = 2
            ' 
            ' btnChange
            ' 
            btnChange.ButtonSize = Collection.Editors.ButtonBase.SizeType.Large
            btnChange.DialogResult = System.Windows.Forms.DialogResult.OK
            btnChange.Location = New System.Drawing.Point(184, 186)
            btnChange.Name = "btnChange"
            btnChange.Size = New System.Drawing.Size(140, 30)
            btnChange.TabIndex = 3
            btnChange.Text = "{Action}"
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
            dxContainer.Size = New System.Drawing.Size(356, 248)
            dxContainer.TabIndex = 0
            dxContainer.TabStop = False
            ' 
            ' PasswordForm
            ' 
            AcceptButton = btnChange
            AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
            ClientSize = New System.Drawing.Size(358, 280)
            Controls.Add(dxContainer)
            DoubleBuffered = True
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "PasswordForm"
            Text = "{Title}"
            CType(layoutContainer, ComponentModel.ISupportInitialize).EndInit()
            layoutContainer.ResumeLayout(False)
            CType(tbPassword, ComponentModel.ISupportInitialize).EndInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).EndInit()
            CType(tbConfirmPassword, ComponentModel.ISupportInitialize).EndInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).EndInit()
            dxContainer.ResumeLayout(False)
            ResumeLayout(False)

        End Sub

#End Region

        Private layoutContainer As XtraEditors.HtmlContentControl
        Private tbPassword As Collection.Editors.PasswordBox
        Private tbConfirmPassword As Collection.Editors.PasswordBox
        Private btnChange As Collection.Editors.Button
        Private mvvmContext As Utils.MVVM.MVVMContext
        Private viewModelBindingSource As System.Windows.Forms.BindingSource
        Private dxContainer As XtraEditors.DirectXFormContainerControl
    End Class
End Namespace
