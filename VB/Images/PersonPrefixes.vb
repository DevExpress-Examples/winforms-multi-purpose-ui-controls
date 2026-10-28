Imports System
Imports DevExpress.Utils
Imports DevExpress.Utils.Svg

Namespace DevExpress.UITemplates.Collection.Images

    Public Module PersonPrefixes
        Const assetsRoot As String = "UITemplatesExampleVB.Assets."
        <ThreadStatic>
        Private svgImagesCore As SvgImageCollection
        Public ReadOnly Property SvgImages As SvgImageCollection
            Get
                Return If(svgImagesCore, Function()
                                             svgImagesCore = SvgImageCollection.FromResources(assetsRoot & "SVG.PersonPrefixes", GetType(PersonPrefixes).Assembly)
                                             Return svgImagesCore
                                         End Function())
            End Get
        End Property
        Public ReadOnly Property Mr As SvgImage
            Get
                Return SvgImages(NameOf(PersonPrefixes.Mr))
            End Get
        End Property
        Public ReadOnly Property Mrs As SvgImage
            Get
                Return SvgImages(NameOf(PersonPrefixes.Mrs))
            End Get
        End Property
        Public ReadOnly Property Ms As SvgImage
            Get
                Return SvgImages(NameOf(PersonPrefixes.Ms))
            End Get
        End Property
        Public ReadOnly Property Miss As SvgImage
            Get
                Return SvgImages(NameOf(PersonPrefixes.Miss))
            End Get
        End Property
        Public ReadOnly Property Doctor As SvgImage
            Get
                Return SvgImages(NameOf(PersonPrefixes.Doctor))
            End Get
        End Property
    End Module
End Namespace
