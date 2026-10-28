namespace DevExpress.UITemplates.Collection.Components {
    using System.Drawing;
    using DevExpress.Utils.Html;

    public sealed class ProgressIndicator : ProgressIndicatorBase {
        public static void Register() {
            DxHtmlDocument.Define<ProgressIndicator>("progress-indicator");
        }
        //
        public string ProgressColor {
            get { return GetAttribute(nameof(ProgressColor)) as string ?? "@Green"; }
        }
        public string BackColor {
            get { return GetAttribute(nameof(BackColor)) as string ?? "@ControlText/0.3"; }
        }
        public override void AttributeChangedCallback(string attributeName) {
            base.AttributeChangedCallback(attributeName);
            if(attributeName == "value")
                UpdateIndicator(MaxValue - MinValue, Value - MinValue);
        }
        protected override void UpdateBackground(double range, double value, DxHtmlElement element) {
            if(value > 0) {
                element.Style.SetBackgroundColor(BackColor);
                element.Style.SetProperty("border-radius", "1px");
            }
            else element.Style.SetBackgroundColor(Color.Empty);
        }
        protected override void UpdateProgress(double range, double value, DxHtmlElement element) {
            if(value > 0) {
                element.Style.SetBackgroundColor(ProgressColor);
                double progress = System.Math.Round(100 * (value / range));
                element.Style.SetProperty("width", progress.ToString() + "%");
                element.Style.SetProperty("border-radius", "1px");
                element.Style.SetProperty("box-shadow", "0px 0px 4px " + ProgressColor + @"/0.4");
            }
            else element.Style.SetBackgroundColor(Color.Empty);
        }
    }
}
