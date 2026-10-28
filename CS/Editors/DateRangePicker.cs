namespace DevExpress.UITemplates.Collection.Editors {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;
    using UITemplatesExample.Assets.Toolbox; 
    using DevExpress.UITemplates.Collection.Utilities;
    using DevExpress.Utils;
    using DevExpress.Utils.Design;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Calendar;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ToolboxBitmapRoot), "DateRangePicker.bmp")]
    [Description("A text box with a dropdown calendar that allows you to select a date range.")]
    [DevExpress.Utils.Design.SmartTagFilter(typeof(DateRangePickerFilter))]
    public class DateRangePicker : PopupContainerEdit {
        readonly DateRangeCalendar calendarCore;
        bool hasPropertyChanges = true;
        public DateRangePicker() {
            calendarCore = CreateDateRangeCalendar();
            Initialize();
        }
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            calendarCore.Dispose();
        }
        protected internal DateRangeCalendar Calendar {
            get { return calendarCore; }
        }
        protected internal PopupContainerControl PopupContainer {
            get { return Properties.PopupControl; }
        }
        protected virtual DateRangeCalendar CreateDateRangeCalendar() {
            return new DateRangeCalendar(this);
        }
        protected virtual PopupContainerControl CreatePopupContainer() {
            return new PopupContainerControl();
        }
        void Initialize() {
            Calendar.Dock = DockStyle.Fill;
            Calendar.Name = "calendarControl";
            Calendar.SyncSelectionWithEditValue = false;
            SyncEditValue(EditValue as DateRange ?? NullValue);
            PopupContainer.Controls.Add(Calendar);
            PopupContainer.Name = "popupContainerControl";
            PopupContainer.Size = new Size(Width, 400);
        }
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [System.ComponentModel.Category(CategoryName.Properties)]
        public new RepositoryItemDateRangePicker Properties {
            get { return (RepositoryItemDateRangePicker)base.Properties; }
        }
        protected override RepositoryItem CreateRepositoryItemCore() {
            return new RepositoryItemDateRangePicker();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get { return base.EditValue; }
            set {
                DateRange? range = value as DateRange ?? NullValue;
                if(base.EditValue != range) {
                    base.EditValue = range;
                    SyncEditValue(range);
                }
            }
        }
        void SyncEditValue(DateRange? range) {
            var selectedRanges = Calendar.SelectedRanges;
            selectedRanges.BeginUpdate();
            selectedRanges.Clear();
            selectedRanges.Add(range);
            selectedRanges.EndUpdate();
        }

        DateRange? nullValue;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateRange? NullValue {
            get { return nullValue; }
            set {
                if(nullValue == value)
                    return;
                if(value == null)
                    nullValue = new DateRange(DateTime.Today, DateTime.Today);
                else
                    nullValue = value;
            }
        }
        [Browsable(false)]
        public DateTime StartDate {
            get { return (EditValue as DateRange)?.StartDate ?? DateTime.MinValue; }
        }
        [Browsable(false)]
        public DateTime EndDate {
            get { return (EditValue as DateRange)?.EndDate ?? DateTime.MinValue; }
        }
        protected override void InitializeDefaultProperties() {
            base.InitializeDefaultProperties();
            fEditValue = new DateRange(DateTime.Today, DateTime.Today);
            NullValue = new DateRange(DateTime.Today, DateTime.Today);
            Properties.TextEditStyle = TextEditStyles.Standard;
            Properties.PopupControl = CreatePopupContainer();
            Properties.CalendarProperties.BeginUpdate();
            Properties.CalendarProperties.ColumnCount = 2;
            Properties.CalendarProperties.HighlightTodayCell = DevExpress.Utils.DefaultBoolean.False;
            Properties.CalendarProperties.ShowClear = false;
            Properties.CalendarProperties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.True;
            Properties.CalendarProperties.ShowToday = false;
            Properties.CalendarProperties.EndUpdate();
        }
        public class RepositoryItemDateRangePicker : RepositoryItemPopupContainerEdit {
            public RepositoryItemDateRangePicker() {
                CalendarProperties = CreateCalendarProperties();
                CalendarProperties.PropertiesChanged += OnCalendarPropertiesChanged;
            }
            protected override void Dispose(bool disposing) {
                base.Dispose(disposing);
                CalendarProperties.PropertiesChanged -= OnCalendarPropertiesChanged;
            }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public RepositoryItemDateEdit CalendarProperties {
                get;
                private set;
            }
            protected virtual RepositoryItemDateEdit CreateCalendarProperties() {
                return new RepositoryItemDateEdit();
            }
            protected virtual void OnCalendarPropertiesChanged(object? sender, EventArgs e) {
                OnPropertiesChanged();
            }
            protected override Type GetDefaultMaskManagerType() {
                return typeof(DateRangeMaskManager);
            }
            protected override bool ShouldCreateMaskSettingsWhenMaskLoadedOrUpdated {
                get { return true; }
            }
            protected override string GetDefaultEditMask(CultureInfo culture) {
                return "d";
            }
            public override BaseEdit CreateEditor() {
                return new DateRangePicker();
            }
        }
        #endregion Properties
        //
        protected override void OnMaskEditValueChanging(ChangingEventArgs e) {
            if(e.NewValue is DateTime) {
                DateTime maskEditValue = (DateTime)e.NewValue;
                if(maskEditValue < Properties.CalendarProperties.MinValue)
                    e.Cancel = true;
                if(maskEditValue > Properties.CalendarProperties.MaxValue)
                    e.Cancel = true;
            }
        }
        protected override void OnValidatingCore(CancelEventArgs e) {
            if(StartDate < Properties.CalendarProperties.MinValue)
                e.Cancel = true;
            if(EndDate > Properties.CalendarProperties.MaxValue)
                e.Cancel = true;
        }
        protected override void OnPopupClosed(PopupCloseMode closeMode) {
            base.OnPopupClosed(closeMode);
            if(closeMode != PopupCloseMode.Cancel) {
                DateRange? currentRange = Calendar.GetCurrentRange();
                if(currentRange != null)
                    EditValue = currentRange;
            }
            else {
                SyncEditValue(EditValue as DateRange ?? NullValue);
                Calendar.ResetState(StartDate, EndDate);
            }
        }
        protected virtual void EnsurePopupControlCreated() {
            if(PopupContainer == null) {
                Properties.PopupControl = CreatePopupContainer();
                Initialize();
            }
        }
        public override void ShowPopup() {
            EnsurePopupControlCreated();
            if(hasPropertyChanges) {
                Calendar.Assign(Properties.CalendarProperties);
                Properties.PopupFormMinSize = Calendar.PreferredSize;
                PopupContainer.Size = Calendar.PreferredSize;
                hasPropertyChanges = false;
            }
            Calendar.ResetState(StartDate, StartDate);
            base.ShowPopup();
        }
        protected override void OnPropertiesChanged() {
            base.OnPropertiesChanged();
            hasPropertyChanges = true;
        }
        #region DateRangeCalendar
        public class DateRangeCalendar : CalendarControl {
            bool isSelecting;
            DateTime rangeStart;
            public DateRangeCalendar(PopupContainerEdit owner) {
                Owner = owner;
            }
            protected PopupContainerEdit Owner { 
                get; 
                private set;
            }
            public DateRange? GetCurrentRange() {
                if(SelectedRanges.Count < 1)
                    return null;
                if(isSelecting)
                    return new DateRange(rangeStart, rangeStart);
                return SelectedRanges[0];
            }
            protected override DateRangeCollection CreateSelectedRanges() {
                return new SelectedRangesCollection(this);
            }
            protected override CalendarSelectionManager CreateSelectionManager() {
                return new DateRangeCalendarSelectionManager(this);
            }
            protected override void AssignProperties(RepositoryItemDateEdit item) {
                using(var calendarTimeProperties = new RepositoryItemTimeEdit()) {
                    calendarTimeProperties.Assign(item.CalendarTimeProperties);
                    var selectionMode = item.SelectionMode;
                    int timeEditWidth = item.TimeEditWidth;
                    var borderStyle = item.BorderStyle;
                    var calendarTimeEditing = item.CalendarTimeEditing;
                    item.BeginUpdate();
                    item.BorderStyle = BorderStyles.NoBorder;
                    item.CalendarTimeEditing = CalendarTimeEditing;
                    item.CalendarTimeProperties.Assign(CalendarTimeProperties);
                    item.SelectionMode = SelectionMode;
                    item.TimeEditWidth = TimeEditWidth;
                    base.AssignProperties(item);
                    RightToLeft = WindowsFormsSettings.GetRightToLeft(this);
                    item.BorderStyle = borderStyle;
                    item.CalendarTimeEditing = calendarTimeEditing;
                    item.CalendarTimeProperties.Assign(calendarTimeProperties);
                    item.SelectionMode = selectionMode;
                    item.TimeEditWidth = timeEditWidth;
                    item.EndUpdate();
                }
            }
            protected internal void Assign(RepositoryItemDateEdit item) {
                AssignProperties(item);
            }
            protected override bool GetHasRaiseCustomDrawDayNumberCellSubscribers() { return true; }
            protected override void RaiseCustomDrawDayNumberCell(CustomDrawDayNumberCellEventArgs e) {
                base.RaiseCustomDrawDayNumberCell(e);
                if(SelectedRanges.Count < 1)
                    return;
                var range = SelectedRanges[0];
                if(range.StartDate < e.Date && e.Date < range.EndDate) {
                    if(e.Style.BackColor.IsEmpty)
                        return;
                    if(e.Date == DateTime)
                        return;
                    e.Style.BackColor = Color.FromArgb(100, e.Style.BackColor);
                }
            }
            protected override void OnMouseMove(MouseEventArgs e) {
                base.OnMouseMove(e);
                if(isSelecting) {
                    SelectedRanges.BeginUpdate();
                    SelectedRanges.Clear();
                    if(HotDate.HasValue) {
                        SelectedRanges.Add(new DateRange(rangeStart, HotDate.Value));
                        DateTime = HotDate.Value;
                    }
                    SelectedRanges.EndUpdate();
                } else {
                    if(e.Button == MouseButtons.Left)
                        if(HotDate.HasValue) {
                            SelectedRanges.BeginUpdate();
                            SelectedRanges.Clear();
                            SelectedRanges.Add(new DateRange(HotDate.Value, HotDate.Value));
                            SelectedRanges.EndUpdate();
                        }
                }
            }
            protected override void OnKeyDown(KeyEventArgs e) {
                base.OnKeyDown(e);
                if(!isSelecting)
                    return;
                SelectedRanges.BeginUpdate();
                SelectedRanges.Clear();
                SelectedRanges.Add(new DateRange(rangeStart, DateTime));
                SelectedRanges.EndUpdate();
            }
            protected override void OnDateTimeCommit(object value) {
                base.OnDateTimeCommit(value);
                if(!isSelecting) {
                    isSelecting = true;
                    rangeStart = DateTime;
                    return;
                }
                isSelecting = false;
                Owner.EditValue = new DateRange(rangeStart, DateTime);
                Owner.ClosePopup();
            }
            public override void ResetState(object editDate, DateTime dateTime) {
                isSelecting = false;
                base.ResetState(editDate, dateTime);
            }
            //
            public class SelectedRangesCollection : DateRangeCollection {
                public new DateRangeCalendar? Owner => base.Owner as DateRangeCalendar;
                public SelectedRangesCollection(DateRangeCalendar owner)
                    : base(owner) {
                }
                protected override void InsertItem(int index, DateRange item) {
                    if(Count != 0)
                        ClearItems();
                    base.InsertItem(0, item);
                }
                public override bool IsDateSelected(DateTime date) {
                    if(Count == 0)
                        return false;
                    date = date.Date;
                    if(Owner != null && Owner.DateTime.Date.Equals(date.Date))
                        return true;
                    foreach(DateRange range in this) {
                        if(range.StartDate.Date <= date && date <= range.EndDate)
                            return true;
                    }
                    return false;
                }
            }
            public class DateRangeCalendarSelectionManager : CalendarSelectionManager {
                public DateRangeCalendarSelectionManager(CalendarControlBase calendar) : base(calendar) { }
                protected override bool CanUpdateSelectionOnMouseDown(CalendarHitInfo hitInfo) {
                    return false;
                }
                protected override bool CanUpdateSelectionOnMouseMove(CalendarHitInfo hitInfo) {
                    return false;
                }
            }
        }
        #endregion DateRangeCalendar

        #region SmartTagFilter
        public class DateRangePickerFilter : ControlFilter, ISmartTagFilter2, ISmartTagFilter {
            readonly HashSet<string> hiddenActions = new HashSet<string> { "EditBehavior", "Buttons" };
            readonly HashSet<string> hiddenActionProperties = new HashSet<string> { "EditorType" };
            public override bool FilterMethod(string methodName, object actionMethodItem) {
                if(hiddenActions.Contains(methodName))
                    return false;
                return base.FilterMethod(methodName, actionMethodItem);
            }
            public bool FilterProperty(MemberDescriptor descriptor, object actionPropertyItem) {
                return !hiddenActionProperties.Contains(descriptor.Name);
            }
        }
        #endregion
    }
}
