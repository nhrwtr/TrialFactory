using Flow.Entity;

namespace Product
{
    public class Cell
    {
        public int ViewIndex { get; set; }

        public string SectorName => Sector.Name;

        public string SegmentName => Segment.Name;

        public int FlowIndex => Flow.Index;

        public FlowEntity Flow { get; set; }
        public Sector Sector { get; set; }
        public Segment Segment { get; set; }
        public SegmentDetail SegmentDetail { get; set; }
    }
}
