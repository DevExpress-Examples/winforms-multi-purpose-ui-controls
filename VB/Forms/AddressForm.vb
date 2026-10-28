Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Mvvm.POCO
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Forms

    Public Partial Class AddressForm
        Inherits HtmlFormBase
        Public Sub New()
            InitializeComponent()
            If Not mvvmContext.IsDesignMode Then InitializeBinding()
        End Sub
        <ComponentModel.Browsable(False)>
        <ComponentModel.Category("Data")>
        Public ReadOnly Property Result As Address
            Get
                Return mvvmContext.OfType(Of ViewModel)().ViewModel?.Address
            End Get
        End Property
        Private Sub InitializeBinding()
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            fluent.SetObjectDataSourceBinding(
                viewModelBindingSource,
                Function(x) x.Address,
                Sub(x) x.Validate())
            fluent.SetBinding(Me, Function(frm) frm.Text, Function(x) x.Title)
            fluent.SetBinding(btnAccept, Function(btn) btn.Text, Function(x) x.Action)
            fluent.BindCommand(btnAccept, Sub(x) x.Accept())
        End Sub
        Public Class Address
            <Required(AllowEmptyStrings:=False)>
            Public Overridable Property Country As String
            <Required(AllowEmptyStrings:=False)>
            Public Overridable Property AddressLine1 As String
            Public Overridable Property AddressLine2 As String
            <Required(AllowEmptyStrings:=False)>
            Public Overridable Property City As String
            Public Overridable Property ZipCode As String
            Public Overridable Property State As String
        End Class
        Public Class ViewModel
            Private _Address As DevExpress.UITemplates.Collection.Forms.AddressForm.Address
            Private ReadOnly validationContext As ValidationContext
            Private ReadOnly validationResults As List(Of ValidationResult)
            Public Sub New()
                Address = New Address()
                validationContext = New ValidationContext(Address)
                validationResults = New List(Of ValidationResult)()
            End Sub
            Public ReadOnly Property Title As String
                Get
                    Return "New Address"
                End Get
            End Property
            Public ReadOnly Property Action As String
                Get
                    Return "Accept"
                End Get
            End Property

            Public Property Address As Address
                Get
                    Return _Address
                End Get
                Private Set(value As Address)
                    _Address = value
                End Set
            End Property
            Public Sub Validate()
                Dim wasValid = validationResults.Count = 0
                If wasValid <> ValidateAddress() Then RaiseCanExecuteChanged(Sub(x) x.Accept())
            End Sub
            Private Function ValidateAddress() As Boolean
                validationResults.Clear()
                Return Validator.TryValidateObject(Address, validationContext, validationResults) AndAlso validationResults.Count = 0
            End Function
            Public Function CanAccept() As Boolean
                Return ValidateAddress()
            End Function
            Public Sub Accept()
                ' do something if required 
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
            Public Shared Layout As Collection.Utilities.HtmlCssAsset = New AddressFormLayoutHtmlCssAsset()
            '
            Friend NotInheritable Class AddressFormLayoutHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
        End Class
#End Region
    End Class
End Namespace
