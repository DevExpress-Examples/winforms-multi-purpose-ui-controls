using System;
using System.Collections.Generic;

namespace DevExpress.UITemplates.Collection.Messages {

    public class ReloadRequired<TKey, TEntity> : IEquatable<ReloadRequired<TKey, TEntity>>
        where TEntity : class
        where TKey : struct {
        readonly TKey id;
        readonly bool isNew;
        ReloadRequired(TKey id, bool isNew) {
            this.id = id;
            this.isNew = isNew;
        }
        public TKey Id {
            get { return id; }
        }
        public bool IsNew {
            get { return isNew; }
        }
        public bool Equals(ReloadRequired<TKey, TEntity> other) {
            return EqualityComparer<TKey>.Default.Equals(other.id, id) && (other.isNew == isNew);
        }
        public static ReloadRequired<TKey, TEntity> FromID(TKey id) {
            return new ReloadRequired<TKey, TEntity>(id, false);
        }
        public static ReloadRequired<TKey, TEntity> FromNew(TKey id) {
            return new ReloadRequired<TKey, TEntity>(id, true);
        }
        public static ReloadRequired<TKey, TEntity> All(TKey id) {
            return new ReloadRequired<TKey, TEntity>(id, false);
        }
    }
}
