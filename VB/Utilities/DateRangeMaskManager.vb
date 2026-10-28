Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports System.Linq
Imports DevExpress.Data.Mask
Imports DevExpress.XtraEditors.Controls

Namespace DevExpress.UITemplates.Collection.Utilities

    <MaskManager.Compatible(GetType(DateTimeMaskManager))>
    Public Class DateRangeMaskManager
        Inherits MaskManager
        Public Shared Sub Register()
            RegisterMaskManagerType(GetType(DateRangeMaskManager))
            RegisterMaskManagerInfo(GetType(DateRangeMaskManager), Nothing, description:="Mask to enter date ranges")
            RegisterMaskManagerInfo(GetType(DateRangeMaskManager), standardMaskSpecifiers:=New ManagerInfo.StandardMaskSpecifier() {New ManagerInfo.StandardMaskSpecifier(Nothing, "Short date format", "d", Date.Now.ToShortDateString() & Separator & Date.Now.AddDays(5).ToShortDateString()), New ManagerInfo.StandardMaskSpecifier(Nothing, "Month/day format", "m", Date.Now.ToString("m") & Separator & Date.Now.AddDays(35).ToString("m"))}, customPlaceholders:=Nothing, helpLink:=Nothing, standardHelpLink:=Nothing, customHelpLink:=Nothing, advancedSettingsLink:=Nothing)
        End Sub
        '
        <Parameters("UITemplatesExampleVB, DevExpress.UITemplates.Collection.Utilities.DateRangeMaskManager", "Date Ranges")>
        Public Sub New(
                        <Parameter("mask", "Mask Expression")> mask As String,
            <Parameter("cultureInfo")>
                        <Parameter("culture", GetType(CultureInfoConverter), "Culture (name)", Visibility:=ParameterVisibility.Advanced)> cultureInfo As CultureInfo)
            NestedManagers = InitializeNestedManagers(mask, cultureInfo)
        End Sub
        Private Function InitializeNestedManagers(mask As String, cultureInfo As CultureInfo) As MaskManager()
            Dim nestedManagers = New MaskManager() {New DateTimeMaskManager(mask, True, cultureInfo, True, True), New DateTimeMaskManager(mask, True, cultureInfo, True, True)}
            For Each nested As MaskManager In nestedManagers
                AddHandler nested.EditTextChanging, AddressOf Nested_EditTextChanging
                AddHandler nested.EditTextChanged, AddressOf Nested_EditTextChanged
                AddHandler nested.LocalEditAction, AddressOf Nested_LocalEditAction
            Next
            Return nestedManagers
        End Function
        Private Sub Nested_EditTextChanging(sender As Object, e As MaskChangingEventArgs)
            If Not e.Cancel AndAlso TypeOf e.NewValue Is Date Then
                Dim [date] = CDate(e.NewValue)
                If Index = 0 Then
                    If [date] > RangeEnd Then e.Cancel = True
                Else
                    If [date] < RangeStart Then e.Cancel = True
                End If
            End If
            If Not e.Cancel Then e.Cancel = Not RaiseEditTextChanging(e.NewValue)
        End Sub
        Private Sub Nested_EditTextChanged(sender As Object, e As EventArgs)
            RaiseEditTextChanged()
        End Sub
        Private Sub Nested_LocalEditAction(sender As Object, e As CancelEventArgs)
            e.Cancel = Not RaiseModifyWithoutEditValueChange()
        End Sub
        Private ReadOnly Property RangeStart As Date
            Get
                Return CDate((If(NestedManagers(0).GetCurrentEditValue(), Date.MinValue)))
            End Get
        End Property
        Private ReadOnly Property RangeEnd As Date
            Get
                Return CDate((If(NestedManagers(1).GetCurrentEditValue(), Date.MaxValue)))
            End Get
        End Property
        Public Overrides Function GetCurrentEditText() As String
            Throw New NotImplementedException()
        End Function
        Public Overrides Function GetCurrentEditValue() As Object
            Dim startDate = CType(NestedManagers(0).GetCurrentEditValue(), Date?)
            Dim endDate = CType(NestedManagers(1).GetCurrentEditValue(), Date?)
            If startDate.HasValue AndAlso endDate.HasValue Then Return New DateRange(startDate.Value, endDate.Value)
            If startDate.HasValue Then Return New DateRange(startDate.Value, startDate.Value)
            If endDate.HasValue Then Return New DateRange(endDate.Value, endDate.Value)
            Return New DateRange()
        End Function
        Public Overrides Sub SetInitialEditText(initialEditText As String)
            Throw New NotImplementedException()
        End Sub
        Public Overrides Sub SetInitialEditValue(initialEditValue As Object)
            If Not (TypeOf initialEditValue Is DateRange) Then
                For Each m In NestedManagers
                    m.SetInitialEditValue(Nothing)
                Next
            Else
                Dim range = CType(initialEditValue, DateRange)
                NestedManagers(0).SetInitialEditValue(range.StartDate)
                NestedManagers(0).SelectAll()
                NestedManagers(1).SetInitialEditValue(range.EndDate)
                NestedManagers(1).SelectAll()
            End If
            Index = 0
        End Sub
        Public Const Separator As String = " - "
        Protected ReadOnly NestedManagers As MaskManager()
        Protected Index As Integer
        Protected ReadOnly Property ActiveManager As MaskManager
            Get
                Return NestedManagers(Index)
            End Get
        End Property
        Public Overrides ReadOnly Property DisplayText As String
            Get
                Return String.Join(Separator, NestedManagers.Select(Function(m) m.DisplayText))
            End Get
        End Property
        Protected ReadOnly Property ActiveDisplayOffset As Integer
            Get
                Return Enumerable.Range(0, Index).Sum(Function(i) NestedManagers(CInt(i)).DisplayText.Length + Separator.Length)
            End Get
        End Property
        Public Overrides ReadOnly Property DisplayCursorPosition As Integer
            Get
                Return ActiveDisplayOffset + ActiveManager.DisplayCursorPosition
            End Get
        End Property
        Public Overrides ReadOnly Property DisplaySelectionAnchor As Integer
            Get
                Return ActiveDisplayOffset + ActiveManager.DisplaySelectionAnchor
            End Get
        End Property
        Public Overrides ReadOnly Property CanUndo As Boolean
            Get
                Return ActiveManager.CanUndo
            End Get
        End Property
        Public Overrides Function Backspace() As Boolean
            Return ActiveManager.Backspace()
        End Function
        Public Overrides Function CursorEnd(forceSelection As Boolean) As Boolean
            If Index = NestedManagers.Length - 1 AndAlso ActiveManager.DisplaySelectionLength = ActiveManager.DisplayText.Length Then Return False
            ActiveManager.FlushPendingEditActions()
            Index = NestedManagers.Length - 1
            ActiveManager.SelectAll()
            Return True
        End Function
        Public Overrides Function CursorHome(forceSelection As Boolean) As Boolean
            If Index = 0 AndAlso ActiveManager.DisplaySelectionLength = ActiveManager.DisplayText.Length Then Return False
            ActiveManager.FlushPendingEditActions()
            Index = NestedManagers.Length - 1
            ActiveManager.SelectAll()
            Return True
        End Function
        Public Overrides Function CursorMoveNear(forceSelection As Boolean, isNeededKeyCheck As Boolean) As Boolean
            If ActiveManager.DisplaySelectionLength <> ActiveManager.DisplayText.Length Then
                Dim nestedResult As Boolean = ActiveManager.CursorMoveNear(forceSelection, isNeededKeyCheck)
                If nestedResult OrElse forceSelection Then Return nestedResult
            End If
            If Index = 0 Then Return False
            If isNeededKeyCheck Then Return True
            ActiveManager.FlushPendingEditActions()
            Threading.Interlocked.Decrement(Index)
            ActiveManager.SelectAll()
            Return True
        End Function
        Public Overrides Function CursorMoveFar(forceSelection As Boolean, isNeededKeyCheck As Boolean) As Boolean
            If ActiveManager.DisplaySelectionLength <> ActiveManager.DisplayText.Length Then
                Dim nestedResult As Boolean = ActiveManager.CursorMoveFar(forceSelection, isNeededKeyCheck)
                If nestedResult OrElse forceSelection Then Return nestedResult
            End If
            If Index = NestedManagers.Length - 1 Then Return False
            If isNeededKeyCheck Then Return True
            ActiveManager.FlushPendingEditActions()
            Threading.Interlocked.Increment(Index)
            ActiveManager.SelectAll()
            Return True
        End Function
        Public Overrides Function CursorToDisplayPosition(newPosition As Integer, forceSelection As Boolean) As Boolean
            Dim runningoffset = 0, i = 0
            Do
                runningoffset += NestedManagers(i).DisplayText.Length + Separator.Length
                Threading.Interlocked.Increment(i)
            Loop While newPosition >= runningoffset - Separator.Length / 2
            Dim toEditorIndex = i - 1
            If toEditorIndex = Index Then Return ActiveManager.CursorToDisplayPosition(newPosition - ActiveDisplayOffset, forceSelection)
            If forceSelection Then
                Return False
            Else
                ActiveManager.FlushPendingEditActions()
                Index = toEditorIndex
                ActiveManager.CursorToDisplayPosition(newPosition - ActiveDisplayOffset, forceSelection)
                Return True
            End If
        End Function
        Public Overrides Function Delete() As Boolean
            Return ActiveManager.Delete()
        End Function
        Public Overrides Function Insert(insertion As String) As Boolean
            Return ActiveManager.Insert(insertion)
        End Function
        Public Overrides Sub SelectAll()
            ActiveManager.SelectAll()
        End Sub
        Public Overrides Function FlushPendingEditActions() As Boolean
            Dim result = False
            Dim i = 0

            While i < NestedManagers.Length
                result = result Or NestedManagers(i).FlushPendingEditActions()
                Threading.Interlocked.Increment(i)
            End While
            Return result
        End Function
        Public Overrides Function SpinDown() As Boolean
            Return ActiveManager.SpinDown()
        End Function
        Public Overrides Function SpinUp() As Boolean
            Return ActiveManager.SpinUp()
        End Function
        Public Overrides Function Undo() As Boolean
            Return ActiveManager.Undo()
        End Function
    End Class
End Namespace
