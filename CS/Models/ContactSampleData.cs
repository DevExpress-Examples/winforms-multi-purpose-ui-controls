namespace DevExpress.UITemplates.Collection.Models {
    using System;
    using System.Collections.Generic;

    public static class ContactSampleData {
        static ContactSampleData() {
            Contact1 = new Contact("John Smith");
            Contact1.SetActive();
            Contact1.SetUnreadCount(2);
            Contact2 = new Contact("Mary Brown");
            Contact2.SetLastOnline(DateTime.Now.AddHours(-4));
            Contacts = new Contact[] { 
                Contact1, Contact2 
            };
        }
        //
        public static Contact Contact1 {
            get;
            private set;
        }
        public static Contact Contact2 {
            get;
            private set;
        }
        public static IReadOnlyCollection<Contact> Contacts {
            get;
            private set;
        }
    }
}
