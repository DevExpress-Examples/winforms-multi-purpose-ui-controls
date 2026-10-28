namespace DevExpress.UITemplates.Collection.Editors {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.Skins;
    using UITemplatesExample.Assets.Toolbox; 
    using DevExpress.UITemplates.Collection.Components;
    using DevExpress.UITemplates.Collection.Utilities;
    using DevExpress.Utils;
    using DevExpress.Utils.Drawing;
    using DevExpress.Utils.Html;
    using DevExpress.XtraEditors.ButtonsPanelControl;
    using DevExpress.XtraEditors.Internal;

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ToolboxBitmapRoot), "TwinButton.bmp")]
    [Description("A button consisting of two buttons with opposing actions displayed side by side.")]
    public class TwinButton : HtmlButtonBase {
        readonly TwinButtonImageOptions firstIconImageOptionsCore;
        readonly TwinButtonImageOptions secondIconImageOptionsCore;
        public TwinButton() {
            this.firstIconImageOptionsCore = CreateImageOptions();
            this.firstIconImageOptionsCore.Changed += OnIconImageOptionsChanged;
            this.secondIconImageOptionsCore = CreateImageOptions();
            this.secondIconImageOptionsCore.Changed += OnIconImageOptionsChanged;
        }
        protected override void Dispose(bool disposing) {
            if(firstIconImageOptionsCore != null) {
                this.firstIconImageOptionsCore.Changed -= OnIconImageOptionsChanged;
                firstIconImageOptionsCore.Dispose();
            }
            if(secondIconImageOptionsCore != null) {
                this.secondIconImageOptionsCore.Changed -= OnIconImageOptionsChanged;
                secondIconImageOptionsCore.Dispose();
            }
            if(firstButtonElement != null)
                firstButtonElement.RemoveEventListener("item-click", OnButtonItemClick);
            if(secondButtonElement != null)
                secondButtonElement.RemoveEventListener("item-click", OnButtonItemClick);
            base.Dispose(disposing);
        }
        #region Properties
        public enum SizeType {
            Small = -1,
            Default = 0,
            Large = 1,
        }
        SizeType buttonSizeTypeCore = SizeType.Default;
        [DefaultValue(SizeType.Default), System.ComponentModel.Category("Layout")]
        public SizeType ButtonSize {
            get { return buttonSizeTypeCore; }
            set {
                if(buttonSizeTypeCore == value) return;
                buttonSizeTypeCore = value;
                OnButtonSizeChanged(value);
            }
        }
        protected virtual void OnButtonSizeChanged(SizeType value) {
            SetButtonElementSize(value);
            InvalidatePart(firstButtonElement);
            InvalidatePart(secondButtonElement);
            if(AutoSize) AdjustSize();
            OnPropertiesChanged();
        }
        protected virtual void SetButtonElementSize(SizeType value) {
            if(firstButtonElement != null)
                firstButtonElement.SetAttribute(nameof(TwinButtonItem.ItemSize), (TwinButtonItem.Size)(int)value);
            if(secondButtonElement != null)
                secondButtonElement.SetAttribute(nameof(TwinButtonItem.ItemSize), (TwinButtonItem.Size)(int)value);
        }
        [Utils.Design.SmartTagProperty("AutoSize", "", 3)]
        public override bool AutoSize {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
        string? firstTextCore;
        [DefaultValue(null), System.ComponentModel.Category("Text")]
        [Utils.Design.SmartTagProperty("First Text", "", 1, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute | Utils.Design.SmartTagActionType.RefreshContentAfterExecute)]
        public string? FirstText {
            get { return firstTextCore; }
            set {
                if(firstTextCore == value) return;
                firstTextCore = value;
                OnPropertiesChanged();
            }
        }
        string? secondTextCore;
        [DefaultValue(null), System.ComponentModel.Category("Text")]
        [Utils.Design.SmartTagProperty("Second Text", "", 1, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute | Utils.Design.SmartTagActionType.RefreshContentAfterExecute)]
        public string? SecondText {
            get { return secondTextCore; }
            set {
                if(secondTextCore == value) return;
                secondTextCore = value;
                OnPropertiesChanged();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override string Text {
            get { return $"{FirstText ?? "First"} {SecondText ?? "Second"}"; }
            set { }
        }
        [System.ComponentModel.Category(XtraEditors.CategoryName.Appearance), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Utils.Design.SmartTagProperty("FirstIcon", "", 2, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute | Utils.Design.SmartTagActionType.RefreshContentAfterExecute)]
        public TwinButtonImageOptions FirstIconImageOptions {
            get { return firstIconImageOptionsCore; }
        }
        [System.ComponentModel.Category(XtraEditors.CategoryName.Appearance), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Utils.Design.SmartTagProperty("SecondIcon", "", 2, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute | Utils.Design.SmartTagActionType.RefreshContentAfterExecute)]
        public TwinButtonImageOptions SecondIconImageOptions {
            get { return secondIconImageOptionsCore; }
        }
        protected virtual void OnIconImageOptionsChanged(object sender, ImageOptionsChangedEventArgs args) {
            shouldRaiseSizeableChanged = args.ImageSizeChanged;
            if(sender == firstIconImageOptionsCore)
                UpdatePartVisibility(firstButtonIcon);
            if(sender == secondIconImageOptionsCore)
                UpdatePartVisibility(secondButtonIcon);
            if(AutoSize) AdjustSize();
            OnPropertiesChanged();
        }
        protected virtual TwinButtonImageOptions CreateImageOptions() {
            return new TwinButtonImageOptions();
        }
        public class TwinButtonImageOptions : ButtonImageOptionsBase { }
        #endregion Properties
        #region Events
        readonly static object firstClick = new object();
        readonly static object secondClick = new object();
        //
        [System.ComponentModel.Category(XtraEditors.CategoryName.Action)]
        public event EventHandler FirstClick {
            add { Events.AddHandler(firstClick, value); }
            remove { Events.RemoveHandler(firstClick, value); }
        }
        protected void RaiseFirstClick() {
            var handler = Events[firstClick] as EventHandler;
            handler?.Invoke(this, EventArgs.Empty);
        }
        [System.ComponentModel.Category(XtraEditors.CategoryName.Action)]
        public event EventHandler SecondClick {
            add { Events.AddHandler(secondClick, value); }
            remove { Events.RemoveHandler(secondClick, value); }
        }
        protected void RaiseSecondClick() {
            var handler = Events[secondClick] as EventHandler;
            handler?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnButtonItemClick(DxHtmlElementEventArgs args) {
            activeElement = args.Element;
            if(args.Element.Id == nameof(firstButton))
                RaiseFirstClick();
            if(args.Element.Id == nameof(secondButton))
                RaiseSecondClick();
        }
        DxHtmlElement? clickTarget;
        public void PerformClick() {
            clickTarget = activeElement;
            try { PerformClickCore(); }
            finally { clickTarget = null; }
        }
        public void PerformFirstClick() {
            clickTarget = firstButtonElement;
            try { PerformClickCore(); }
            finally { clickTarget = null; }
        }
        public void PerformSecondClick() {
            clickTarget = secondButtonElement;
            try { PerformClickCore(); }
            finally { clickTarget = null; }
        }
        protected override void OnClick(EventArgs e) {
            base.OnClick(e);
            if(clickTarget == firstButtonElement)
                RaiseFirstClick();
            if(clickTarget == secondButtonElement)
                RaiseSecondClick();
        }
        #endregion Events
        #region Parts
        protected readonly static object firstButton = new object();
        protected readonly static object secondButton = new object();
        protected readonly static object icon = new object();
        protected readonly static object firstButtonIcon = new object();
        protected readonly static object secondButtonIcon = new object();
        //
        DxHtmlElement? firstButtonElement, secondButtonElement, activeElement;
        protected override void FindParts(Dictionary<object, DxHtmlElement> parts, DxHtmlRootElement root) {
            base.FindParts(parts, root);
            firstButtonElement = root.FindElementById(nameof(firstButton));
            secondButtonElement = root.FindElementById(nameof(secondButton));
            var iSize = (TwinButtonItem.Size)(int)ButtonSize;
            if(iSize != TwinButtonItem.Size.Default) {
                firstButtonElement.SetAttribute(nameof(TwinButtonItem.ItemSize), iSize);
                secondButtonElement.SetAttribute(nameof(TwinButtonItem.ItemSize), iSize);
            }
            var contentTemplateId = GetButtonContentTemplateId();
            firstButtonElement.SetAttribute(nameof(TwinButtonItem.Template), contentTemplateId);
            secondButtonElement.SetAttribute(nameof(TwinButtonItem.Template), contentTemplateId);
            firstButtonElement.AddEventListener("item-click", OnButtonItemClick);
            secondButtonElement.AddEventListener("item-click", OnButtonItemClick);
            parts[firstButton] = firstButtonElement;
            parts[secondButton] = secondButtonElement;
            parts[firstButtonIcon] = firstButtonElement.FindElementById(nameof(icon));
            parts[secondButtonIcon] = secondButtonElement.FindElementById(nameof(icon));
        }
        protected override void CalcPartsVisibility(Dictionary<object, DxHtmlElement> parts) {
            DxHtmlElement? firstIconElement;
            if(parts.TryGetValue(firstButtonIcon, out firstIconElement) && firstIconElement != null)
                firstIconElement.Hidden = !IsFirstIconVisible();
            DxHtmlElement? secondIconElement;
            if(parts.TryGetValue(secondButtonIcon, out secondIconElement) && secondIconElement != null)
                secondIconElement.Hidden = !IsSecondIconVisible();
        }
        protected virtual bool IsFirstIconVisible() {
            return FirstIconImageOptions.HasImage;
        }
        protected virtual bool IsSecondIconVisible() {
            return SecondIconImageOptions.HasImage;
        }
        protected override string GetPartText(string partName, DxHtmlElementBase element) {
            if(partName == "Item.Text") {
                if(TwinButtonItem.IsButtonElement(element, firstButtonElement))
                    return FirstText ?? "First";
                if(TwinButtonItem.IsButtonElement(element, secondButtonElement))
                    return SecondText ?? "Second";
            }
            return base.GetPartText(partName, element);
        }
        protected override object GetPartImage(string partName, ObjectState state, DxHtmlElementBase element) {
            if(partName == "Item.Icon") {
                if(TwinButtonItem.IsButtonElement(element, firstButtonElement))
                    return firstIconImageOptionsCore.GetImage(LookAndFeel, state);
                if(TwinButtonItem.IsButtonElement(element, secondButtonElement))
                    return secondIconImageOptionsCore.GetImage(LookAndFeel, state);
            }
            return base.GetPartImage(partName, state, element);
        }
        protected override bool OnGotFocus(Dictionary<object, DxHtmlElement> parts, DxHtmlRootElement root) {
            activeElement?.Focus(true);
            return (activeElement != null);
        }
        protected override bool OnLostFocus(Dictionary<object, DxHtmlElement> parts, DxHtmlRootElement root) {
            activeElement?.Focus(false);
            return (activeElement != null);
        }
        protected override bool ProcessDialogKey(Keys keyData) {
            if(keyData == Keys.Left || keyData == Keys.Right) {
                activeElement?.Focus(false);
                if(activeElement == firstButtonElement)
                    activeElement = secondButtonElement;
                else activeElement = firstButtonElement;
                activeElement?.Focus(true);
                UpdateViewInfoState();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        bool isKeyPressedCore;
        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);
            if(e.Handled)
                return;
            if(e.KeyData == Keys.Space) {
                isKeyPressedCore = true;
                UpdateViewInfoState();
            }
        }
        protected override void OnKeyUp(KeyEventArgs e) {
            base.OnKeyUp(e);
            if(e.Handled)
                return;
            if(e.KeyData == Keys.Space) {
                bool wasPressed = isKeyPressedCore;
                isKeyPressedCore = false;
                UpdateViewInfoState();
                if(wasPressed)
                    OnKeyClick();
            }
        }
        protected virtual void OnKeyClick() {
            if(activeElement != null)
                OnButtonItemClick(new DxHtmlElementEventArgs(activeElement));
        }
        protected override void OnGotFocus(EventArgs e) {
            activeElement = activeElement ?? firstButtonElement;
            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e) {
            base.OnLostFocus(e);
            activeElement?.Focus(false);
            isKeyPressedCore = false;
        }
        protected override void OnMouseUp(MouseEventArgs e) {
            var dxArgs = DXMouseEventArgs.GetMouseArgs(e);
            dxArgs.Handled = GetValidationCanceled();
            base.OnMouseUp(dxArgs);
        }
        protected override bool GetValidationCanceled() {
            if(!base.GetValidationCanceled())
                return false;
            return !IsUnvalidatedControlIsParent(this);
        }
        #endregion Parts
        #region Theme
        protected virtual string GetButtonContentTemplateId() {
            return "twin-button-item-template";
        }
        protected override string LoadDefaultTemplate() {
            return TwinButtonHtmlCssAsset.Default.Html;
        }
        protected override string LoadDefaultStyles() {
            return TwinButtonHtmlCssAsset.Default.Css;
        }
        sealed class TwinButtonHtmlCssAsset : HtmlCssAsset {
            static TwinButtonHtmlCssAsset() {
                TwinButtonItem.Register();
            }
            public static readonly HtmlCssAsset Default = new TwinButtonHtmlCssAsset();
        }
        #endregion Theme
        protected override ICustomDxHtmlPreview CreateHtmlEditorPreview() {
            var previewControl = new TwinButton();
            previewControl.FirstText = string.IsNullOrEmpty(FirstText) ? "{First}" : FirstText;
            previewControl.SecondText = string.IsNullOrEmpty(SecondText) ? "{Second}" : SecondText;
            previewControl.FirstIconImageOptions.Assign(FirstIconImageOptions);
            previewControl.SecondIconImageOptions.Assign(SecondIconImageOptions);
            return previewControl;
        }
    }
}
