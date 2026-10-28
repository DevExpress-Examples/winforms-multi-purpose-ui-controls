Namespace DevExpress.UITemplates.Collection.Forms
    Partial Class AddressForm
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
            ccCountry = New Collection.Editors.CountryChooser()
            viewModelBindingSource = New System.Windows.Forms.BindingSource(components)
            ebAddressLine1 = New Collection.Editors.EditBox()
            ebAddressLine2 = New Collection.Editors.EditBox()
            ebZipCode = New Collection.Editors.EditBox()
            ebCity = New Collection.Editors.EditBox()
            ebState = New Collection.Editors.EditBox()
            btnAccept = New Collection.Editors.Button()
            mvvmContext = New Utils.MVVM.MVVMContext(components)
            dxContainer = New XtraEditors.DirectXFormContainerControl()
            CType(layoutContainer, ComponentModel.ISupportInitialize).BeginInit()
            layoutContainer.SuspendLayout()
            CType(ccCountry, ComponentModel.ISupportInitialize).BeginInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).BeginInit()
            CType(ebAddressLine1, ComponentModel.ISupportInitialize).BeginInit()
            CType(ebAddressLine2, ComponentModel.ISupportInitialize).BeginInit()
            CType(ebZipCode, ComponentModel.ISupportInitialize).BeginInit()
            CType(ebCity, ComponentModel.ISupportInitialize).BeginInit()
            CType(ebState, ComponentModel.ISupportInitialize).BeginInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).BeginInit()
            dxContainer.SuspendLayout()
            SuspendLayout()
            ' 
            ' layoutContainer
            ' 
            layoutContainer.AllowFocus = False
            layoutContainer.Controls.Add(ccCountry)
            layoutContainer.Controls.Add(ebAddressLine1)
            layoutContainer.Controls.Add(ebAddressLine2)
            layoutContainer.Controls.Add(ebZipCode)
            layoutContainer.Controls.Add(ebCity)
            layoutContainer.Controls.Add(ebState)
            layoutContainer.Controls.Add(btnAccept)
            layoutContainer.DataContext = viewModelBindingSource
            layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill
            layoutContainer.Location = New System.Drawing.Point(0, 0)
            layoutContainer.Name = "layoutContainer"
            layoutContainer.Size = New System.Drawing.Size(396, 218)
            layoutContainer.TabIndex = 0
            layoutContainer.TabStop = False
            ' 
            ' ccCountry
            ' 
            ccCountry.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "Country", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            ccCountry.Location = New System.Drawing.Point(36, 20)
            ccCountry.Name = "ccCountry"
            ccCountry.Placeholder = "Country*"
            ccCountry.Size = New System.Drawing.Size(324, 23)
            ccCountry.TabIndex = 0
            ' 
            ' viewModelBindingSource
            ' 
            viewModelBindingSource.DataSource = GetType(Address)
            ' 
            ' ebAddressLine1
            ' 
            ebAddressLine1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "AddressLine1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            ebAddressLine1.Location = New System.Drawing.Point(36, 51)
            ebAddressLine1.Name = "ebAddressLine1"
            ebAddressLine1.Placeholder = "Address Line 1*"
            ebAddressLine1.Size = New System.Drawing.Size(324, 20)
            ebAddressLine1.TabIndex = 1
            ' 
            ' ebAddressLine2
            ' 
            ebAddressLine2.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "AddressLine2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            ebAddressLine2.Location = New System.Drawing.Point(36, 79)
            ebAddressLine2.Name = "ebAddressLine2"
            ebAddressLine2.Placeholder = "Address Line 2"
            ebAddressLine2.Size = New System.Drawing.Size(324, 20)
            ebAddressLine2.TabIndex = 2
            ' 
            ' ebZipCode
            ' 
            ebZipCode.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "ZipCode", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            ebZipCode.Location = New System.Drawing.Point(260, 107)
            ebZipCode.MaskSettings.Set("MaskManagerType", GetType(Data.Mask.RegExpMaskManager))
            ebZipCode.MaskSettings.Set("MaskManagerSignature", "isOptimistic=False")
            ebZipCode.MaskSettings.Set("mask", "\d+")
            ebZipCode.Name = "ebZipCode"
            ebZipCode.Placeholder = "ZIP Code"
            ebZipCode.Size = New System.Drawing.Size(100, 20)
            ebZipCode.TabIndex = 5
            ' 
            ' ebCity
            ' 
            ebCity.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "City", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            ebCity.Location = New System.Drawing.Point(36, 107)
            ebCity.Name = "ebCity"
            ebCity.Placeholder = "City*"
            ebCity.Size = New System.Drawing.Size(108, 20)
            ebCity.TabIndex = 3
            ' 
            ' ebState
            ' 
            ebState.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "State", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            ebState.Location = New System.Drawing.Point(152, 107)
            ebState.Name = "ebState"
            ebState.Placeholder = "State"
            ebState.Size = New System.Drawing.Size(100, 20)
            ebState.TabIndex = 4
            ' 
            ' btnAccept
            ' 
            btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK
            btnAccept.Location = New System.Drawing.Point(260, 166)
            btnAccept.Name = "btnAccept"
            btnAccept.Size = New System.Drawing.Size(100, 32)
            btnAccept.TabIndex = 6
            btnAccept.Text = "{Action}"
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
            dxContainer.Size = New System.Drawing.Size(396, 218)
            dxContainer.TabIndex = 0
            dxContainer.TabStop = False
            ' 
            ' AddressForm
            ' 
            AcceptButton = btnAccept
            AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
            ClientSize = New System.Drawing.Size(398, 250)
            Controls.Add(dxContainer)
            DoubleBuffered = True
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "AddressForm"
            Text = "{Title}"
            CType(layoutContainer, ComponentModel.ISupportInitialize).EndInit()
            layoutContainer.ResumeLayout(False)
            CType(ccCountry, ComponentModel.ISupportInitialize).EndInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).EndInit()
            CType(ebAddressLine1, ComponentModel.ISupportInitialize).EndInit()
            CType(ebAddressLine2, ComponentModel.ISupportInitialize).EndInit()
            CType(ebZipCode, ComponentModel.ISupportInitialize).EndInit()
            CType(ebCity, ComponentModel.ISupportInitialize).EndInit()
            CType(ebState, ComponentModel.ISupportInitialize).EndInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).EndInit()
            dxContainer.ResumeLayout(False)
            ResumeLayout(False)

        End Sub

#End Region

        Private layoutContainer As XtraEditors.HtmlContentControl
        Private ccCountry As Collection.Editors.CountryChooser
        Private ebAddressLine1 As Collection.Editors.EditBox
        Private ebAddressLine2 As Collection.Editors.EditBox
        Private ebZipCode As Collection.Editors.EditBox
        Private ebCity As Collection.Editors.EditBox
        Private ebState As Collection.Editors.EditBox
        Private btnAccept As Collection.Editors.Button
        Private mvvmContext As Utils.MVVM.MVVMContext
        Private viewModelBindingSource As System.Windows.Forms.BindingSource
        Private dxContainer As XtraEditors.DirectXFormContainerControl
    End Class
End Namespace
