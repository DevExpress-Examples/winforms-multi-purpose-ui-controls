Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Mvvm.POCO
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Forms

    Public Partial Class PasswordForm
        Inherits HtmlFormBase
        Public Sub New()
            InitializeComponent()
            If Not mvvmContext.IsDesignMode Then InitializeBinding()
        End Sub
        <ComponentModel.Category("Data"), ComponentModel.Browsable(False)>
        Public ReadOnly Property Password As String
            Get
                Return If(mvvmContext.OfType(Of ViewModel)().ViewModel?.Password, String.Empty)
            End Get
        End Property
        Private Sub InitializeBinding()
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, Sub(x) x.Validate())
            fluent.SetBinding(Me, Function(frm) frm.Text, Function(x) x.Title)
            fluent.SetBinding(btnChange, Function(btn) btn.Text, Function(x) x.Action)
            fluent.SetBinding(tbConfirmPassword, Function(pwd) pwd.ErrorText, Function(x) x.ConfirmedPasswordError)
            fluent.BindCommand(btnChange, Sub(x) x.ChangePassword())
        End Sub
        Public Class ViewModel
            Public ReadOnly Property Title As String
                Get
                    Return "Create Password"
                End Get
            End Property
            Public ReadOnly Property Subject As String
                Get
                    Return "Please create a password you haven't used before."
                End Get
            End Property
            Public ReadOnly Property Action As String
                Get
                    Return "Create Password"
                End Get
            End Property
            Public Overridable Property Password As String
            Public Overridable Property ConfirmedPassword As String
            Public Overridable Property ConfirmedPasswordError As String
            Public Sub Validate()
                If Not String.IsNullOrEmpty(ConfirmedPassword) AndAlso Not String.IsNullOrEmpty(Password) AndAlso Not Equals(ConfirmedPassword, Password) Then
                    ConfirmedPasswordError = "Passwords do not match."
                Else
                    ConfirmedPasswordError = String.Empty
                End If
                RaiseCanExecuteChanged(Sub(x) x.ChangePassword())
            End Sub
            Public Function CanChangePassword() As Boolean
                If String.IsNullOrEmpty(Password) Then Return False
                If String.IsNullOrEmpty(ConfirmedPassword) Then Return False
                If Not Equals(ConfirmedPassword, Password) Then Return False
                Return Collection.Utilities.Password.Check(Password) >= Collection.Utilities.Password.Strength.Medium
            End Function
            Public Sub ChangePassword()
                ' do something 
            End Sub
        End Class
#Region "Theme"
        Protected Overrides Function LoadDefaultHtmlImages() As Object
            Return Forms.Base.FormAssets.DefaultHtmlImages
        End Function
        Protected Overrides Function LoadDefaultTemplate() As String
            Return Forms.Base.FormAssets.FixedDialog.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return Forms.Base.FormAssets.FixedDialog.Css
        End Function
        Protected Overrides Function LoadDefaultLayoutTemplate() As String
            Return Assets.Layout.Html
        End Function
        Protected Overrides Function LoadDefaultLayoutStyles() As String
            Return Assets.Layout.Css
        End Function
        Public Class Assets
            Public Shared Layout As Collection.Utilities.HtmlCssAsset = New PasswordFormLayoutHtmlCssAsset()
            '
            Friend NotInheritable Class PasswordFormLayoutHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
        End Class
#End Region
    End Class
End Namespace
