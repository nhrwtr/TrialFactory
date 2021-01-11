using Flow.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using General.Util;

namespace Flow.Entity
{
    public class SegmentDetail : Entity
    {
        public string Modified { get; set; }

        public override EntityCategory Category { get => EntityCategory.SEGMENT_DETAIL; set { } }

        public SegmentDetail()
        {
        }

        public void Init(Root root, Sector sector, Segment segment)
        {
            Modified = "N";
            AddParent(root);
            AddParent(sector);
            AddParent(segment);
        }

        public static SegmentDetail Create(Root root, Sector sector, Segment segment)
        {
            var obj = new SegmentDetail();
            obj.Init(root, sector, segment);
            return obj;
        }
    }
}
