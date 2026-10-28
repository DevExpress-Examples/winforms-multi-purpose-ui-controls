Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Components

    Public MustInherit Class ProgressIndicatorBase
        Inherits DxHtmlComponent
        Public ReadOnly Property MinValue As Double
            Get
                Return GetDouble(NameOf(ProgressIndicatorBase.MinValue), 0)
            End Get
        End Property
        Public ReadOnly Property MaxValue As Double
            Get
                Return GetDouble(NameOf(ProgressIndicatorBase.MaxValue), 1.0)
            End Get
        End Property
        Public ReadOnly Property Value As Double
            Get
                Return GetDouble(NameOf(ProgressIndicatorBase.Value), 0)
            End Get
        End Property
        Protected Function GetDouble(name As String, defaultValue As Double) As Double
            Dim value As Double
            Return If(Double.TryParse(If(TryCast(GetAttribute(name), String), String.Empty), value), value, defaultValue)
        End Function
        Protected Overridable Function GetDefaultHeight() As String
            Return "2px"
        End Function
        Private Function CalcOwnHeight() As String
            Dim height = Element.GetComputedStyle().Height
            Return If(height.IsEmpty, GetDefaultHeight(), height.ToString())
        End Function
        Private bgElement, progressElement As DxHtmlElement
        Public Overrides Sub ConnectedCallback()
            MyBase.ConnectedCallback()
            Dim range = MaxValue - MinValue, value = Me.Value - MinValue
            Dim progress = Math.Round(100 * (value / range))
            Dim ownHeight As String = CalcOwnHeight()
            bgElement = CreateBackground(ownHeight)
            progressElement = CreateProgress(progress, ownHeight)
            UpdateBackground(range, value, bgElement)
            UpdateProgress(range, value, progressElement)
            AppendChild(bgElement)
            AppendChild(progressElement)
        End Sub
        Public Overrides Sub DisconnectedCallback()
            MyBase.DisconnectedCallback()
            progressElement = Nothing
            bgElement = progressElement
        End Sub
        Protected Overridable Function CreateBackground(ownHeight As String) As DxHtmlElement
            Dim bgElement = DxHtmlDocument.CreateElement("div")
            bgElement.Style.SetProperty("width", "100%")
            bgElement.Style.SetProperty("height", ownHeight)
            Return bgElement
        End Function
        Protected Overridable Function CreateProgress(progress As Double, ownHeight As String) As DxHtmlElement
            Dim progressElement = DxHtmlDocument.CreateElement("div")
            progressElement.Style.SetProperty("width", progress.ToString() & "%")
            progressElement.Style.SetProperty("height", ownHeight)
            progressElement.Style.SetProperty("margin-top", "-" & ownHeight)
            Return progressElement
        End Function
        Protected Sub UpdateIndicator(range As Double, value As Double)
            If bgElement IsNot Nothing Then UpdateBackground(range, value, bgElement)
            If progressElement IsNot Nothing Then UpdateProgress(range, value, progressElement)
        End Sub
        Protected MustOverride Sub UpdateBackground(range As Double, value As Double, element As DxHtmlElement)
        Protected MustOverride Sub UpdateProgress(range As Double, value As Double, element As DxHtmlElement)

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
