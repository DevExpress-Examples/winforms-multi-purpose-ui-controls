namespace DevExpress.UITemplates.Collection.Editors {
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using DevExpress.UITemplates.Collection.Components;
    using DevExpress.UITemplates.Collection.Editors.Base;
    using DevExpress.Utils;
    using DevExpress.Utils.Design;
    using DevExpress.Utils.Html;
    using DevExpress.XtraEditors.Internal;

    [SmartTagAction(typeof(HtmlItemsControlActions), "AddItem", "Add Item", SmartTagActionType.RefreshBoundsAfterExecute | SmartTagActionType.RefreshContentAfterExecute)]
    public abstract class ButtonGroupBase : HtmlButtonBase, IHtmlItemsControl {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        static ButtonGroupBase() {
            Components.ItemsSelector.Register();
        }
        readonly ButtonGroupItem.Collection itemsCore;
        protected ButtonGroupBase() {
            itemsCore = CreateItemsCollection();
            Items.CollectionChanged += OnItemsCollectionChanged;
        }
        protected override void Dispose(bool disposing) {
            if(selectorElement != null)
                selectorElement.RemoveEventListener("selection-changed", OnItemsSelectorSelectionChanged);
            Items.CollectionChanged -= OnItemsCollectionChanged;
            base.Dispose(disposing);
        }
        protected virtual ButtonGroupItem.Collection CreateItemsCollection() {
            return new ButtonGroupItem.Collection();
        }
        protected virtual void OnItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            if(selectorElement != null)
                selectorElement.SetAttribute(nameof(ItemsSelector.Items), Items);
            OnPropertiesChanged();
        }
        DxHtmlElement? selectorElement;
        protected override void FindParts(Dictionary<object, DxHtmlElement> parts, DxHtmlRootElement root) {
            base.FindParts(parts, root);
            selectorElement = root.FindElementsByTag("items-selector").FirstOrDefault();
            if(selectorElement != null) {
                selectorElement.SetAttribute(nameof(ItemSize), ItemSize);
                SetupItemsSelector(selectorElement);
                selectorElement.AddEventListener("selection-changed", OnItemsSelectorSelectionChanged);
            }
        }
        protected abstract void SetupItemsSelector(DxHtmlElement selectorElement);
        protected abstract void OnItemsSelectorSelectionChanged(DxHtmlElementEventArgs args);
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(DevExpress.Utils.Design.DXCollectionEditorBase), typeof(System.Drawing.Design.UITypeEditor)), Localizable(true)]
        [System.ComponentModel.Category("Data")]
        public ButtonGroupItem.Collection Items {
            get { return itemsCore; }
        }
        Components.ItemsSelector.Size itemSizeCore;
        [System.ComponentModel.Category("Layout"), DefaultValue(Components.ItemsSelector.Size.Default)]
        public Components.ItemsSelector.Size ItemSize {
            get { return itemSizeCore; }
            set {
                if(itemSizeCore == value) return;
                itemSizeCore = value;
                SetItemsSelectorItemSize(value);
            }
        }
        [Browsable(false), DefaultValue(null), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text {
            get { return base.Text; }
            set { base.Text = value; }
        }
        #endregion Properties
        #region API
        protected void UpdateItemsSelectorSelection() {
            if(selectorElement != null) {
                var selector = selectorElement.GetAttribute("self") as Components.ItemsSelector;
                if(selector != null) 
                    selector.UpdateSelection();
            }
        }
        protected ButtonGroupItem? GetItemsSelectorSelectedItem() {
            return selectorElement?.GetAttribute(nameof(Components.ItemsSelector.SelectedItem)) as ButtonGroupItem;
        }
        protected void SetItemsSelectorSelectedItem(ButtonGroupItem? value) {
            if(selectorElement != null)
                selectorElement.SetAttribute(nameof(Components.ItemsSelector.SelectedItem), value);
        }
        protected void SetItemsSelectorItemSize(Components.ItemsSelector.Size value) {
            if(selectorElement != null)
                selectorElement.SetAttribute(nameof(ItemSize), value);
        }
        #endregion
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e) {
            var dxArgs = DXMouseEventArgs.GetMouseArgs(e);
            dxArgs.Handled = GetValidationCanceled();
            base.OnMouseUp(dxArgs);
        }
        protected override bool IsAutoHeight {
            get { return false; }
        }
        protected override bool IsAutoWidth {
            get { return AutoSize; }
        }
        void IHtmlItemsControl.OnInitializeNewComponent() {
            Items.Add(new ButtonGroupItem(1, "Item 1"));
            Items.Add(new ButtonGroupItem(2, "Item 2"));
        }
        void IHtmlItemsControl.AddItem() {
            Items.Add(new ButtonGroupItem(Items.Count + 1, "Item " + (Items.Count + 1)));
        }
    }
}
