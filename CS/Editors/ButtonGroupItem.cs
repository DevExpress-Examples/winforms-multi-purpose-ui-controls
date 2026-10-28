namespace DevExpress.UITemplates.Collection.Editors {
    using System.ComponentModel;

    [TypeConverter(typeof(Converter))]
    public class ButtonGroupItem : ItemBase {
        public ButtonGroupItem()
            : base(null, string.Empty, null) { }
        public ButtonGroupItem(object? value, [Localizable(true)] string caption)
            : base(value, caption, null) { }
        public ButtonGroupItem(object? value, [Localizable(true)] string caption, object? tag)
            : base(value, caption, tag) { }
        protected override ItemBase Clone() {
            return new ButtonGroupItem(Value, Caption, Tag);
        }
        #region internals
        public class Collection : Collection<ButtonGroupItem> {
            protected override ButtonGroupItem CreateItem(object? value, string caption) {
                return new ButtonGroupItem(value, caption);
            }
        }
        public class Selection : Selection<ButtonGroupItem> { }
        public class Converter : Converter<ButtonGroupItem> { }
        #endregion internals
    }
}
