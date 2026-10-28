Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Forms

    Public Partial Class LoginForm
        Inherits HtmlFormBase
        Public Sub New()
            InitializeComponent()
            If Not mvvmContext.IsDesignMode Then InitializeBinding()
        End Sub
        <ComponentModel.Category("Data"), ComponentModel.Browsable(False)>
        Public ReadOnly Property IsAuthorizationComplete As Boolean
            Get
                Return LoginStatus = Status.AuthorizationComplete
            End Get
        End Property
        <ComponentModel.Category("Data"), ComponentModel.Browsable(False)>
        Public ReadOnly Property LoginStatus As Status
            Get
                Return If(GetViewModel()?.Status, Status.Unknown)
            End Get
        End Property
        Private Function GetViewModel() As ViewModel
            Return mvvmContext.OfType(Of ViewModel)().ViewModel
        End Function
        Private Sub InitializeBinding()
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, Sub(x) x.Validate())
            fluent.SetBinding(Me, Function(frm) frm.Text, Function(x) x.Title)
            fluent.SetBinding(btnLogin, Function(btn) btn.Text, Function(x) x.Action)
            fluent.BindCommandToElement(layoutContainer, "recoveryLink", Sub(x) x.Recover())
            fluent.BindCommandToElement(layoutContainer, "registerLink", Sub(x) x.Register())
            fluent.BindCommand(btnLogin, Sub(x) x.LogIn())
        End Sub
        Public Enum Status
            Unknown
            AuthorizationComplete
            AuthorizationFailed
            RecoveryRequested
            RegistrationRequested
        End Enum
        Public Class ViewModel
            Public ReadOnly Property Title As String
                Get
                    Return "Log In"
                End Get
            End Property
            Public ReadOnly Property Action As String
                Get
                    Return "Log In"
                End Get
            End Property
            Public ReadOnly Property RecoveryLink As String
                Get
                    Return "Forgot the password?"
                End Get
            End Property
            Public ReadOnly Property RegisterLink As String
                Get
                    Return "Create an account"
                End Get
            End Property
            Public Overridable Property Email As String
            Public Overridable Property Password As String

            Public Overridable Property Status As Status
            Protected Overridable Sub OnStatusChanged()
                Validate()
            End Sub
            Private isLoginDataValid As Boolean
            Public Sub Validate()
                isLoginDataValid = Collection.Utilities.Email.Validate(Email) AndAlso Not String.IsNullOrEmpty(Password)
                RaiseCanExecuteChanged(Sub(x) x.Register())
                RaiseCanExecuteChanged(Sub(x) x.LogIn())
            End Sub
            Public Sub Recover()
                Status = Status.RecoveryRequested
                ' start recovery routine 
                CloseWindow()
            End Sub
            Public Function CanRegister() As Boolean
                Return Status = Status.Unknown AndAlso isLoginDataValid
            End Function
            Public Sub Register()
                Status = Status.RegistrationRequested
                ' start registration routine with current Email/Password 
                CloseWindow()
            End Sub
            Public Function CanLogIn() As Boolean
                Return Status = Status.Unknown AndAlso isLoginDataValid
            End Function
            Public Sub LogIn()
                Status = If(QueryAuthorization(), Status.AuthorizationComplete, Status.AuthorizationFailed)
            End Sub
            Private Function QueryAuthorization() As Boolean
                ' do authorization request with current Email/Password 
                Return True
            End Function
            Private Sub CloseWindow()
                Dim currentWindow = GetService(Of ICurrentWindowService)()
                If currentWindow IsNot Nothing Then currentWindow.Close()
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
        Public NotInheritable Class Assets
            Public Shared Layout As Collection.Utilities.HtmlCssAsset = New LoginFormLayoutHtmlCssAsset()
            '
            Friend NotInheritable Class LoginFormLayoutHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
        End Class
#End Region
    End Class
End Namespace
