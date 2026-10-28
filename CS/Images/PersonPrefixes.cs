namespace DevExpress.UITemplates.Collection.Images {
    using System;
    using DevExpress.Utils;
    using DevExpress.Utils.Svg;

    public static class PersonPrefixes {
        const string assetsRoot = "UITemplatesExample.Assets."; 
        [ThreadStatic]
        static SvgImageCollection svgImagesCore;
        public static SvgImageCollection SvgImages {
            get { return svgImagesCore ?? (svgImagesCore = SvgImageCollection.FromResources(assetsRoot + "SVG.PersonPrefixes", typeof(PersonPrefixes).Assembly)); }
        }
        public static SvgImage Mr {
            get { return SvgImages[nameof(Mr)]; }
        }
        public static SvgImage Mrs {
            get { return SvgImages[nameof(Mrs)]; }
        }
        public static SvgImage Ms {
            get { return SvgImages[nameof(Ms)]; }
        }
        public static SvgImage Miss {
            get { return SvgImages[nameof(Miss)]; }
        }
        public static SvgImage Doctor {
            get { return SvgImages[nameof(Doctor)]; }
        }
    }
}
