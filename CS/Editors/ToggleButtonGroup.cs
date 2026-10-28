namespace DevExpress.UITemplates.Collection.Editors {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using UITemplatesExample.Assets.Toolbox; 
    using DevExpress.UITemplates.Collection.Utilities;
    using DevExpress.Utils.Html;

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ToolboxBitmapRoot), "ToggleButtonGroup.bmp")]
    [Description("A set of two-state buttons that can be toggled on or off.")]
    public class ToggleButtonGroup : ButtonGroupBase {
        readonly ButtonGroupItem.Selection selectionCore = new ButtonGroupItem.Selection();
        protected override void Dispose(bool disposing) {
            selectionCore.Clear();
            base.Dispose(disposing);
        }
        protected override void SetupItemsSelector(DxHtmlElement selectorElement) {
            selectorElement.SetAttribute(nameof(Items), Items);
            selectorElement.SetAttribute(nameof(Components.ItemsSelector.IsMultiSelect), true);
            selectorElement.SetAttribute(nameof(Components.ItemsSelector.Selection), Selection);
        }
        protected override void OnItemsSelectorSelectionChanged(DxHtmlElementEventArgs args) {
            RaiseSelectionChanged();
            RaiseSelectedValuesChanged();
        }
        #region Properties
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ButtonGroupItem.Selection Selection {
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
            return ToggleButtonGroupHtmlCssAsset.Default.Html;
        }
        protected override string LoadDefaultStyles() {
            return ToggleButtonGroupHtmlCssAsset.Default.Css;
        }
        sealed class ToggleButtonGroupHtmlCssAsset : HtmlCssAsset {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            static ToggleButtonGroupHtmlCssAsset() {
                Components.ItemsSelector.Register();
            }
            public static readonly HtmlCssAsset Default = new ToggleButtonGroupHtmlCssAsset();
        }
        #endregion Theme
        #region API
        public void SelectAll() {
            if(Selection.Count == Items.Count)
                return;
            Selection.Clear();
            foreach(ButtonGroupItem item in Items)
                Selection.Add(item);
            OnSelectionChanged();
        }
        public void UnselectAll() {
            if(Selection.Count == 0)
                return;
            Selection.Clear();
            OnSelectionChanged();
        }
        public void Select(ButtonGroupItem item) {
            if(Selection.Add(item))
                OnSelectionChanged();
        }
        public void SelectValue(object value) {
            var item = value as ButtonGroupItem ?? Items.GetItemByValue(value);
            if(item != null && Selection.Add(item))
                OnSelectionChanged();
        }
        public void Unselect(ButtonGroupItem item) {
            if(Selection.Remove(item))
                OnSelectionChanged();
        }
        public void UnselectValue(object value) {
            var item = value as ButtonGroupItem ?? Items.GetItemByValue(value);
            if(item != null && Selection.Remove(item))
                OnSelectionChanged();
        }
        public bool IsValueSelected(object value) {
            var item = value as ButtonGroupItem;
            return (item != null) ? Selection.Contains(item) : Selection.ContainsValue(value);
        }
        protected virtual void OnSelectionChanged() {
            UpdateItemsSelectorSelection();
            RaiseSelectionChanged();
            RaiseSelectedValuesChanged();
        }
        #endregion API
        protected override ICustomDxHtmlPreview CreateHtmlEditorPreview() {
            var previewControl = new ToggleButtonGroup();
            previewControl.Items.AddRange(new ButtonGroupItem[] { 
                new ButtonGroupItem(1,"One"),
                new ButtonGroupItem(2,"Two"),
                new ButtonGroupItem(3,"Three"),
            });
            previewControl.Select(previewControl.Items[0]);
            return previewControl;
        }
    }
}
