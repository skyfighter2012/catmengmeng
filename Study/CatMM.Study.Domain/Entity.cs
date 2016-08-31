using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Study.Domain
{
    /// <summary>
    /// Entity
    /// </summary>
    public abstract class Entity : Entity<Guid>
    {
    }

    /// <summary>
    /// Entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Entity<TKey>
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual TKey Id { get; protected set; }

        /// <summary>
        /// Version
        /// </summary>
        public virtual int Version { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TKey>);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Equals(Entity<TKey> other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();

                return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        /// <summary>
        /// Get unproxied type
        /// </summary>
        /// <returns></returns>
        public Type GetUnproxiedType()
        {
            return GetType();
        }

        /// <summary>
        /// Override get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (Equals(Id, default(TKey)))
            {
                return base.GetHashCode();
            }

            return Id.GetHashCode();
        }

        /// <summary>
        /// Is transient
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsTransient(Entity<TKey> obj)
        {
            return obj != null && Equals(obj.Id, default(TKey));
        }
    }
}
