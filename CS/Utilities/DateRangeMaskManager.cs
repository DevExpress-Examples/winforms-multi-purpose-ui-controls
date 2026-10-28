namespace DevExpress.UITemplates.Collection.Utilities {
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using DevExpress.Data.Mask;
    using DevExpress.XtraEditors.Controls;

    [AutoInstall, Compatible(typeof(DateTimeMaskManager))]
    public class DateRangeMaskManager : MaskManager {
        public static void Register() {
            RegisterMaskManagerType(typeof(DateRangeMaskManager));
            RegisterMaskManagerInfo(typeof(DateRangeMaskManager), null, description: "Mask to enter date ranges");
            RegisterMaskManagerInfo(typeof(DateRangeMaskManager),
                standardMaskSpecifiers: new ManagerInfo.StandardMaskSpecifier[] {
                    new ManagerInfo.StandardMaskSpecifier(null, "Short date format", "d", DateTime.Now.ToShortDateString() + Separator + DateTime.Now.AddDays(5).ToShortDateString()),
                    new ManagerInfo.StandardMaskSpecifier(null, "Month/day format", "m", DateTime.Now.ToString("m") + Separator + DateTime.Now.AddDays(35).ToString("m"))
                },
                customPlaceholders: null, 
                helpLink: null, standardHelpLink: null, customHelpLink: null, advancedSettingsLink: null);
        }
        //
        [Parameters("UITemplatesExample, DevExpress.UITemplates.Collection.Utilities.DateRangeMaskManager", "Date Ranges")]
        public DateRangeMaskManager(
            [Parameter("mask", "Mask Expression")]
            string mask,
            [Parameter("cultureInfo")]
            [Parameter("culture", typeof(CultureInfoConverter), "Culture (name)", Visibility = ParameterVisibility.Advanced)]
            CultureInfo cultureInfo) {
            this.NestedManagers = InitializeNestedManagers(mask, cultureInfo);
        }
        MaskManager[] InitializeNestedManagers(string mask, CultureInfo cultureInfo) {
            var nestedManagers = new MaskManager[] {
                    new DateTimeMaskManager(mask, true, cultureInfo, true, true),
                    new DateTimeMaskManager(mask, true, cultureInfo, true, true)
                };
            foreach(MaskManager nested in nestedManagers) {
                nested.EditTextChanging += Nested_EditTextChanging;
                nested.EditTextChanged += Nested_EditTextChanged;
                nested.LocalEditAction += Nested_LocalEditAction;
            }
            return nestedManagers;
        }
        void Nested_EditTextChanging(object? sender, MaskChangingEventArgs e) {
            if(!e.Cancel && e.NewValue is DateTime) {
                DateTime date = (DateTime)e.NewValue;
                if(Index == 0) {
                    if(date > RangeEnd)
                        e.Cancel = true;
                }
                else {
                    if(date < RangeStart)
                        e.Cancel = true;
                }
            }
            if(!e.Cancel)
                e.Cancel = !RaiseEditTextChanging(e.NewValue);
        }
        void Nested_EditTextChanged(object? sender, EventArgs e) {
            RaiseEditTextChanged();
        }
        void Nested_LocalEditAction(object? sender, CancelEventArgs e) {
            e.Cancel = !RaiseModifyWithoutEditValueChange();
        }
        DateTime RangeStart {
            get { return (DateTime)(NestedManagers[0].GetCurrentEditValue() ?? DateTime.MinValue); }
        }
        DateTime RangeEnd {
            get { return (DateTime)(NestedManagers[1].GetCurrentEditValue() ?? DateTime.MaxValue); }
        }
        public override string GetCurrentEditText() {
            throw new NotImplementedException();
        }
        public override object GetCurrentEditValue() {
            var startDate = (DateTime?)NestedManagers[0].GetCurrentEditValue();
            var endDate = (DateTime?)NestedManagers[1].GetCurrentEditValue();
            if(startDate.HasValue && endDate.HasValue)
                return new DateRange(startDate.Value, endDate.Value);
            if(startDate.HasValue)
                return new DateRange(startDate.Value, startDate.Value);
            if(endDate.HasValue)
                return new DateRange(endDate.Value, endDate.Value);
            return new DateRange();
        }
        public override void SetInitialEditText(string initialEditText) {
            throw new NotImplementedException();
        }
        public override void SetInitialEditValue(object initialEditValue) {
            if(!(initialEditValue is DateRange)) {
                foreach(var m in NestedManagers)
                    m.SetInitialEditValue(null);
            }
            else {
                var range = (DateRange)initialEditValue;
                NestedManagers[0].SetInitialEditValue(range.StartDate);
                NestedManagers[0].SelectAll();
                NestedManagers[1].SetInitialEditValue(range.EndDate);
                NestedManagers[1].SelectAll();
            }
            Index = 0;
        }
        public const string Separator = " - ";
        protected readonly MaskManager[] NestedManagers;
        protected int Index;
        protected MaskManager ActiveManager {
            get { return NestedManagers[Index]; }
        }
        public override string DisplayText {
            get { return string.Join(Separator, NestedManagers.Select(m => m.DisplayText)); }
        }
        protected int ActiveDisplayOffset {
            get { return Enumerable.Range(0, Index).Sum(i => NestedManagers[i].DisplayText.Length + Separator.Length); }
        }
        public override int DisplayCursorPosition {
            get { return ActiveDisplayOffset + ActiveManager.DisplayCursorPosition; }
        }
        public override int DisplaySelectionAnchor {
            get { return ActiveDisplayOffset + ActiveManager.DisplaySelectionAnchor; }
        }
        public override bool CanUndo {
            get { return ActiveManager.CanUndo; }
        }
        public override bool Backspace() {
            return ActiveManager.Backspace();
        }
        public override bool CursorEnd(bool forceSelection) {
            if(Index == NestedManagers.Length - 1 && ActiveManager.DisplaySelectionLength == ActiveManager.DisplayText.Length)
                return false;
            ActiveManager.FlushPendingEditActions();
            Index = NestedManagers.Length - 1;
            ActiveManager.SelectAll();
            return true;
        }
        public override bool CursorHome(bool forceSelection) {
            if(Index == 0 && ActiveManager.DisplaySelectionLength == ActiveManager.DisplayText.Length)
                return false;
            ActiveManager.FlushPendingEditActions();
            Index = NestedManagers.Length - 1;
            ActiveManager.SelectAll();
            return true;
        }
        public override bool CursorMoveNear(bool forceSelection, bool isNeededKeyCheck) {
            if(ActiveManager.DisplaySelectionLength != ActiveManager.DisplayText.Length) {
                bool nestedResult = ActiveManager.CursorMoveNear(forceSelection, isNeededKeyCheck);
                if(nestedResult || forceSelection)
                    return nestedResult;
            }
            if(Index == 0)
                return false;
            if(isNeededKeyCheck)
                return true;
            ActiveManager.FlushPendingEditActions();
            --Index;
            ActiveManager.SelectAll();
            return true;
        }
        public override bool CursorMoveFar(bool forceSelection, bool isNeededKeyCheck) {
            if(ActiveManager.DisplaySelectionLength != ActiveManager.DisplayText.Length) {
                bool nestedResult = ActiveManager.CursorMoveFar(forceSelection, isNeededKeyCheck);
                if(nestedResult || forceSelection)
                    return nestedResult;
            }
            if(Index == NestedManagers.Length - 1)
                return false;
            if(isNeededKeyCheck)
                return true;
            ActiveManager.FlushPendingEditActions();
            ++Index;
            ActiveManager.SelectAll();
            return true;
        }
        public override bool CursorToDisplayPosition(int newPosition, bool forceSelection) {
            int runningoffset = 0, i = 0;
            do {
                runningoffset += NestedManagers[i].DisplayText.Length + Separator.Length;
                ++i;
            }
            while(newPosition >= runningoffset - Separator.Length / 2);
            int toEditorIndex = i - 1;
            if(toEditorIndex == Index)
                return ActiveManager.CursorToDisplayPosition(newPosition - ActiveDisplayOffset, forceSelection);
            if(forceSelection)
                return false;
            else {
                ActiveManager.FlushPendingEditActions();
                Index = toEditorIndex;
                ActiveManager.CursorToDisplayPosition(newPosition - ActiveDisplayOffset, forceSelection);
                return true;
            }
        }
        public override bool Delete() {
            return ActiveManager.Delete();
        }
        public override bool Insert(string insertion) {
            return ActiveManager.Insert(insertion);
        }
        public override void SelectAll() {
            ActiveManager.SelectAll();
        }
        public override bool FlushPendingEditActions() {
            bool result = false;
            for(int i = 0; i < NestedManagers.Length; ++i)
                result |= NestedManagers[i].FlushPendingEditActions();
            return result;
        }
        public override bool SpinDown() {
            return ActiveManager.SpinDown();
        }
        public override bool SpinUp() {
            return ActiveManager.SpinUp();
        }
        public override bool Undo() {
            return ActiveManager.Undo();
        }
    }
}
