Imports System
Imports DevExpress.Utils
Imports DevExpress.Utils.Svg

Namespace DevExpress.UITemplates.Collection.Images

    Public Module CardLogos
        Const assetsRoot As String = "UITemplatesExampleVB.Assets."
        <ThreadStatic>
        Private svgImagesCore As SvgImageCollection
        Public ReadOnly Property SvgImages As SvgImageCollection
            Get
                Return If(svgImagesCore, Function()
                                             svgImagesCore = CreateAllImages()
                                             Return svgImagesCore
                                         End Function())
            End Get
        End Property
        Private Function CreateAllImages() As SvgImageCollection
            Dim rootAsm = GetType(CardLogos).Assembly
            Dim imgCollection = SvgImageCollection.FromResources(assetsRoot & "SVG.CardLogos", rootAsm)
            Dim dinnersClubBase = imgCollection(NameOf(CardLogos.DinersClub))
            imgCollection.Add("DinersClubInternational", dinnersClubBase)
            imgCollection.Add("DinersClubCarteBlanche", dinnersClubBase)
            imgCollection.Add("DinersClubNorthAmerica", dinnersClubBase)
            Return imgCollection
        End Function
        Public ReadOnly Property Visa As SvgImage
            Get
                Return CardLogos.SvgImages(NameOf(CardLogos.Visa))
            End Get
        End Property
        Public ReadOnly Property MasterCard As SvgImage
            Get
                Return CardLogos.SvgImages(NameOf(CardLogos.MasterCard))
            End Get
        End Property
        Public ReadOnly Property Maestro As SvgImage
            Get
                Return CardLogos.SvgImages(NameOf(CardLogos.Maestro))
            End Get
        End Property
        Public ReadOnly Property AmericanExpress As SvgImage
            Get
                Return CardLogos.SvgImages(NameOf(CardLogos.AmericanExpress))
            End Get
        End Property
        Public ReadOnly Property DinersClub As SvgImage
            Get
                Return CardLogos.SvgImages(NameOf(CardLogos.DinersClub))
            End Get
        End Property
        Public ReadOnly Property Discover As SvgImage
            Get
                Return CardLogos.SvgImages(NameOf(CardLogos.Discover))
            End Get
        End Property
        Public ReadOnly Property JCB As SvgImage
            Get
                Return CardLogos.SvgImages(NameOf(CardLogos.JCB))
            End Get
        End Property
    End Module
End Namespace
