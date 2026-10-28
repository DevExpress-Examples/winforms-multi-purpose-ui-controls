Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.XtraEditors.Internal
Imports DevExpress.XtraEditors.Mask

Namespace DevExpress.UITemplates.Collection.Forms

    Public Partial Class PaymentForm
        Inherits HtmlFormBase
        Public Sub New()
            InitializeComponent()
            If Not mvvmContext.IsDesignMode Then
                InitializeStyles()
                InitializeEditors()
                InitializeBinding()
            End If
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
        Private Sub InitializeStyles()
            Assets.Button.Apply(btnAccept.HtmlTemplate)
            Assets.Button.Apply(btnDecline.HtmlTemplate)
        End Sub
        Private Sub InitializeEditors()
            Dim nullValuePromptForeColor = Color.FromArgb(55, 102, 191)
            numberBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor
            nameBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor
            validThruMonthBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor
            validThruYearBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor
            cvcBox.Properties.NullValuePromptForeColor = nullValuePromptForeColor

            numberBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(New Padding(6, 3, 0, 0))
            nameBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(New Padding(8, 1, 0, 0))
            validThruMonthBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(New Padding(8, 1, 0, 0))
            validThruYearBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(New Padding(8, 1, 0, 0))
            cvcBox.Properties.MaskBoxPadding = ScaleHelper.ScalePadding(New Padding(5, 2, 0, 0))

            numberBox.Properties.MaskSettings.Configure(Of MaskSettings.Simple)(Sub(x)
                                                                                    x.MaskExpression = "0000 0000 0000 0000"
                                                                                    x.Placeholder = "0"c
                                                                                End Sub)
            validThruMonthBox.Properties.MaskSettings.Configure(Of MaskSettings.DateTime)(Sub(x) x.MaskExpression = "MM")
            validThruYearBox.Properties.MaskSettings.Configure(Of MaskSettings.DateTime)(Sub(x) x.MaskExpression = "yy")
            cvcBox.Properties.MaskSettings.Configure(Of MaskSettings.Simple)(Sub(x)
                                                                                 x.MaskExpression = "000"
                                                                                 x.Placeholder = "0"c
                                                                             End Sub)
        End Sub
        Private Sub InitializeBinding()
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            fluent.SetObjectDataSourceBinding(viewModelBindingSource, Sub(x) x.Validate())
            fluent.SetBinding(Me, Function(frm) frm.Text, Function(x) x.Title)
            fluent.SetBinding(btnAccept, Function(btn) btn.Text, Function(x) x.AcceptCaption)
            fluent.SetBinding(btnDecline, Function(btn) btn.Text, Function(x) x.DeclineCaption)
            fluent.BindCommand(btnAccept, Sub(x) x.Accept())
            fluent.BindCommand(btnDecline, Sub(x) x.Decline())
        End Sub
        Public Class ViewModel
            Implements ISupportParameter
            Public Sub New()
                Card = New Collection.Utilities.PaymentCard(Nothing, Date.Now, String.Empty)
            End Sub
            Public ReadOnly Property Title As String
                Get
                    Return "PAYMENT DETAILS"
                End Get
            End Property
            Public ReadOnly Property AcceptCaption As String
                Get
                    Return "Confirm and Pay"
                End Get
            End Property
            Public ReadOnly Property DeclineCaption As String
                Get
                    Return "Cancel"
                End Get
            End Property
            Private Property Parameter As Object Implements ISupportParameter.Parameter
                Get
                    Return Card
                End Get
                Set(value As Object)
                    Card = TryCast(value, Collection.Utilities.PaymentCard)
                End Set
            End Property

            Public Overridable Property Card As Collection.Utilities.PaymentCard
            Public Overridable Property CardNumber As String
            Public Overridable Property CardHolder As String
            Public Overridable Property ValidThruMonth As String
            Public Overridable Property ValidThruYear As String
            Public Overridable Property CVC As String
            Public Sub Validate()
                Card = New Collection.Utilities.PaymentCard(CardNumber, ValidThruMonth, ValidThruYear, CVC)
                RaiseCanExecuteChanged(Sub(x) x.Accept())
            End Sub
            Public Function CanAccept() As Boolean
                Dim cardType = Collection.Utilities.PaymentCardType.Validate(If(Card?.Number, String.Empty))
                If cardType = Collection.Utilities.PaymentCard.Type.Invalid Then Return False
                If Card.ExpirationDate < Date.Now.Date Then Return False
                If If(Card.CVC, String.Empty).Length <> 3 Then Return False
                Return Not String.IsNullOrEmpty(CardHolder)
            End Function
            Public Sub Accept()
                ' do start payment procedure with current PaymentCard data 
            End Sub
            Public Sub Decline()
                ' do some cleanup here 
            End Sub
        End Class
#Region "Theme"
        Protected Overrides Function LoadDefaultTemplate() As String
            Return Assets.Form.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return Assets.Form.Css
        End Function
        Protected Overrides Function LoadDefaultLayoutTemplate() As String
            Return Assets.Layout.Html
        End Function
        Protected Overrides Function LoadDefaultLayoutStyles() As String
            Return Assets.Layout.Css
        End Function
        Public Class Assets
            Public Shared Form As Collection.Utilities.HtmlCssAsset = New PaymentFormHtmlCssAsset()
            Public Shared Layout As Collection.Utilities.HtmlCssAsset = New PaymentFormLayoutHtmlCssAsset()
            Public Shared Button As Collection.Utilities.HtmlCssAsset = New PaymentFormButtonHtmlCssAsset()
            '
            Friend NotInheritable Class PaymentFormHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
            Friend NotInheritable Class PaymentFormLayoutHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
            Friend NotInheritable Class PaymentFormButtonHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
        End Class
#End Region
    End Class
End Namespace
