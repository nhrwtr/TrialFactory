using Flow.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flow.Entity
{
    public interface IReadOnlyEntity
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
        EntityCategory Category { get; }
    }
}
