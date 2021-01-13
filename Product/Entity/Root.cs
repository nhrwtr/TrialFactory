namespace Flow.Entity
{
    public class Root : Entity
    {
        public string RootId { get; set; }

        public string FlowId { get; set; }

        public string Name { get; set; }

        public Root()
        {
            RootId = string.Empty;
        }

        public void Init(string rootId)
        {
            RootId = rootId;
        }

        public static Root Create(string rootId)
        {
            var obj = new Root();
            obj.Init(rootId);
            return obj;
        }
    }
}
