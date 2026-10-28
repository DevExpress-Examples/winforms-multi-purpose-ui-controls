namespace DevExpress.UITemplates.Collection.Models {
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Contact {
        public Contact(string userName) {
            this.UserName = userName;
        }
        public object Avatar {
            get;
            set;
        }
        public string UserName {
            get;
            private set;
        }
        public DateTime LastActivity {
            get;
            private set;
        }
        [Display(AutoGenerateField = false)]
        public DateTime LastOnline {
            get;
            private set;
        }
        public string LastOnlineText {
            get {
                if(IsActive)
                    return "Online";
                if(LastOnline == DateTime.MinValue)
                    return string.Empty;
                var diff = DateTime.Now.Subtract(LastOnline);
                if(diff.TotalMinutes < 1)
                    return "Just now";
                if(diff.TotalMinutes < 60)
                    return ((int)(0.5 + diff.TotalMinutes)).ToString() + " minutes ago";
                if(diff.TotalMinutes < 90)
                    return "1 hour ago";
                if(diff.TotalMinutes < 360)
                    return ((int)(diff.TotalMinutes / 60 + 0.5)).ToString() + " hours ago";
                if(diff.TotalMinutes < 1440)
                    return LastOnline.ToShortTimeString();
                if(diff.TotalMinutes < 2880)
                    return "Yesterday, " + LastOnline.ToShortTimeString();
                return LastOnline.ToShortDateString();
            }
        }
        [Display(AutoGenerateField = false)]
        public bool IsActive {
            get;
            private set;
        }
        public int UnreadCount {
            get;
            internal set;
        }
        [Display(AutoGenerateField = false)]
        public bool HasUnreadMessages {
            get { return UnreadCount > 0; }
        }
        // API
        public void SetActive(bool value = true) {
            IsActive = value;
        }
        public void SetLastOnline(DateTime dateTime) {
            LastOnline = dateTime;
        }
        public void SetUnreadCount(int value) {
            UnreadCount = value;
        }
        public override string ToString() {
            return IsActive ? UserName : $"{UserName}, {LastOnlineText}";
        }
    }
}
