namespace DevExpress.UITemplates.Collection.Editors {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using UITemplatesExample.Assets.Toolbox; 
    using DevExpress.UITemplates.Collection.Utilities;
    using DevExpress.Utils.Html;

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ToolboxBitmapRoot), "RadioButtonGroup.bmp")]
    [Description("A predesigned group of toggle buttons used to select a single option/value from multiple choices.")]
    public class RadioButtonGroup : ButtonGroupBase {
        protected override void SetupItemsSelector(DxHtmlElement selectorElement) {
            selectorElement.SetAttribute(nameof(Items), Items);
            selectorElement.SetAttribute(nameof(Components.ItemsSelector.IsMultiSelect), false);
            if(selectedItem != null)
                selectorElement.SetAttribute(nameof(SelectedItem), selectedItem);
        }
        protected override void OnItemsSelectorSelectionChanged(DxHtmlElementEventArgs args) {
            selectedItem = GetItemsSelectorSelectedItem();
            RaiseSelectedItemChanged();
            RaiseSelectedValueChanged();
        }
        #region Properties
        ButtonGroupItem? selectedItem;
        [Browsable(false), DefaultValue(null), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ButtonGroupItem? SelectedItem {
            get { return selectedItem; }
            set {
                if(selectedItem == value) return;
                selectedItem = value;
                OnSelectedItemChanged(value);
            }
        }
        protected virtual void OnSelectedItemChanged(ButtonGroupItem? item) {
            SetItemsSelectorSelectedItem(item);
            RaiseSelectedItemChanged();
            RaiseSelectedValueChanged();
        }
        [Browsable(false), DefaultValue(null), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object? SelectedValue {
            get { return selectedItem?.Value; }
            set { SelectedItem = (value as ButtonGroupItem) ?? Items.GetItemByValue(value); }
        }
        #endregion Properties
        #region Events
        readonly static object selectedItemChanged = new object();
        readonly static object selectedValueChanged = new object();
        //
        public event EventHandler SelectedItemChanged {
            add { Events.AddHandler(selectedItemChanged, value); }
            remove { Events.RemoveHandler(selectedItemChanged, value); }
        }
        protected void RaiseSelectedItemChanged() {
            var handler = Events[selectedItemChanged] as EventHandler;
            handler?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler SelectedValueChanged {
            add { Events.AddHandler(selectedValueChanged, value); }
            remove { Events.RemoveHandler(selectedValueChanged, value); }
        }
        protected void RaiseSelectedValueChanged() {
            var handler = Events[selectedValueChanged] as EventHandler;
            handler?.Invoke(this, EventArgs.Empty);
        }
        #endregion Events
        #region Theme
        protected override string LoadDefaultTemplate() {
            return RadioButtonGroupHtmlCssAsset.Default.Html;
        }
        protected override string LoadDefaultStyles() {
            return RadioButtonGroupHtmlCssAsset.Default.Css;
        }
        sealed class RadioButtonGroupHtmlCssAsset : HtmlCssAsset {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            static RadioButtonGroupHtmlCssAsset() {
                Components.ItemsSelector.Register();
            }
            public static readonly HtmlCssAsset Default = new RadioButtonGroupHtmlCssAsset();
        }
        #endregion Theme
        protected override ICustomDxHtmlPreview CreateHtmlEditorPreview() {
            var previewControl = new RadioButtonGroup();
            previewControl.Items.AddRange(new ButtonGroupItem[] {
                new ButtonGroupItem(1,"One"),
                new ButtonGroupItem(2,"Two"),
                new ButtonGroupItem(3,"Three"),
            });
            previewControl.SelectedItem = previewControl.Items[0];
            return previewControl;
        }
    }
}
