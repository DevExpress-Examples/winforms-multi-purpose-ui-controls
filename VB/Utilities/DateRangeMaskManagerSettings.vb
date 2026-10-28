Imports DevExpress.XtraEditors.Mask
Imports System

Namespace DevExpress.UITemplates.Collection.Utilities

    Public MustInherit Partial Class CustomMaskSettings
        Inherits MaskSettings.User
        Public Class CalendarRange
            Inherits MaskSettingsWithCulture
            Protected Overrides Function GetMaskManagerType() As Type
                Return GetType(DateRangeMaskManager)
            End Function
        End Class
    End Class
End Namespace
