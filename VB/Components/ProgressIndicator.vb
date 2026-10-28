Imports System.Drawing
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Components

    Public NotInheritable Class ProgressIndicator
        Inherits Components.ProgressIndicatorBase
        Public Shared Sub Register()
            DxHtmlDocument.Define(Of ProgressIndicator)("progress-indicator")
        End Sub
        '
        Public ReadOnly Property ProgressColor As String
            Get
                Return If(TryCast(MyBase.GetAttribute(NameOf(ProgressIndicator.ProgressColor)), String), "@Green")
            End Get
        End Property
        Public ReadOnly Property BackColor As String
            Get
                Return If(TryCast(MyBase.GetAttribute(NameOf(ProgressIndicator.BackColor)), String), "@ControlText/0.3")
            End Get
        End Property
        Public Overrides Sub AttributeChangedCallback(attributeName As String)
            MyBase.AttributeChangedCallback(attributeName)
            If Equals(attributeName, "value") Then MyBase.UpdateIndicator(MyBase.MaxValue - MyBase.MinValue, MyBase.Value - MyBase.MinValue)
        End Sub
        Protected Overrides Sub UpdateBackground(range As Double, value As Double, element As DxHtmlElement)
            If value > 0 Then
                element.Style.SetBackgroundColor(BackColor)
                element.Style.SetProperty("border-radius", "1px")
            Else
                element.Style.SetBackgroundColor(Color.Empty)
            End If
        End Sub
        Protected Overrides Sub UpdateProgress(range As Double, value As Double, element As DxHtmlElement)
            If value > 0 Then
                element.Style.SetBackgroundColor(ProgressColor)
                Dim progress = Math.Round(100 * (value / range))
                element.Style.SetProperty("width", progress.ToString() & "%")
                element.Style.SetProperty("border-radius", "1px")
                element.Style.SetProperty("box-shadow", "0px 0px 4px " & ProgressColor & "/0.4")
            Else
                element.Style.SetBackgroundColor(Color.Empty)
            End If
        End Sub
    End Class
End Namespace
