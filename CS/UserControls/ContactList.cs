namespace DevExpress.UITemplates.Collection.UserControls {
    using System.Collections.Generic;
    using DevExpress.Data;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.UITemplates.Collection.Utilities;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Tile;

    public partial class ContactList : XtraUserControl {
        public ContactList() {
            InitializeComponent();
            if(!mvvmContext.IsDesignMode) {
                InitializeStyles();
                InitializeBinding();
                InitializeBehavior();
            }
        }
        void InitializeStyles() {
            Assets.SearchPanel.Apply(searchPanel);
            searchPanel.HtmlImages = Images.UIElements.SvgImages;
            contactsTileView.HtmlImages = Images.UIElements.SvgImages;
        }
        void InitializeBinding() {
            var fluent = mvvmContext.OfType<ViewModel>();
            // Bind the contacts
            fluent.SetBinding(gridControl, gc => gc.DataSource, x => x.Contacts);
            fluent.WithEvent<TileView, FocusedRowObjectChangedEventArgs>(contactsTileView, nameof(ColumnView.FocusedRowObjectChanged))
                .SetBinding(x => x.SelectedContact,
                    (args) => args.Row as Contact,
                    (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            // We need update our contacts list when the ViewModel detect changes
            fluent.SetTrigger(x => x.Contacts, contacts => contactsTileView.RefreshData());
            // Bind life-cycle events
            fluent.WithEvent(this, nameof(HandleCreated)).EventToCommand(x => x.OnCreate);
            fluent.WithEvent(this, nameof(HandleDestroyed)).EventToCommand(x => x.OnDestroy);
        }
        void InitializeBehavior() {
            // Setup default sorting for contacts
            var colLastActivity = contactsTileView.Columns["LastActivity"];
            if(colLastActivity != null)
                contactsTileView.SortInfo.Add(colLastActivity, ColumnSortOrder.Descending);
            // Setup search by user name only
            searchControl.QueryIsSearchColumn += OnQueryIsSearchColumn;
        }
        void OnQueryIsSearchColumn(object sender, QueryIsSearchColumnEventArgs e) {
            e.IsSearchColumn = (e.FieldName == "UserName");
        }
        void OnContactItemTemplate(object sender, TileViewCustomItemTemplateEventArgs e) {
            Assets.Contact.Apply(e.HtmlTemplate);
        }
        void OnContactItemTemplateCustomize(object sender, TileViewItemCustomizeEventArgs e) {
            var contact = contactsTileView.GetRow(e.RowHandle) as Contact;
            if(contact != null) {
                var statusBadge = e.HtmlElement.FindElementById("statusBadge");
                if(statusBadge != null && contact.IsActive)
                    statusBadge.Style.SetBackgroundColor("@Green");
                if(!contact.HasUnreadMessages) {
                    var unreadBadge = e.HtmlElement.FindElementById("unreadBadge");
                    if(unreadBadge != null)
                        unreadBadge.Hidden = true;
                }
            }
        }
        public class ViewModel {
            public virtual List<Contact> Contacts {
                get;
                protected set;
            }
            public virtual Contact SelectedContact {
                get;
                set;
            }
            public void OnCreate() {
                // do loading contact DTOs from data-layer
                ContactSampleData.Contact1.Avatar = Images.Users.CreateAvatar(01, Images.Users.SampleUser1);
                ContactSampleData.Contact2.Avatar = Images.Users.CreateAvatar(02, Images.Users.SampleUser2);
                Contacts = new List<Contact>(ContactSampleData.Contacts);
            }
            public void OnDestroy() {
                /* do some cleanup if required */
            }
        }
        #region Theme
        public class Assets {
            public static HtmlCssAsset Contact = new ContactHtmlCssAsset();
            public static HtmlCssAsset SearchPanel = new ContactSearchPanelHtmlCssAsset();
            //
            sealed class ContactHtmlCssAsset : HtmlCssAsset { }
            sealed class ContactSearchPanelHtmlCssAsset : HtmlCssAsset { }
        }
        #endregion Theme
    }
}
