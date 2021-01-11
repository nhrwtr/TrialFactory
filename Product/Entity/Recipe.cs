using Flow.Enum;
using General.Util;

namespace Flow.Entity
{
    public class Recipe : Entity
    {
        public int Seaquence { get; set; }
        public string Modified { get; set; }

        public override EntityCategory Category { get => EntityCategory.RECIPE; set { } }

        public Recipe()
        {
        }

        public void Init(Root root, Sector sector, Segment segment, int seaquence)
        {
            Seaquence = seaquence;
            Modified = "N";
            AddParent(root);
            AddParent(sector);
            AddParent(segment);
        }

        public static Recipe Create(Root root, Sector sector, Segment segment, int seaquence)
        {
            var obj = new Recipe();
            obj.Init(root, sector, segment, seaquence);
            return obj;
        }
    }
}