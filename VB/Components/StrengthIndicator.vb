Imports System.Drawing
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Components

    Public NotInheritable Class StrengthIndicator
        Inherits ProgressIndicatorBase
        Public Shared Sub Register()
            DxHtmlDocument.Define(Of StrengthIndicator)("strength-indicator")
        End Sub
        '
        Public ReadOnly Property WeakColor As String
            Get
                Return If(TryCast(GetAttribute(NameOf(StrengthIndicator.WeakColor)), String), "@Red")
            End Get
        End Property
        Public ReadOnly Property MediumColor As String
            Get
                Return If(TryCast(GetAttribute(NameOf(StrengthIndicator.MediumColor)), String), "@Orange")
            End Get
        End Property
        Public ReadOnly Property StrongColor As String
            Get
                Return If(TryCast(GetAttribute(NameOf(StrengthIndicator.StrongColor)), String), "@Green")
            End Get
        End Property
        Public ReadOnly Property BackgroundColor As String
            Get
                Return If(TryCast(GetAttribute(NameOf(StrengthIndicator.BackgroundColor)), String), "@Gray")
            End Get
        End Property
        Public Overrides Sub AttributeChangedCallback(attributeName As String)
            MyBase.AttributeChangedCallback(attributeName)
            If Equals(attributeName, "value") Then UpdateIndicator(MaxValue - MinValue, Value - MinValue)
        End Sub
        Protected Overrides Sub UpdateBackground(range As Double, value As Double, element As DxHtmlElement)
            If value > 0 Then
                element.Style.SetBackgroundColor(BackgroundColor)
            Else
                element.Style.SetBackgroundColor(Color.Empty)
            End If
        End Sub
        Protected Overrides Sub UpdateProgress(range As Double, value As Double, element As DxHtmlElement)
            If value > 0 Then
                If value < range * 0.333 Then
                    element.Style.SetBackgroundColor(WeakColor)
                Else
                    If value < range * 0.666 Then
                        element.Style.SetBackgroundColor(MediumColor)
                    Else
                        element.Style.SetBackgroundColor(StrongColor)
                    End If
                End If
                Dim progress = Math.Round(100 * (value / range))
                element.Style.SetProperty("width", progress.ToString() & "%")
            Else
                element.Style.SetBackgroundColor(Color.Empty)
            End If
        End Sub
    End Class
End Namespace
