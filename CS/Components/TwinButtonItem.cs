namespace DevExpress.UITemplates.Collection.Components {
    using DevExpress.Utils;
    using DevExpress.Utils.Html;

    public sealed class TwinButtonItem : DxHtmlComponent {
        public static void Register() {
            DxHtmlDocument.Define<TwinButtonItem>("twin-button-item");
        }
        public static bool IsButtonElement(DxHtmlElementBase element, DxHtmlElementBase? buttonElement) {
            var parent = element.ParentElement;
            while(parent != null) {
                if(parent.TagName == "twin-button-item")
                    return buttonElement == parent;
                parent = parent.ParentElement;
            }
            return false;
        }
        //
        public enum Size {
            Small = -1,
            Default = 0,
            Large = 1,
        }
        public string Template {
            get { return GetAttribute(nameof(Template)) as string ?? string.Empty; }
        }
        public Size? ItemSize {
            get {
                object value = GetAttribute(nameof(ItemSize));
                if(value is int)
                    return new Size?((Size)(int)value);
                if(value is string) {
                    if(string.Equals((string)value, nameof(Size.Small), System.StringComparison.OrdinalIgnoreCase))
                        return Size.Small;
                    if(string.Equals((string)value, nameof(Size.Default), System.StringComparison.OrdinalIgnoreCase))
                        return Size.Default;
                    if(string.Equals((string)value, nameof(Size.Large), System.StringComparison.OrdinalIgnoreCase))
                        return Size.Large;
                }
                return value is Size ? new Size?((Size)value) : null;
            }
        }
        public override void AttributeChangedCallback(string attributeName) {
            base.AttributeChangedCallback(attributeName);
            if(string.Equals(attributeName, nameof(Template), System.StringComparison.OrdinalIgnoreCase)) {
                Reset();
                return;
            }
            if(string.Equals(attributeName, nameof(ItemSize), System.StringComparison.OrdinalIgnoreCase)) {
                EnsureItemSize(originalParentClassName);
                return;
            }
        }
        string? originalParentClassName;
        public override void ConnectedCallback() {
            base.ConnectedCallback();
            AddEventListener("mouseup", OnItemMouseUp);
            SetAttribute("self", this);
            EnsureTemplate();
            EnsureItemSize(originalParentClassName = Element.ParentElement.ClassName);
        }
        public override void DisconnectedCallback() {
            RemoveEventListener("mouseup", OnItemMouseUp);
            base.DisconnectedCallback();
        }
        public void Reset() {
            ClearChildren();
            EnsureTemplate();
            EnsureItemSize(originalParentClassName);
        }
        void EnsureTemplate() {
            string? templateId = GetAttribute(nameof(Template)) as string;
            if(!string.IsNullOrEmpty(templateId)) {
                var template = Element.RootElement.FindTemplate(templateId);
                if(template != null)
                    AppendChild(template.CloneNode(true));
            }
            if(string.IsNullOrEmpty(Element.ClassName))
                Element.ClassName = "twin-button-item";
        }
        void EnsureItemSize(string? parentClassName) {
           Element.ParentElement.ClassName = CalcClassName(parentClassName, ItemSize);
        }
        static string CalcClassName(string? className, Size? size) {
            return className + " " + size.GetValueOrDefault().ToString().ToLowerInvariant();
        }
        void OnItemMouseUp(DxHtmlElementEventArgs args) {
            var mouseArgs = args as DxHtmlElementMouseEventArgs;
            if(mouseArgs != null && mouseArgs.IsClick) {
                var meArgs = mouseArgs.MouseArgs as DXMouseEventArgs;
                if(meArgs != null && meArgs.Handled)
                    return;
                OnItemClick(args);
            }
        }
        void OnItemClick(DxHtmlElementEventArgs args) {
            DispatchEvent("item-click", args);
            args.CancelBubble = true;
            args.SuppressOwnerEvent = true;
        }
    }
}
