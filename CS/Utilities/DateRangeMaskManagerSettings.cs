namespace DevExpress.UITemplates.Collection.Utilities {
    using DevExpress.XtraEditors.Mask;
    using System;

    public abstract partial class CustomMaskSettings : MaskSettings.User {
        public class CalendarRange : MaskSettingsWithCulture {
            protected override Type GetMaskManagerType() {
                return typeof(DateRangeMaskManager);
            }
        }
    }
}
