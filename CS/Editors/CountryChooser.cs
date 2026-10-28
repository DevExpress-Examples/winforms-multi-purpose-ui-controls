namespace DevExpress.UITemplates.Collection.Editors {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using DevExpress.Data;
    using UITemplatesExample.Assets.Toolbox; 
    using DevExpress.UITemplates.Collection.Images;
    using DevExpress.UITemplates.Collection.Utilities;
    using DevExpress.Utils;
    using DevExpress.Utils.Design;
    using DevExpress.Utils.Drawing;
    using DevExpress.Utils.Html;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Internal;
    using DevExpress.XtraEditors.Popup;
    using DevExpress.XtraEditors.Repository;

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ToolboxBitmapRoot), "CountryChooser.bmp")]
    [Description("A predesigned drop-down editor that allows users to quickly choose from over 200 countries.")]
    public class CountryChooser : HtmlLookUpBase {
        protected override RepositoryItem CreateRepositoryItemCore() {
            return new CountryChooserProperties();
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Country {
            get {
                if(EditValue is string stringValue)
                    return stringValue;

                return string.Empty;
            }
            set { EditValue = value; }
        }
        #region Properties
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new CountryChooserProperties Properties {
            get { return (CountryChooserProperties)BaseProperties; }
        }
        [System.ComponentModel.Category(CategoryName.ToolTip)]
        public bool ShowCountryToolTip {
            get { return Properties.ShowCountryToolTip; }
            set { Properties.ShowCountryToolTip = value; }
        }
        bool ShouldSerializeShowCountryToolTip() {
            return Properties.ShouldSerializeShowCountryToolTip();
        }
        void ResetShowCountryToolTip() {
            Properties.ResetShowCountryToolTip();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [System.ComponentModel.Category("Appearance")]
        public ContextImageOptions LeadingIconOptions {
            get { return Properties.ContextImageOptions; }
        }
        #endregion Properties
        public class CountryChooserProperties : HtmlLookUpBaseProperties, DevExpress.Utils.Text.IStringImageProvider {
            public CountryChooserProperties() {
                AutoSuggest += OnAutoSuggest;
                CustomDrawCell += OnCustomDrawCell;
            }
            protected override void Dispose(bool disposing) {
                AutoSuggest -= OnAutoSuggest;
                CustomDrawCell -= OnCustomDrawCell;
                base.Dispose(disposing);
            }
            bool? showFooterCore;
            [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public override bool ShowFooter {
                get { return showFooterCore.GetValueOrDefault(); }
                set { showFooterCore = value; }
            }
            void OnAutoSuggest(object sender, LookUpEditAutoSuggestEventArgs e) {
                var currentCountry = ((CountryChooser)sender).currentCountryInfo;
                e.QuerySuggestions = Task.Run(GetGetCountries(e.Text, currentCountry, e.CancellationToken));
                e.SetHighlightRange(GetGetRangeFromDisplayText(e.Text, currentCountry));
            }
            void OnCustomDrawCell(object sender, LookUpCustomDrawCellArgs e) {
                if(e.RowKey is string stringKey) {
                    var info = Countries.GetCountryByName((string)e.RowKey!);
                    if(info != null) {
                        e.DrawHtmlText(GetHtmlRepresentation(info));
                        e.Handled = true;
                    }
                }
            }
            internal static Func<ICollection> GetGetCountries(string text,
                Countries.Info? currentCountry, System.Threading.CancellationToken cancellationToken) {
                var entries = Countries.All;
                var contains = !IsCurrentCountry(text, currentCountry) ?
                    IgnoreCaseComparisonFunctions.GetContains(CultureInfo.CurrentCulture.CompareInfo, CompareOptions.IgnoreCase, text) :
                    new Func<string, bool>(_ => true);
                return new Func<ICollection>(() =>
                    entries.Select(x => x.Country).Where(x => {
                        cancellationToken.ThrowIfCancellationRequested();
                        return contains(x);
                    }).ToList());
            }
            internal static Func<string, DisplayTextHighlightRange?> GetGetRangeFromDisplayText(string text,
                Countries.Info? currentCountry) {
                if(IsCurrentCountry(text, currentCountry))
                    return _ => null;
                var indexOf = IgnoreCaseComparisonFunctions.GetIndexOf(CultureInfo.CurrentCulture.CompareInfo, CompareOptions.IgnoreCase, text);
                return (country) => {
                    int index = indexOf(country);
                    if(index == -1)
                        return null;
                    return new DisplayTextHighlightRange(index + 1, text.Length);
                };
            }
            static bool IsCurrentCountry(string text, Countries.Info? currentCountry) {
                return currentCountry != null && string.Equals(text, currentCountry.Country, StringComparison.OrdinalIgnoreCase);
            }
            internal static string GetHtmlRepresentation(Countries.Info info) {
                return $"<image={info.ISO2}><nbsp>{info.Country}<nbsp><color=@disabledtext>{info.ISO3}</color>";
            }
            public override BaseEdit CreateEditor() {
                return new CountryChooser();
            }
            protected override SearchMode GetDefaultSearchMode() {
                return SearchMode.AutoSuggest;
            }
            bool? showCountryToolTipCore;
            [System.ComponentModel.Category(CategoryName.ToolTip)]
            public bool ShowCountryToolTip {
                get { return showCountryToolTipCore.GetValueOrDefault(true); }
                set {
                    if(ShowCountryToolTip == value) return;
                    showCountryToolTipCore = value;
                    OnPropertiesChanged(new PropertyChangedEventArgs(nameof(ShowCountryToolTip)));
                }
            }
            protected internal bool ShouldSerializeShowCountryToolTip() {
                return showCountryToolTipCore.HasValue;
            }
            protected internal void ResetShowCountryToolTip() {
                showCountryToolTipCore = null;
            }
            #region Icons
            protected override ContextImageOptions CreateContextImageOptions() {
                return new CountrySelectorContextImageOptions(this);
            }
            Image DevExpress.Utils.Text.IStringImageProvider.GetImage(string id) {
                var scaleDpi = ((CountryChooser)OwnerEdit)?.ScaleDPI ?? DevExpress.Utils.DPI.ScaleHelper.NoScale;
                var imgSize = scaleDpi.ScaleSize(ContextImageOptions.SvgImageSize);
                return CountryFlags.GetISO2GlyphOrFlag(LookAndFeel, id, imgSize);
            }
            sealed class CountrySelectorContextImageOptions : ContextImageOptions {
                readonly CountryChooserProperties owner;
                public CountrySelectorContextImageOptions(CountryChooserProperties owner) {
                    this.owner = owner;
                    SvgImage = DataEntry.World;
                    SvgImageSize = new Size(16, 16);
                }
                protected override bool ShouldSerializeSvgImage() {
                    return base.ShouldSerializeSvgImage() && !ReferenceEquals(SvgImage, DataEntry.World);
                }
                protected override bool ShouldSerializeSvgImageSize() {
                    return base.ShouldSerializeSvgImageSize() && (SvgImageSize != new Size(16, 16));
                }
                Countries.Info? ChoosenCountry {
                    get { return ((CountryChooser)owner.OwnerEdit)?.currentCountryInfo; }
                }
                protected override Image GetImageFromSvg(Size userSvgImageSize, bool scaleSvgImageSize, ISvgPaletteProvider palette) {
                    palette = CheckSvgPalette(palette);
                    Size size = GetSvgImageSize(SvgImage, SvgImageSize, userSvgImageSize, scaleSvgImageSize, ForcedScaleFactor);
                    var choosenCountry = ChoosenCountry;
                    if(choosenCountry != null)
                        return CountryFlags.GetISO2GlyphOrFlag(owner.LookAndFeel, choosenCountry.ISO2, size, palette);
                    return SvgBitmap.Render(size, palette);
                }
            }
            #endregion Icons
            #region Parts
            protected override object GetPartImage(string partName, ObjectState state) {
                if(partName == "DropDownIcon")
                    return UIElements.DropDown;
                return base.GetPartImage(partName, state);
            }
            protected internal Rectangle GetLeadingIconBounds() {
                return GetPartBounds(leadingIcon);
            }
            protected override bool IsDropDownIconVisible() {
                return Countries.All.Count > 0;
            }
            #endregion
            #region Assets
            protected override string LoadDefaultStyles() {
                return CountryChooserHtmlCssAsset.Default.Css;
            }
            protected override string LoadDefaultTemplate() {
                return CountryChooserHtmlCssAsset.Default.Html;
            }
            sealed class CountryChooserHtmlCssAsset : HtmlCssAsset {
                public static readonly HtmlCssAsset Default = new CountryChooserHtmlCssAsset();
            }
            #endregion Style
        }
        protected override bool QueryLeadingIconTooltip() {
            return QueueToolTip();
        }
        bool QueueToolTip(Action? action = null) {
            if(action == null && Properties.ShowCountryToolTip && (currentCountryInfo != null))
                action = new Action(ShowCountryInformation);
            if(action != null && IsHandleCreated)
                BeginInvoke(action);
            return (action != null);
        }
        protected virtual void ShowCountryInformation() {
            var controller = GetToolTipController();
            if(controller == null)
                return;
            string information =
                $"Continent: {currentCountryInfo?.Continent}<br>" +
                $"Capital: {currentCountryInfo?.Capital}<br>" +
                $"Currency: {currentCountryInfo?.Currency}";
            var showArgs = new ToolTipControllerShowEventArgs(this, this, information, currentCountryInfo?.Country, WarningToolTipLocation, false, false, 0, ToolTipIconType.None, ToolTipIconSize.Small, null, -1, controller.Appearance, controller.AppearanceTitle);
            showArgs.ToolTipType = ToolTipType.SuperTip;
            showArgs.ObjectBounds = RectangleToScreen(Properties.GetLeadingIconBounds());
            ShowCountryInformation(controller, showArgs);
        }
        protected virtual void ShowCountryInformation(ToolTipController controller, ToolTipControllerShowEventArgs showArgs) {
            ShowLeadingIconTooltip(controller, showArgs);
        }
        protected override void ShowAutoSuggestPopup(LookUpEditAutoSuggestEventArgs args) {
            base.ShowAutoSuggestPopup(args);
            HideLeadingIconTooltip();
        }
        Countries.Info? currentCountryInfo;
        protected override void OnEditValueChanging(ChangingEventArgs e) {
            if(!e.Cancel) {
                if(e.NewValue is string country)
                    currentCountryInfo = Countries.GetCountryByName(country);
                else currentCountryInfo = null;
            }
            base.OnEditValueChanging(e);
        }
        protected override ICustomDxHtmlPreview CreateHtmlEditorPreview() {
            var previewControl = new CountryChooser();
            previewControl.Properties.BeginUpdate();
            previewControl.Properties.HeaderLabel = string.IsNullOrEmpty(HeaderLabel) ? "{HeaderLabel}" : HeaderLabel;
            previewControl.Properties.FooterLabel = string.IsNullOrEmpty(FooterLabel) ? "{FooterLabel}" : FooterLabel;
            previewControl.Properties.NullValuePrompt = string.IsNullOrEmpty(Placeholder) ? "{Placeholder}" : Placeholder;
            previewControl.Properties.EndUpdate();
            return previewControl;
        }
    }
}
