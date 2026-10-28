Imports System
Imports System.Collections.Concurrent
Imports System.Drawing
Imports DevExpress.Utils

Namespace DevExpress.UITemplates.Collection.Images

    Public Module Users
        Const assetsRoot As String = "UITemplatesExampleVB.Assets."
        <ThreadStatic>
        Private imagesCore As ImageCollection
        Public ReadOnly Property Images As ImageCollection
            Get
                Return If(imagesCore, Function()
                                          imagesCore = CreateAllImages()
                                          Return imagesCore
                                      End Function())
            End Get
        End Property
        Private Function CreateAllImages() As ImageCollection
            Dim imgCollection = New ImageCollection()
            imgCollection.ImageSize = New Size(350, 420)
            Dim rootAsm = GetType(Users).Assembly
            Dim usersRoot = assetsRoot & "PNG.Users."
            Dim unknown = ResourceImageHelperCore.CreateImageFromResources(usersRoot & NameOf(Users.Unknown) & ".png", rootAsm)
            Dim user1 = ResourceImageHelperCore.CreateImageFromResources(usersRoot & NameOf(Users.SampleUser1) & ".png", rootAsm)
            Dim user2 = ResourceImageHelperCore.CreateImageFromResources(usersRoot & NameOf(Users.SampleUser2) & ".png", rootAsm)
            Dim user3 = ResourceImageHelperCore.CreateImageFromResources(usersRoot & NameOf(Users.SampleUser3) & ".png", rootAsm)
            imgCollection.AddImage(unknown, NameOf(Users.Unknown))
            imgCollection.AddImage(user1, NameOf(Users.SampleUser1))
            imgCollection.AddImage(user2, NameOf(Users.SampleUser2))
            imgCollection.AddImage(user3, NameOf(Users.SampleUser3))
            Return imgCollection
        End Function
        Public ReadOnly Property Unknown As Image
            Get
                Return Images.Images(NameOf(Users.Unknown))
            End Get
        End Property
        Public ReadOnly Property SampleUser1 As Image
            Get
                Return Images.Images(NameOf(Users.SampleUser1))
            End Get
        End Property
        Public ReadOnly Property SampleUser2 As Image
            Get
                Return Images.Images(NameOf(Users.SampleUser2))
            End Get
        End Property
        Public ReadOnly Property SampleUser3 As Image
            Get
                Return Images.Images(NameOf(Users.SampleUser3))
            End Get
        End Property
        ' API
        Private ReadOnly avatars As ConcurrentDictionary(Of Long, Image) = New ConcurrentDictionary(Of Long, Image)()
        Public Function CreateAvatar(id As Long, image As Image) As Image
            Return avatars.GetOrAdd(id, Function(x) ClipImage(image))
        End Function
        Private Function ClipImage(image As Image, Optional size As Integer = 128) As Image
            Dim avatar = New Bitmap(size, size, Imaging.PixelFormat.Format32bppArgb)
            Using g = Graphics.FromImage(avatar)
                g.Clear(Color.White)
                Dim clipSize = Math.Min(image.Width, image.Height)
                g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                g.DrawImage(image, New RectangleF(0, 0, size, size), New RectangleF(0, 0, clipSize, clipSize), GraphicsUnit.Pixel)
            End Using
            Return avatar
        End Function
    End Module
End Namespace
