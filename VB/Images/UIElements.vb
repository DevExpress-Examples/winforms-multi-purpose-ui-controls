Imports System
Imports DevExpress.Utils
Imports DevExpress.Utils.Svg

Namespace DevExpress.UITemplates.Collection.Images

    Public Module UIElements
        Const assetsRoot As String = "UITemplatesExampleVB.Assets."
        <ThreadStatic>
        Private svgImagesCore As SvgImageCollection
        Public ReadOnly Property SvgImages As SvgImageCollection
            Get
                Return If(svgImagesCore, Function()
                                             svgImagesCore = SvgImageCollection.FromResources(assetsRoot & "SVG.UIElements", GetType(UIElements).Assembly)
                                             Return svgImagesCore
                                         End Function())
            End Get
        End Property
#Region "Elements"
        Public ReadOnly Property Check As SvgImage
            Get
                Return UIElements.SvgImages(NameOf(UIElements.Check))
            End Get
        End Property
        Public ReadOnly Property Close As SvgImage
            Get
                Return UIElements.SvgImages(NameOf(UIElements.Close))
            End Get
        End Property
        Public ReadOnly Property Search As SvgImage
            Get
                Return UIElements.SvgImages(NameOf(UIElements.Search))
            End Get
        End Property
        Public ReadOnly Property DropDown As SvgImage
            Get
                Return UIElements.SvgImages(NameOf(UIElements.DropDown))
            End Get
        End Property
        Public ReadOnly Property Show As SvgImage
            Get
                Return UIElements.SvgImages(NameOf(UIElements.Show))
            End Get
        End Property
        Public ReadOnly Property Hide As SvgImage
            Get
                Return UIElements.SvgImages(NameOf(UIElements.Hide))
            End Get
        End Property
        Public ReadOnly Property Copy As SvgImage
            Get
                Return UIElements.SvgImages(NameOf(UIElements.Copy))
            End Get
        End Property
        Public ReadOnly Property Info As SvgImage
            Get
                Return UIElements.SvgImages(NameOf(UIElements.Info))
            End Get
        End Property
#End Region
    End Module
End Namespace
