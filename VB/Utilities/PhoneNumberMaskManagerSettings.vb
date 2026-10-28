Imports System
Imports DevExpress.XtraEditors.Mask

Namespace DevExpress.UITemplates.Collection.Utilities

    Public MustInherit Partial Class CustomMaskSettings
        Inherits MaskSettings.User
        Public Class PhoneNumber
            Inherits MaskSettingsWithCulture
            Protected Overrides Function GetMaskManagerType() As Type
                Return GetType(PhoneNumberMaskManager)
            End Function
        End Class
    End Class
End Namespace
