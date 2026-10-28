Namespace DevExpress.UITemplates.Collection.Forms
    Partial Class PaymentForm
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
            numberBox = New XtraEditors.TextEdit()
            nameBox = New XtraEditors.TextEdit()
            validThruMonthBox = New XtraEditors.TextEdit()
            validThruYearBox = New XtraEditors.TextEdit()
            cvcBox = New XtraEditors.TextEdit()
            viewModelBindingSource = New System.Windows.Forms.BindingSource(components)
            btnAccept = New Collection.Editors.Button()
            btnDecline = New Collection.Editors.Button()
            mvvmContext = New Utils.MVVM.MVVMContext(components)
            dxContainer = New XtraEditors.DirectXFormContainerControl()
            CType(layoutContainer, ComponentModel.ISupportInitialize).BeginInit()
            layoutContainer.SuspendLayout()
            CType(numberBox.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(nameBox.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(validThruMonthBox.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(validThruYearBox.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(cvcBox.Properties, ComponentModel.ISupportInitialize).BeginInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).BeginInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).BeginInit()
            dxContainer.SuspendLayout()
            SuspendLayout()
            ' 
            ' layoutContainer
            ' 
            layoutContainer.AllowFocus = False
            layoutContainer.Appearance.BackColor = System.Drawing.Color.Transparent
            layoutContainer.Appearance.Options.UseBackColor = True
            layoutContainer.Controls.Add(numberBox)
            layoutContainer.Controls.Add(nameBox)
            layoutContainer.Controls.Add(validThruMonthBox)
            layoutContainer.Controls.Add(validThruYearBox)
            layoutContainer.Controls.Add(cvcBox)
            layoutContainer.Controls.Add(btnAccept)
            layoutContainer.Controls.Add(btnDecline)
            layoutContainer.DataContext = viewModelBindingSource
            layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill
            layoutContainer.Location = New System.Drawing.Point(0, 0)
            layoutContainer.Name = "layoutContainer"
            layoutContainer.Size = New System.Drawing.Size(398, 408)
            layoutContainer.TabIndex = 0
            layoutContainer.TabStop = False
            ' 
            ' numberBox
            ' 
            numberBox.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "CardNumber", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            numberBox.Location = New System.Drawing.Point(35, 109)
            numberBox.Name = "numberBox"
            numberBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption
            numberBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(30, 79, 168)
            numberBox.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)
            numberBox.Properties.Appearance.ForeColor = System.Drawing.Color.White
            numberBox.Properties.Appearance.Options.UseBackColor = True
            numberBox.Properties.Appearance.Options.UseFont = True
            numberBox.Properties.Appearance.Options.UseForeColor = True
            numberBox.Properties.Appearance.Options.UseTextOptions = True
            numberBox.Properties.Appearance.TextOptions.VAlignment = Utils.VertAlignment.Center
            numberBox.Properties.AutoHeight = False
            numberBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
            numberBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            numberBox.Properties.NullValuePrompt = "0000 0000 0000 0000"
            numberBox.Properties.UseAdvancedMode = Utils.DefaultBoolean.True
            numberBox.Properties.UseMaskAsDisplayFormat = True
            numberBox.Size = New System.Drawing.Size(240, 28)
            numberBox.TabIndex = 1
            ' 
            ' nameBox
            ' 
            nameBox.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "CardHolder", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            nameBox.Location = New System.Drawing.Point(35, 109)
            nameBox.Name = "nameBox"
            nameBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption
            nameBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(30, 79, 168)
            nameBox.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)
            nameBox.Properties.Appearance.ForeColor = System.Drawing.Color.White
            nameBox.Properties.Appearance.Options.UseBackColor = True
            nameBox.Properties.Appearance.Options.UseFont = True
            nameBox.Properties.Appearance.Options.UseForeColor = True
            nameBox.Properties.Appearance.Options.UseTextOptions = True
            nameBox.Properties.Appearance.TextOptions.VAlignment = Utils.VertAlignment.Center
            nameBox.Properties.AutoHeight = False
            nameBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
            nameBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            nameBox.Properties.NullValuePrompt = "CARD HOLDER"
            nameBox.Properties.UseAdvancedMode = Utils.DefaultBoolean.True
            nameBox.Properties.UseMaskAsDisplayFormat = True
            nameBox.Size = New System.Drawing.Size(240, 28)
            nameBox.TabIndex = 2
            ' 
            ' validThruMonthBox
            ' 
            validThruMonthBox.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "ValidThruMonth", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            validThruMonthBox.Location = New System.Drawing.Point(35, 109)
            validThruMonthBox.Name = "validThruMonthBox"
            validThruMonthBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption
            validThruMonthBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(30, 79, 168)
            validThruMonthBox.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)
            validThruMonthBox.Properties.Appearance.ForeColor = System.Drawing.Color.White
            validThruMonthBox.Properties.Appearance.Options.UseBackColor = True
            validThruMonthBox.Properties.Appearance.Options.UseFont = True
            validThruMonthBox.Properties.Appearance.Options.UseForeColor = True
            validThruMonthBox.Properties.Appearance.Options.UseTextOptions = True
            validThruMonthBox.Properties.Appearance.TextOptions.VAlignment = Utils.VertAlignment.Center
            validThruMonthBox.Properties.AutoHeight = False
            validThruMonthBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            validThruMonthBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
            validThruMonthBox.Properties.NullValuePrompt = "MM"
            validThruMonthBox.Properties.UseAdvancedMode = Utils.DefaultBoolean.True
            validThruMonthBox.Properties.UseMaskAsDisplayFormat = True
            validThruMonthBox.Size = New System.Drawing.Size(48, 28)
            validThruMonthBox.TabIndex = 3
            ' 
            ' validThruYearBox
            ' 
            validThruYearBox.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "ValidThruYear", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            validThruYearBox.Location = New System.Drawing.Point(35, 109)
            validThruYearBox.Name = "validThruYearBox"
            validThruYearBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption
            validThruYearBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(30, 79, 168)
            validThruYearBox.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)
            validThruYearBox.Properties.Appearance.ForeColor = System.Drawing.Color.White
            validThruYearBox.Properties.Appearance.Options.UseBackColor = True
            validThruYearBox.Properties.Appearance.Options.UseFont = True
            validThruYearBox.Properties.Appearance.Options.UseForeColor = True
            validThruYearBox.Properties.Appearance.Options.UseTextOptions = True
            validThruYearBox.Properties.Appearance.TextOptions.VAlignment = Utils.VertAlignment.Center
            validThruYearBox.Properties.AutoHeight = False
            validThruYearBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
            validThruYearBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            validThruYearBox.Properties.NullValuePrompt = "YY"
            validThruYearBox.Properties.UseAdvancedMode = Utils.DefaultBoolean.True
            validThruYearBox.Properties.UseMaskAsDisplayFormat = True
            validThruYearBox.Size = New System.Drawing.Size(48, 28)
            validThruYearBox.TabIndex = 4
            ' 
            ' cvcBox
            ' 
            cvcBox.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", viewModelBindingSource, "CVC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            cvcBox.Location = New System.Drawing.Point(35, 109)
            cvcBox.Name = "cvcBox"
            cvcBox.Properties.AdvancedModeOptions.SelectionColor = System.Drawing.SystemColors.ActiveCaption
            cvcBox.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(30, 79, 168)
            cvcBox.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)
            cvcBox.Properties.Appearance.ForeColor = System.Drawing.Color.White
            cvcBox.Properties.Appearance.Options.UseBackColor = True
            cvcBox.Properties.Appearance.Options.UseFont = True
            cvcBox.Properties.Appearance.Options.UseForeColor = True
            cvcBox.Properties.Appearance.Options.UseTextOptions = True
            cvcBox.Properties.Appearance.TextOptions.VAlignment = Utils.VertAlignment.Center
            cvcBox.Properties.AutoHeight = False
            cvcBox.Properties.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
            cvcBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            cvcBox.Properties.NullValuePrompt = "000"
            cvcBox.Properties.UseAdvancedMode = Utils.DefaultBoolean.True
            cvcBox.Properties.UseMaskAsDisplayFormat = True
            cvcBox.Size = New System.Drawing.Size(48, 28)
            cvcBox.TabIndex = 5
            ' 
            ' viewModelBindingSource
            ' 
            viewModelBindingSource.DataSource = GetType(ViewModel)
            ' 
            ' btnAccept
            ' 
            btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK
            btnAccept.Location = New System.Drawing.Point(119, 299)
            btnAccept.Name = "btnAccept"
            btnAccept.Size = New System.Drawing.Size(160, 23)
            btnAccept.TabIndex = 6
            btnAccept.Text = "{Accept}"
            ' 
            ' btnDecline
            ' 
            btnDecline.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnDecline.Location = New System.Drawing.Point(119, 299)
            btnDecline.Name = "btnDecline"
            btnDecline.Size = New System.Drawing.Size(160, 23)
            btnDecline.TabIndex = 7
            btnDecline.Text = "{Decline}"
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
            dxContainer.Size = New System.Drawing.Size(398, 408)
            dxContainer.TabIndex = 0
            dxContainer.TabStop = False
            ' 
            ' PaymentForm
            ' 
            AcceptButton = btnAccept
            CancelButton = btnDecline
            AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
            ClientSize = New System.Drawing.Size(550, 410)
            Controls.Add(dxContainer)
            DoubleBuffered = True
            FormBorderEffect = XtraEditors.FormBorderEffect.None
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "PaymentForm"
            Text = "{Title}"
            CType(layoutContainer, ComponentModel.ISupportInitialize).EndInit()
            layoutContainer.ResumeLayout(False)
            CType(numberBox.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(nameBox.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(validThruMonthBox.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(validThruYearBox.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(cvcBox.Properties, ComponentModel.ISupportInitialize).EndInit()
            CType(viewModelBindingSource, ComponentModel.ISupportInitialize).EndInit()
            CType(mvvmContext, ComponentModel.ISupportInitialize).EndInit()
            dxContainer.ResumeLayout(False)
            ResumeLayout(False)

        End Sub

#End Region

        Private layoutContainer As XtraEditors.HtmlContentControl
        Private numberBox As XtraEditors.TextEdit
        Private nameBox As XtraEditors.TextEdit
        Private validThruMonthBox As XtraEditors.TextEdit
        Private validThruYearBox As XtraEditors.TextEdit
        Private cvcBox As XtraEditors.TextEdit
        Private btnAccept As Collection.Editors.Button
        Private btnDecline As Collection.Editors.Button
        Private mvvmContext As Utils.MVVM.MVVMContext
        Private viewModelBindingSource As System.Windows.Forms.BindingSource
        Private dxContainer As XtraEditors.DirectXFormContainerControl
    End Class
End Namespace
