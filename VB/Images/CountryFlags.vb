Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.Skins
Imports DevExpress.Utils
Imports DevExpress.Utils.Design
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Svg

Namespace DevExpress.UITemplates.Collection.Images

    Public Module CountryFlags
        Const assetsRoot As String = "UITemplatesExampleVB.Assets."
        <ThreadStatic>
        Private svgImagesCore As SvgImageCollection
        Public ReadOnly Property SvgImages As SvgImageCollection
            Get
                Return If(svgImagesCore, Function()
                                             svgImagesCore = SvgImageCollection.FromResources(assetsRoot & "SVG.Countries", GetType(CountryFlags).Assembly)
                                             Return svgImagesCore
                                         End Function())
            End Get
        End Property
        ' Some Countries with simple flags
        Public ReadOnly Property Armenia As SvgImage
            Get
                Return CountryFlags.SvgImages("AM")
            End Get
        End Property
        Public ReadOnly Property Austria As SvgImage
            Get
                Return CountryFlags.SvgImages("AT")
            End Get
        End Property
        Public ReadOnly Property Belgium As SvgImage
            Get
                Return CountryFlags.SvgImages("BE")
            End Get
        End Property
        Public ReadOnly Property Bulgaria As SvgImage
            Get
                Return CountryFlags.SvgImages("BG")
            End Get
        End Property
        Public ReadOnly Property Chile As SvgImage
            Get
                Return CountryFlags.SvgImages("CL")
            End Get
        End Property
        Public ReadOnly Property Germany As SvgImage
            Get
                Return CountryFlags.SvgImages("DE")
            End Get
        End Property
        Public ReadOnly Property Estonia As SvgImage
            Get
                Return CountryFlags.SvgImages("EE")
            End Get
        End Property
        Public ReadOnly Property France As SvgImage
            Get
                Return CountryFlags.SvgImages("FR")
            End Get
        End Property
        Public ReadOnly Property Gabon As SvgImage
            Get
                Return CountryFlags.SvgImages("GA")
            End Get
        End Property
        Public ReadOnly Property Guinea As SvgImage
            Get
                Return CountryFlags.SvgImages("GN")
            End Get
        End Property
        Public ReadOnly Property Hungary As SvgImage
            Get
                Return CountryFlags.SvgImages("HU")
            End Get
        End Property
        Public ReadOnly Property Indonesia As SvgImage
            Get
                Return CountryFlags.SvgImages("ID")
            End Get
        End Property
        Public ReadOnly Property Ireland As SvgImage
            Get
                Return CountryFlags.SvgImages("IE")
            End Get
        End Property
        Public ReadOnly Property Italy As SvgImage
            Get
                Return CountryFlags.SvgImages("IT")
            End Get
        End Property
        Public ReadOnly Property Lithuania As SvgImage
            Get
                Return CountryFlags.SvgImages("LT")
            End Get
        End Property
        Public ReadOnly Property Luxembourg As SvgImage
            Get
                Return CountryFlags.SvgImages("LU")
            End Get
        End Property
        Public ReadOnly Property Monaco As SvgImage
            Get
                Return CountryFlags.SvgImages("MC")
            End Get
        End Property
        Public ReadOnly Property SaintMartin As SvgImage
            Get
                Return CountryFlags.SvgImages("MF")
            End Get
        End Property
        Public ReadOnly Property Mali As SvgImage
            Get
                Return CountryFlags.SvgImages("ML")
            End Get
        End Property
        Public ReadOnly Property Nigeria As SvgImage
            Get
                Return CountryFlags.SvgImages("NG")
            End Get
        End Property
        Public ReadOnly Property Netherlands As SvgImage
            Get
                Return CountryFlags.SvgImages("NL")
            End Get
        End Property
        Public ReadOnly Property Peru As SvgImage
            Get
                Return CountryFlags.SvgImages("PE")
            End Get
        End Property
        Public ReadOnly Property Poland As SvgImage
            Get
                Return CountryFlags.SvgImages("PL")
            End Get
        End Property
        Public ReadOnly Property Romania As SvgImage
            Get
                Return CountryFlags.SvgImages("RO")
            End Get
        End Property
        Public ReadOnly Property Russia As SvgImage
            Get
                Return CountryFlags.SvgImages("RU")
            End Get
        End Property
        Public ReadOnly Property SierraLeone As SvgImage
            Get
                Return CountryFlags.SvgImages("SL")
            End Get
        End Property
        Public ReadOnly Property Chad As SvgImage
            Get
                Return CountryFlags.SvgImages("TD")
            End Get
        End Property
        Public ReadOnly Property Ukraine As SvgImage
            Get
                Return CountryFlags.SvgImages("UA")
            End Get
        End Property
        Public ReadOnly Property USA As SvgImage
            Get
                Return CountryFlags.SvgImages("US")
            End Get
        End Property
        Public ReadOnly Property Yemen As SvgImage
            Get
                Return CountryFlags.SvgImages("YE")
            End Get
        End Property
#Region "Images"
        <ThreadStatic>
        Private glyphCache As Dictionary(Of Integer, Image)
        Public Function GetISO2GlyphOrFlag(skinProvider As ISkinProvider, iso2 As String, glyphSize As Size, Optional palette As ISvgPaletteProvider = Nothing) As Image
            If glyphCache Is Nothing Then glyphCache = New Dictionary(Of Integer, Image)(Utilities.Countries.All.Count * 2)
            Dim key As Integer = HashCodeHelper.Calculate(glyphSize.Width, glyphSize.Height, AscW(iso2(0)), AscW(iso2(1)))
            Dim glyph As Image = Nothing
            If Not glyphCache.TryGetValue(key, glyph) Then
                glyph = New Bitmap(glyphSize.Width, glyphSize.Height, Imaging.PixelFormat.Format32bppArgb)
                CountryFlags.UpdateISO2Glyph(iso2, glyph, skinProvider, palette)
                glyphCache.Add(key, glyph)
            End If
            Return glyph
        End Function
        Private Sub UpdateISO2Glyph(iso2 As String, glyph As Image, skinProvider As ISkinProvider, palette As ISvgPaletteProvider)
            Using g = Graphics.FromImage(glyph)
                g.Clear(Color.Transparent)
                Dim svgImage = CountryFlags.SvgImages(iso2)
                If svgImage IsNot Nothing Then
                    DrawFlagSvgImage(glyph, palette, g, svgImage)
                Else
                    CountryFlags.DrawFlagViaISO2Glyph(iso2, glyph, skinProvider, g)
                End If
            End Using
        End Sub
        Private Sub DrawFlagSvgImage(glyph As Image, palette As ISvgPaletteProvider, g As Graphics, svgImage As SvgImage)
            Dim factor As Double = CDbl(svgImage.Height) / svgImage.Width
            Dim offset As Single = CInt(Math.Ceiling((glyph.Height - factor * glyph.Width) / 2))
            g.TranslateTransform(0, offset)
            Dim svgBmp = SvgBitmap.Create(svgImage)
            svgBmp.RenderToGraphics(g, palette, glyph.Width / svgImage.Width)
        End Sub
        Private Sub DrawFlagViaISO2Glyph(iso2 As String, glyph As Image, provider As ISkinProvider, g As Graphics)
            Dim length = iso2.Length
            If length > 2 OrElse length = 0 Then Throw New ArgumentException()
            Dim width = glyph.Width
            Dim height As Integer = CInt(2 * (width + 0.5F) / 3)
            Dim padding As Integer = width \ 16
            Dim family = AppearanceObject.DefaultFont.FontFamily
            Dim maxSize As Size = New Size(width - padding, height - padding)
            Dim fontBestSize = 0
            Dim emSize As Single
            Dim bestSize As SizeF
            Using path = New GraphicsPath()
                While True
                    emSize = 96F * (fontBestSize + 1) / 72
                    path.AddString("WW", family, 0, emSize, Point.Empty, Nothing)
                    bestSize = path.GetBounds().Size
                    If bestSize.Width > maxSize.Width OrElse bestSize.Height > maxSize.Height Then Exit While
                    fontBestSize += 1
                    path.Reset()
                End While
                path.Reset()
                emSize = 96F * fontBestSize / 72
                path.AddString(iso2, family, 0, emSize, Point.Empty, Nothing)
                Dim pathBounds = path.GetBounds()
                Dim colors = GetColors(provider, AscW(iso2(0)) Mod 5, ObjectState.Normal)
                g.Clear(Color.Transparent)
                Dim offset = (glyph.Height - height) / 2F
                Using brush = New SolidBrush(colors.Item1)
                    g.FillRectangle(brush, New RectangleF(0, offset, width, height))
                End Using
                g.TranslateTransform((width - pathBounds.Width) / 2F - pathBounds.X - 0.5F, (height - pathBounds.Height) / 2F - pathBounds.Y + offset)
                g.SmoothingMode = SmoothingMode.HighQuality
                g.CompositingQuality = CompositingQuality.HighQuality
                Using brush = New SolidBrush(colors.Item2)
                    g.FillPath(brush, path)
                End Using
            End Using
        End Sub
        Private Function GetColors(provider As ISkinProvider, index As Integer, state As ObjectState) As Tuple(Of Color, Color)
            Dim skin = DevExpress.Skins.CommonSkins.GetSkin(provider)
            If skin.SvgPalettes Is Nothing OrElse skin.SvgPalettes.Count = 0 Then Return New Tuple(Of Color, Color)(Color.Gray, Color.White)
            Dim palette As SvgPalette = skin.SvgPalettes(state)
            If palette Is Nothing Then palette = skin.SvgPalettes(ObjectState.Normal)
            If palette Is Nothing Then Return New Tuple(Of Color, Color)(Color.Gray, Color.White)
            Dim backColor As Color = palette.GetColorByStyleName(backColorNameTable(index), "Black")
            Dim foreColor As Color = palette.GetColorByStyleName(foreColorNameTable(index), "White")
            Return New Tuple(Of Color, Color)(backColor, foreColor)
        End Function
        Private ReadOnly backColorNameTable As String() = New String() {"Black", "Red", "Green", "Blue", "Yellow"}
        Private ReadOnly foreColorNameTable As String() = New String() {"White", "White", "White", "White", "White"}
#End Region
    End Module
End Namespace
