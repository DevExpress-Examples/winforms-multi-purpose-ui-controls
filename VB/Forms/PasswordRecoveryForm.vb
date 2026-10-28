Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Forms

    Public Partial Class PasswordRecoveryForm
        Inherits HtmlFormBase
        Public Sub New()
            InitializeComponent()
            If Not mvvmContext.IsDesignMode Then InitializeBinding()
        End Sub
        <ComponentModel.Category("Data"), ComponentModel.Browsable(False)>
        Public ReadOnly Property Email As String
            Get
                Return If(mvvmContext.OfType(Of ViewModel)().ViewModel?.Email, String.Empty)
            End Get
        End Property
        Private Sub InitializeBinding()
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, Sub(x) x.Validate())
            fluent.SetBinding(Me, Function(frm) frm.Text, Function(x) x.Title)
            fluent.SetBinding(btnRecover, Function(btn) btn.Text, Function(x) x.Action)
            fluent.BindCommand(btnRecover, Sub(x) x.Recover())
        End Sub
        Public Class ViewModel
            Public ReadOnly Property Title As String
                Get
                    Return "Account Recovery"
                End Get
            End Property
            Public ReadOnly Property Subject As String
                Get
                    Return "Please enter your email to recover your account."
                End Get
            End Property
            Public ReadOnly Property Action As String
                Get
                    Return "Get Password"
                End Get
            End Property
            Public Overridable Property Email As String
            Private IsEmailValid As Boolean
            Public Sub Validate()
                IsEmailValid = Collection.Utilities.Email.Validate(Email)
                RaiseCanExecuteChanged(Sub(x) x.Recover())
            End Sub
            Public Function CanRecover() As Boolean
                Return IsEmailValid
            End Function
            Public Sub Recover()
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
            Public Shared Layout As Collection.Utilities.HtmlCssAsset = New PasswordRecoveryFormLayoutHtmlCssAsset()
            '
            Friend NotInheritable Class PasswordRecoveryFormLayoutHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
        End Class
#End Region
    End Class
End Namespace
