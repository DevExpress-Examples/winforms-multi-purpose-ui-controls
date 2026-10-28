Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils

Namespace DevExpress.UITemplates.Collection.Forms.Base
    Public Module FormAssets

        ' Common Assets
        Public ReadOnly FixedDialog As HtmlCssAsset = New FixedDialogHtmlCssAsset()

        ' Common Images
        Public ReadOnly Property DefaultHtmlImages As SvgImageCollection
            Get
                Return DevExpress.UITemplates.Collection.Images.UIElements.SvgImages
            End Get
        End Property

        Private NotInheritable Class FixedDialogHtmlCssAsset
            Inherits HtmlCssAsset

            <Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Shared Sub New()
                DevExpress.XtraEditors.DirectXForm.RegisterHtmlComponents()
            End Sub
        End Class

    End Module

End Namespace