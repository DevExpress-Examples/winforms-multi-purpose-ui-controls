Imports DevExpress.Skins
Imports DevExpress.Utils

Namespace DevExpress.UITemplates.Collection.Editors

    Public Class ButtonImageOptionsBase
        Inherits ImageCollectionImageOptions
        Implements ISkinElementDataProvider
        Private imageListCore As Object
        <ComponentModel.DefaultValueAttribute(GetType(Object), Nothing), ComponentModel.TypeConverterAttribute(GetType(DevExpress.Utils.Design.ImageCollectionImagesConverter))>
        Public Overridable Property ImageList As Object
            Get
                Return imageListCore
            End Get
            Set(value As Object)
                SetValue(imageListCore, value, "ImageList")
            End Set
        End Property
        Protected Overrides Function GetImageCollection() As Object
            Return imageListCore
        End Function
        <ComponentModel.EditorAttribute(GetType(DevExpress.Utils.Design.ImageIndexesEditor), GetType(System.Drawing.Design.UITypeEditor))>
        <DevExpress.Utils.ImageList("ImageList")>
        Public Overrides Property ImageIndex As Integer
            Get
                Return MyBase.ImageIndex
            End Get
            Set(value As Integer)
                MyBase.ImageIndex = value
            End Set
        End Property
        Protected Overrides Sub AssignCore(source As ImageOptions)
            MyBase.AssignCore(source)
            Dim sourceOptions = TryCast(source, ButtonImageOptionsBase)
            If sourceOptions IsNot Nothing Then imageListCore = sourceOptions.ImageList
        End Sub
        Protected Overrides Sub ResetCore()
            MyBase.ResetCore()
            imageListCore = Nothing
        End Sub
        '
        Private ReadOnly Property ProductId As SkinProductId
            Get
                Return SkinProductId.Common
            End Get
        End Property
        Private ReadOnly Property ElementName As String
            Get
                Return CommonSkins.SkinButton
            End Get
        End Property

        Private ReadOnly Property ISkinElementDataProvider_ProductId As SkinProductId Implements ISkinElementDataProvider.ProductId
            Get
                Return ProductId
            End Get
        End Property

        Private ReadOnly Property ISkinElementDataProvider_ElementName As String Implements ISkinElementDataProvider.ElementName
            Get
                Return ElementName
            End Get
        End Property
    End Class
End Namespace
