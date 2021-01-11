using Flow.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using General.Util;

namespace Flow.Entity
{
    public interface IEntity : IEquatable<IEntity>, IDisposable
    {
        /// <summary>
        /// 親GlobalID
        /// </summary>
        HashSet<IEntity> Parents { get; }

        /// <summary>
        /// 親GlobalID
        /// </summary>
        HashSet<IEntity> Children { get; }

        /// <summary>
        /// グローバルID
        /// </summary>
        /// <remarks>1画面上で一意なID</remarks>
        string GlobalId { get; }

        /// <summary>
        /// エンティティの分類
        /// </summary>
        EntityCategory Category { get; set; }
    }
}
