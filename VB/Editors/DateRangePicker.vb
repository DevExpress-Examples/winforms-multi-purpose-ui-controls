Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Design
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Calendar
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "DateRangePicker.bmp")>
    <Description("A text box with a dropdown calendar that allows you to select a date range.")>
    <DevExpress.Utils.Design.SmartTagFilter(GetType(DateRangePicker.DateRangePickerFilter))>
    Public Class DateRangePicker
        Inherits PopupContainerEdit
        Private ReadOnly calendarCore As DateRangeCalendar
        Private hasPropertyChanges As Boolean = True
        Public Sub New()
            calendarCore = CreateDateRangeCalendar()
            Initialize()
        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)
            MyBase.Dispose(disposing)
            calendarCore.Dispose()
        End Sub
        Protected Friend ReadOnly Property Calendar As DateRangeCalendar
            Get
                Return calendarCore
            End Get
        End Property
        Protected Friend ReadOnly Property PopupContainer As PopupContainerControl
            Get
                Return Properties.PopupControl
            End Get
        End Property
        Protected Overridable Function CreateDateRangeCalendar() As DateRangeCalendar
            Return New DateRangeCalendar(Me)
        End Function
        Protected Overridable Function CreatePopupContainer() As PopupContainerControl
            Return New PopupContainerControl()
        End Function
        Private Sub Initialize()
            Calendar.Dock = DockStyle.Fill
            Calendar.Name = "calendarControl"
            Calendar.SyncSelectionWithEditValue = False
            SyncEditValue(If(TryCast(EditValue, DateRange), NullValue))
            PopupContainer.Controls.Add(Calendar)
            PopupContainer.Name = "popupContainerControl"
            PopupContainer.Size = New Size(Width, 400)
        End Sub
#Region "Properties"
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <ComponentModel.Category(CategoryName.Properties)>
        Public Overloads ReadOnly Property Properties As RepositoryItemDateRangePicker
            Get
                Return TryCast(MyBase.Properties, RepositoryItemDateRangePicker)
            End Get
        End Property
        Protected Overrides Function CreateRepositoryItemCore() As RepositoryItem
            Return New RepositoryItemDateRangePicker()
        End Function
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overrides Property EditValue As Object
            Get
                Return MyBase.EditValue
            End Get
            Set(value As Object)
                Dim range As DateRange = If(TryCast(value, DateRange), NullValue)
                If MyBase.EditValue IsNot range Then
                    MyBase.EditValue = range
                    Me.SyncEditValue(range)
                End If
            End Set
        End Property
        Private Sub SyncEditValue(range As DateRange)
            Dim selectedRanges = Calendar.SelectedRanges
            selectedRanges.BeginUpdate()
            selectedRanges.Clear()
            selectedRanges.Add(range)
            selectedRanges.EndUpdate()
        End Sub

        Private nullValueField As DateRange
        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property NullValue As DateRange
            Get
                Return nullValueField
            End Get
            Set(value As DateRange)
                If nullValueField Is value Then Return
                If value Is Nothing Then
                    nullValueField = New DateRange(Date.Today, Date.Today)
                Else
                    nullValueField = value
                End If
            End Set
        End Property
        <Browsable(False)>
        Public ReadOnly Property StartDate As Date
            Get
                Return If(TryCast(EditValue, DateRange)?.StartDate, Date.MinValue)
            End Get
        End Property
        <Browsable(False)>
        Public ReadOnly Property EndDate As Date
            Get
                Return If(TryCast(EditValue, DateRange)?.EndDate, Date.MinValue)
            End Get
        End Property
        Protected Overrides Sub InitializeDefaultProperties()
            MyBase.InitializeDefaultProperties()
            fEditValue = New DateRange(Date.Today, Date.Today)
            NullValue = New DateRange(Date.Today, Date.Today)
            Properties.TextEditStyle = TextEditStyles.Standard
            Properties.PopupControl = CreatePopupContainer()
            Properties.CalendarProperties.BeginUpdate()
            Properties.CalendarProperties.ColumnCount = 2
            Properties.CalendarProperties.HighlightTodayCell = DevExpress.Utils.DefaultBoolean.[False]
            Properties.CalendarProperties.ShowClear = False
            Properties.CalendarProperties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.[True]
            Properties.CalendarProperties.ShowToday = False
            Properties.CalendarProperties.EndUpdate()
        End Sub
        Public Class RepositoryItemDateRangePicker
            Inherits RepositoryItemPopupContainerEdit
            Private _CalendarProperties As RepositoryItemDateEdit
            Public Sub New()
                CalendarProperties = CreateCalendarProperties()
                AddHandler CalendarProperties.PropertiesChanged, AddressOf OnCalendarPropertiesChanged
            End Sub
            Protected Overrides Sub Dispose(disposing As Boolean)
                RemoveHandler CalendarProperties.PropertiesChanged, AddressOf OnCalendarPropertiesChanged
                MyBase.Dispose(disposing)
            End Sub
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
            Public Property CalendarProperties As RepositoryItemDateEdit
                Get
                    Return _CalendarProperties
                End Get
                Private Set(value As RepositoryItemDateEdit)
                    _CalendarProperties = value
                End Set
            End Property
            Protected Overridable Function CreateCalendarProperties() As RepositoryItemDateEdit
                Return New RepositoryItemDateEdit()
            End Function
            Protected Overridable Sub OnCalendarPropertiesChanged(sender As Object, e As EventArgs)
                MyBase.OnPropertiesChanged()
            End Sub
            Protected Overrides Function GetDefaultMaskManagerType() As Type
                Return GetType(DateRangeMaskManager)
            End Function
            Protected Overrides ReadOnly Property ShouldCreateMaskSettingsWhenMaskLoadedOrUpdated As Boolean
                Get
                    Return True
                End Get
            End Property
            Protected Overrides Function GetDefaultEditMask(culture As CultureInfo) As String
                Return "d"
            End Function
            Public Overrides Function CreateEditor() As BaseEdit
                Return New DateRangePicker()
            End Function
        End Class
#End Region
        '
        Protected Overrides Sub OnMaskEditValueChanging(e As ChangingEventArgs)
            If TypeOf e.NewValue Is Date Then
                Dim maskEditValue = CDate(e.NewValue)
                If maskEditValue < Properties.CalendarProperties.MinValue Then e.Cancel = True
                If maskEditValue > Properties.CalendarProperties.MaxValue Then e.Cancel = True
            End If
        End Sub
        Protected Overrides Sub OnValidatingCore(e As CancelEventArgs)
            If StartDate < Properties.CalendarProperties.MinValue Then e.Cancel = True
            If EndDate > Properties.CalendarProperties.MaxValue Then e.Cancel = True
        End Sub
        Protected Overrides Sub OnPopupClosed(closeMode As PopupCloseMode)
            MyBase.OnPopupClosed(closeMode)
            If closeMode <> PopupCloseMode.Cancel Then
                EditValue = Calendar.GetCurrentRange()
            Else
                SyncEditValue(If(TryCast(EditValue, DateRange), NullValue))
                Calendar.ResetState(StartDate, EndDate)
            End If
        End Sub
        Protected Overridable Sub EnsurePopupControlCreated()
            If PopupContainer Is Nothing Then
                Properties.PopupControl = CreatePopupContainer()
                Initialize()
            End If
        End Sub
        Public Overrides Sub ShowPopup()
            EnsurePopupControlCreated()
            If hasPropertyChanges Then
                Calendar.Assign(Properties.CalendarProperties)
                Properties.PopupFormMinSize = Calendar.PreferredSize
                PopupContainer.Size = Calendar.PreferredSize
                hasPropertyChanges = False
            End If
            Calendar.ResetState(StartDate, StartDate)
            MyBase.ShowPopup()
        End Sub
        Protected Overrides Sub OnPropertiesChanged()
            MyBase.OnPropertiesChanged()
            hasPropertyChanges = True
        End Sub
#Region "DateRangeCalendar"
        Public Class DateRangeCalendar
            Inherits CalendarControl
            Private _Owner As PopupContainerEdit
            Private isSelecting As Boolean
            Private rangeStart As Date
            Public Sub New(owner As PopupContainerEdit)
                Me.Owner = owner
            End Sub

            Protected Property Owner As PopupContainerEdit
                Get
                    Return _Owner
                End Get
                Private Set(value As PopupContainerEdit)
                    _Owner = value
                End Set
            End Property
            Public Function GetCurrentRange() As DateRange
                If SelectedRanges.Count < 1 Then Return Nothing
                If isSelecting Then Return New DateRange(rangeStart, rangeStart)
                Return SelectedRanges(0)
            End Function
            Protected Overrides Function CreateSelectedRanges() As DateRangeCollection
                Return New SelectedRangesCollection(Me)
            End Function
            Protected Overrides Function CreateSelectionManager() As CalendarSelectionManager
                Return New DateRangeCalendarSelectionManager(Me)
            End Function
            Protected Overrides Sub AssignProperties(item As RepositoryItemDateEdit)
                Using calendarTimeProperties = New RepositoryItemTimeEdit()
                    calendarTimeProperties.Assign(item.CalendarTimeProperties)
                    Dim selectionMode = item.SelectionMode
                    Dim timeEditWidth As Integer = item.TimeEditWidth
                    Dim borderStyle = item.BorderStyle
                    Dim calendarTimeEditing = item.CalendarTimeEditing
                    item.BeginUpdate()
                    item.BorderStyle = BorderStyles.NoBorder
                    item.CalendarTimeEditing = CalendarTimeEditing
                    item.CalendarTimeProperties.Assign(CalendarTimeProperties)
                    item.SelectionMode = SelectionMode
                    item.TimeEditWidth = TimeEditWidth
                    MyBase.AssignProperties(item)
                    RightToLeft = WindowsFormsSettings.GetRightToLeft(Me)
                    item.BorderStyle = borderStyle
                    item.CalendarTimeEditing = calendarTimeEditing
                    item.CalendarTimeProperties.Assign(calendarTimeProperties)
                    item.SelectionMode = selectionMode
                    item.TimeEditWidth = timeEditWidth
                    item.EndUpdate()
                End Using
            End Sub
            Protected Friend Sub Assign(item As RepositoryItemDateEdit)
                Me.AssignProperties(item)
            End Sub
            Protected Overrides Function GetHasRaiseCustomDrawDayNumberCellSubscribers() As Boolean
                Return True
            End Function
            Protected Overrides Sub RaiseCustomDrawDayNumberCell(e As CustomDrawDayNumberCellEventArgs)
                MyBase.RaiseCustomDrawDayNumberCell(e)
                If SelectedRanges.Count < 1 Then Return
                Dim range = SelectedRanges(0)
                If range.StartDate < e.Date AndAlso e.Date < range.EndDate Then
                    If e.Style.BackColor.IsEmpty Then Return
                    If e.Date = DateTime Then Return
                    e.Style.BackColor = Color.FromArgb(100, e.Style.BackColor)
                End If
            End Sub
            Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
                MyBase.OnMouseMove(e)
                If isSelecting Then
                    SelectedRanges.BeginUpdate()
                    SelectedRanges.Clear()
                    If HotDate.HasValue Then
                        SelectedRanges.Add(New DateRange(rangeStart, HotDate.Value))
                        DateTime = HotDate.Value
                    End If
                    SelectedRanges.EndUpdate()
                Else
                    If e.Button = MouseButtons.Left Then
                        If HotDate.HasValue Then
                            SelectedRanges.BeginUpdate()
                            SelectedRanges.Clear()
                            SelectedRanges.Add(New DateRange(HotDate.Value, HotDate.Value))
                            SelectedRanges.EndUpdate()
                        End If
                    End If
                End If
            End Sub
            Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
                MyBase.OnKeyDown(e)
                If Not isSelecting Then Return
                SelectedRanges.BeginUpdate()
                SelectedRanges.Clear()
                SelectedRanges.Add(New DateRange(rangeStart, DateTime))
                SelectedRanges.EndUpdate()
            End Sub
            Protected Overrides Sub OnDateTimeCommit(value As Object)
                MyBase.OnDateTimeCommit(value)
                If Not isSelecting Then
                    isSelecting = True
                    rangeStart = DateTime
                    Return
                End If
                isSelecting = False
                Owner.EditValue = New DateRange(rangeStart, DateTime)
                Owner.ClosePopup()
            End Sub
            Public Overrides Sub ResetState(editDate As Object, dateTime As Date)
                isSelecting = False
                MyBase.ResetState(editDate, dateTime)
            End Sub
            '
            Public Class SelectedRangesCollection
                Inherits DateRangeCollection
                Public Overloads ReadOnly Property Owner As DateRangeCalendar
                    Get
                        Return TryCast(MyBase.Owner, DateRangeCalendar)
                    End Get
                End Property
                Public Sub New(owner As DateRangeCalendar)
                    MyBase.New(owner)
                End Sub
                Protected Overrides Sub InsertItem(index As Integer, item As DateRange)
                    If Count <> 0 Then ClearItems()
                    MyBase.InsertItem(0, item)
                End Sub
                Public Overrides Function IsDateSelected([date] As Date) As Boolean
                    If Count = 0 Then Return False
                    [date] = [date].Date
                    If Owner.DateTime.Date.Equals([date].Date) Then Return True
                    For Each range As DateRange In Me
                        If range.StartDate.Date <= [date] AndAlso [date] <= range.EndDate Then Return True
                    Next
                    Return False
                End Function
            End Class
            Public Class DateRangeCalendarSelectionManager
                Inherits CalendarSelectionManager
                Public Sub New(calendar As CalendarControlBase)
                    MyBase.New(calendar)
                End Sub
                Protected Overrides Function CanUpdateSelectionOnMouseDown(hitInfo As CalendarHitInfo) As Boolean
                    Return False
                End Function
                Protected Overrides Function CanUpdateSelectionOnMouseMove(hitInfo As CalendarHitInfo) As Boolean
                    Return False
                End Function
            End Class
        End Class
#End Region

#Region "SmartTagFilter"
        Public Class DateRangePickerFilter
            Inherits ControlFilter
            Implements ISmartTagFilter2, ISmartTagFilter
            Private ReadOnly hiddenActions As HashSet(Of String) = New HashSet(Of String) From {
                "EditBehavior",
                "Buttons"
            }
            Private ReadOnly hiddenActionProperties As HashSet(Of String) = New HashSet(Of String) From {
                "EditorType"
            }
            Public Overrides Function FilterMethod(methodName As String, actionMethodItem As Object) As Boolean
                If hiddenActions.Contains(methodName) Then Return False
                Return MyBase.FilterMethod(methodName, actionMethodItem)
            End Function
            Public Shadows Function FilterProperty(descriptor As MemberDescriptor, actionPropertyItem As Object) As Boolean
                Return Not hiddenActionProperties.Contains(descriptor.Name)
            End Function

            Private Function ISmartTagFilter2_FilterProperty(descriptor As MemberDescriptor, actionPropertyItem As Object) As Boolean Implements ISmartTagFilter2.FilterProperty
                Return FilterProperty(descriptor, actionPropertyItem)
            End Function
        End Class
#End Region
    End Class
End Namespace
