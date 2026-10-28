Imports System.ComponentModel
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Editors.Base

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Class HtmlItemsControlActions
        Inherits DevExpress.Utils.ControlActions
        Public Sub AddItem(component As IComponent)
            Dim htmlItemsControl = TryCast(component, IHtmlItemsControl)
            If htmlItemsControl IsNot Nothing Then htmlItemsControl.AddItem()
        End Sub
    End Class
End Namespace
