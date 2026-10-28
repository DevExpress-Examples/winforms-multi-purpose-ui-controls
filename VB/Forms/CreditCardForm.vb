Imports System
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Mvvm.POCO
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Forms

    Public Partial Class CreditCardForm
        Inherits HtmlFormBase
        Public Sub New()
            InitializeComponent()
            If Not mvvmContext.IsDesignMode Then InitializeBinding()
        End Sub
        <ComponentModel.Category("Data"), ComponentModel.Browsable(False)>
        Public ReadOnly Property Card As Collection.Utilities.PaymentCard
            Get
                Return If(GetViewModel()?.Card, Collection.Utilities.PaymentCard.EmptyCard)
            End Get
        End Property
        <ComponentModel.Category("Data"), ComponentModel.Browsable(False)>
        Public ReadOnly Property CardHolder As String
            Get
                Return If(GetViewModel()?.CardHolder, String.Empty)
            End Get
        End Property
        Private Function GetViewModel() As ViewModel
            Return mvvmContext.OfType(Of ViewModel)().ViewModel
        End Function
        Private Sub InitializeBinding()
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, Sub(x) x.Validate())
            fluent.SetBinding(Me, Function(frm) frm.Text, Function(x) x.Title)
            fluent.SetBinding(btnAdd, Function(btn) btn.Text, Function(x) x.Action)
            fluent.BindCommand(btnAdd, Sub(x) x.AddCard())
        End Sub
        Public Class ViewModel
            Public ReadOnly Property Title As String
                Get
                    Return "Add Card"
                End Get
            End Property
            Public ReadOnly Property Action As String
                Get
                    Return "Add Card"
                End Get
            End Property
            Public ReadOnly Property CardNumber As String
                Get
                    Return If(Card?.NumberMasked, "0000 0000 0000 0000")
                End Get
            End Property
            Public ReadOnly Property HolderName As String
                Get
                    Return If(Not String.IsNullOrEmpty(CardHolder), CardHolder, "CARD HOLDER")
                End Get
            End Property
            Public ReadOnly Property ValidThru As String
                Get
                    Return If((Card?.ExpirationDate)?.ToString("MM/yy"), "MM/YY")
                End Get
            End Property
            Public Overridable Property Card As Collection.Utilities.PaymentCard
            Public Overridable Property CardHolder As String
            Public Sub Validate()
                RaisePropertyChanged(Function(x) x.CardNumber)
                RaisePropertyChanged(Function(x) x.HolderName)
                RaisePropertyChanged(Function(x) x.ValidThru)
                RaiseCanExecuteChanged(Sub(x) x.AddCard())
            End Sub
            Public Function CanAddCard() As Boolean
                Dim cardType = Collection.Utilities.PaymentCardType.Validate(If(Card?.Number, String.Empty))
                If cardType = Collection.Utilities.PaymentCard.Type.Invalid Then Return False
                If Card.ExpirationDate < Date.Now.Date Then Return False
                If If(Card.CVC, String.Empty).Length <> 3 Then Return False
                Return Not String.IsNullOrEmpty(CardHolder)
            End Function
            Public Sub AddCard()
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
            Public Shared Layout As Collection.Utilities.HtmlCssAsset = New CreditCardFormLayoutHtmlCssAsset()
            '
            Friend NotInheritable Class CreditCardFormLayoutHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
        End Class
#End Region
    End Class
End Namespace
