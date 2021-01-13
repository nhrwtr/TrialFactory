using Flow.Enum;

namespace Flow.Entity
{
    public class Sector : Entity
    {
        public string Modified { get; set; }
        public string Id { get; set; }

        public string Name { get; set; }

        public override EntityCategory Category { get => EntityCategory.SECTOR; set { } }

        public Sector()
        {
        }

        public void Init(Root root, string sectorId)
        {
            Modified = "N";
            Id = sectorId;
            AddParent(root);
        }

        public static Sector Create(Root root, string sectorId)
        {
            var obj = new Sector();
            obj.Init(root, sectorId);
            return obj;
        }
    }
}
