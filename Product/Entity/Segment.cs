using Flow.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using General.Util;

namespace Flow.Entity
{
    public class Segment : Entity
    {
        public string Modified { get; set; }
        public string Id { get; set; }

        public string Name { get; set; }

        public override EntityCategory Category { get => EntityCategory.SEGMENT; set { } }

        public Segment()
        {
        }

        public void Init(Root root, Sector sector, string segmentId)
        {
            Modified = "A";
            Id = segmentId;
            AddParent(root);
            AddParent(sector);
        }

        public static Segment Create(Root root, Sector sector, string segmentId)
        {
            var obj = new Segment();
            obj.Init(root, sector, segmentId);
            return obj;
        }
    }
}
