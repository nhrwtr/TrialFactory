using Flow.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using General.Util;
using System.Linq;

namespace Flow.Entity
{
    public class FlowEntity : Entity
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public decimal? SerialNo { get; set; }
        public string Modified { get; set; }

        public override EntityCategory Category { get => EntityCategory.FLOW; set { } }

        public FlowEntity()
        {
            Modified = "A";
            Id = string.Empty;
            Index = -1;
        }

        public void Init(Root root, Sector sector, Segment segment)
        {
            Index = -1;
            SerialNo = default;
            Id = root.FlowId;
            AddParent(root);
            AddChild(sector);
            AddChild(segment);
        }

        public static FlowEntity Create(Root root, Sector sector, Segment segment, int index)
        {
            var obj = new FlowEntity();
            obj.Init(root, sector, segment);
            obj.Index = index;
            return obj;
        }
    }
}
