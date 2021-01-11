using Flow.Entity;
using Product;
using System;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Root root = Root.Create("XXXXXXX");
            FlowManager manager = new FlowManager();
            manager.Init(root);

            manager.AddSectorUp(0);
            manager.AddSegmentUp(0);

            foreach (Cell cell in manager.DataGridItems)
            {
                string disp = $"{cell.ViewIndex}[{cell.FlowIndex}]: Flow= {cell.Flow.GlobalId}, Sector= {cell.Sector.GlobalId}, Segment= {cell.Segment.GlobalId}";
                Console.WriteLine(disp);
            }

            foreach (IEntity entity in manager.Entities)
            {
                string data = $"{entity.GetType()}: {entity.GlobalId}";
                Console.WriteLine(data);
            }
        }
    }
}
