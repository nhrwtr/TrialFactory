using Flow.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using General.Util;

namespace Flow.Entity
{
    public class Entity : IEntity, IReadOnlyEntity
    {
        protected HashSet<IEntity> _parents = new HashSet<IEntity>();
        public HashSet<IEntity> Parents
        {
            get => _parents;
            private set => _parents = new HashSet<IEntity>(value);
        }

        protected HashSet<IEntity> _children = new HashSet<IEntity>();
        public HashSet<IEntity> Children
        {
            get => _children;
            private set => _children = new HashSet<IEntity>(value);
        }

        public string GlobalId { get; private set; }
        public virtual EntityCategory Category { get; set; }

        public Entity()
        {
            DefineGlobalId();
        }

        public virtual void Dispose()
        {
            GlobalId = string.Empty;
            // 自分の情報を消す
            foreach (var parent in Parents)
            {
                if (parent != null && parent.Children.Contains(this))
                {
                    parent.Children.Remove(this);
                }
            }
            Parents.Clear();
            Children.Clear();
        }

        protected void DefineGlobalId()
        {
            GlobalId = GuidFactory.Create();
        }

        public override int GetHashCode()
        {
            return GlobalId.GetHashCode();
        }

        public void AddParent(IEntity entity)
        {
            Parents.Add(entity);
            entity.Children.Add(this);
        }

        public void AddChild(IEntity entity)
        {
            Children.Add(entity);
        }

        public virtual bool Equals(IEntity other)
        {
            return GlobalId == other.GlobalId;
        }

        public override bool Equals(object obj)
        {
            return obj is IEntity ? Equals(obj as IEntity) : base.Equals(obj);
        }

        public static bool operator ==(Entity obj1, Entity obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Entity entity1, Entity entity2)
        {
            return !(entity1 == entity2);
        }
    }
}
