namespace DevExpress.UITemplates.Collection.Editors {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using UITemplatesExample.Assets.Toolbox; 
    using DevExpress.UITemplates.Collection.Components;
    using DevExpress.UITemplates.Collection.Utilities;
    using DevExpress.Utils.Html;

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ToolboxBitmapRoot), "MultiSelectChipGroup.bmp")]
    [Description("A chip group with multi value selection support.")]
    public class MultiSelectChipGroup : ChipGroupBase {
        readonly Chip.Selection selectionCore = new Chip.Selection();
        protected override void Dispose(bool disposing) {
            selectionCore.Clear();
            base.Dispose(disposing);
        }
        protected override void SetupItemsSelector(DxHtmlElement selectorElement) {
            selectorElement.SetAttribute(nameof(ItemsSelector.IsMultiSelect), true);
            selectorElement.SetAttribute(nameof(ItemsSelector.Selection), Selection);
        }
        protected override void OnItemsSelectorSelectionChanged(DxHtmlElementEventArgs args) {
            RaiseSelectionChanged();
            RaiseSelectedValuesChanged();
        }
        #region Properties
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Chip.Selection Selection {
            get { return selectionCore; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HashSet<object> SelectedValues {
            get { return Items.GetValues(Selection); }
        }
        #endregion Properties
        #region Events
        readonly static object selectionChanged = new object();
        readonly static object selectedValuesChanged = new object();
        //
        public event EventHandler SelectionChanged {
            add { Events.AddHandler(selectionChanged, value); }
            remove { Events.RemoveHandler(selectionChanged, value); }
        }
        protected void RaiseSelectionChanged() {
            var handler = Events[selectionChanged] as EventHandler;
            handler?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler SelectedValuesChanged {
            add { Events.AddHandler(selectedValuesChanged, value); }
            remove { Events.RemoveHandler(selectedValuesChanged, value); }
        }
        protected void RaiseSelectedValuesChanged() {
            var handler = Events[selectedValuesChanged] as EventHandler;
            handler?.Invoke(this, EventArgs.Empty);
        }
        #endregion Events
        #region Theme
        protected override string LoadDefaultTemplate() {
            return MultiSelectChipGroupHtmlCssAsset.Default.Html;
        }
        protected override string LoadDefaultStyles() {
            return MultiSelectChipGroupHtmlCssAsset.Default.Css;
        }
        sealed class MultiSelectChipGroupHtmlCssAsset : HtmlCssAsset {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            static MultiSelectChipGroupHtmlCssAsset() {
                ItemsSelector.Register();
            }
            public static readonly HtmlCssAsset Default = new MultiSelectChipGroupHtmlCssAsset();
        }
        #endregion Theme
        #region API
        public void SelectAll() {
            if(Selection.Count == Items.Count)
                return;
            Selection.Clear();
            foreach(Chip item in Items)
                Selection.Add(item);
            OnSelectionChanged();
        }
        public void UnselectAll() {
            if(Selection.Count == 0)
                return;
            Selection.Clear();
            OnSelectionChanged();
        }
        public void Select(Chip item) {
            if(Selection.Add(item))
                OnSelectionChanged();
        }
        public void SelectValue(object value) {
            var item = value as Chip ?? Items.GetItemByValue(value);
            if(item != null && Selection.Add(item)) 
                OnSelectionChanged();
        }
        public void Unselect(Chip item) {
            if(Selection.Remove(item))
                OnSelectionChanged();
        }
        public void UnselectValue(object value) {
            var item = value as Chip ?? Items.GetItemByValue(value);
            if(item != null && Selection.Remove(item))
                OnSelectionChanged();
        }
        public bool IsValueSelected(object value) {
            var item = value as Chip;
            return (item != null) ? Selection.Contains(item) : Selection.ContainsValue(value);
        }
        protected virtual void OnSelectionChanged() {
            UpdateItemsSelectorSelection();
            RaiseSelectionChanged();
            RaiseSelectedValuesChanged();
        }
        #endregion API
        protected override ICustomDxHtmlPreview CreateHtmlEditorPreview() {
            var previewControl = new MultiSelectChipGroup();
            previewControl.Items.AddRange(new Chip[] {
                new Chip(1,"One"),
                new Chip(2,"Two"),
                new Chip(3,"Three"),
            });
            previewControl.Select(previewControl.Items[0]);
            return previewControl;
        }
    }
}
