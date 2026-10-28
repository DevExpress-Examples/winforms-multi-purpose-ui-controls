Imports System
Imports DevExpress.Utils
Imports DevExpress.Utils.Svg

Namespace DevExpress.UITemplates.Collection.Images

    Public Module DataEntry
        Const assetsRoot As String = "UITemplatesExampleVB.Assets."
        <ThreadStatic>
        Private svgImagesCore As SvgImageCollection
        Public ReadOnly Property SvgImages As SvgImageCollection
            Get
                Return If(svgImagesCore, Function()
                                             svgImagesCore = SvgImageCollection.FromResources(assetsRoot & "SVG.DataEntry", GetType(DataEntry).Assembly)
                                             Return svgImagesCore
                                         End Function())
            End Get
        End Property
        Public ReadOnly Property Email As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Email))
            End Get
        End Property
        Public ReadOnly Property Key As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Key))
            End Get
        End Property
        Public ReadOnly Property Phone As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Phone))
            End Get
        End Property
        Public ReadOnly Property World As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.World))
            End Get
        End Property
        Public ReadOnly Property Card As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Card))
            End Get
        End Property
        Public ReadOnly Property Employees As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Employees))
            End Get
        End Property
        Public ReadOnly Property Customers As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Customers))
            End Get
        End Property
        Public ReadOnly Property Products As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Products))
            End Get
        End Property
        Public ReadOnly Property Sales As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Sales))
            End Get
        End Property
        Public ReadOnly Property Tasks As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Tasks))
            End Get
        End Property
        Public ReadOnly Property Opportunities As SvgImage
            Get
                Return DataEntry.SvgImages(NameOf(DataEntry.Opportunities))
            End Get
        End Property
    End Module
End Namespace
