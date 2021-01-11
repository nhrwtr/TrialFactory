using Flow.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Product
{
    public class FlowData
    {
        protected HashSet<IEntity> _entities = new HashSet<IEntity>();
#if DEBUG
        internal IEnumerable<IEntity> Entities => _entities;
#endif

        protected List<Cell> _flows = new List<Cell>();

        public IList<Cell> Flows => _flows;

        public FlowData()
        {
        }

        public void AddEntity(IEntity entity)
        {
            _entities.Add(entity);
        }

        public void InsertCell(int index, Cell cell)
        {
            _flows.Insert(index, cell);
            ReindexingCell(index + 1);
        }

        public void ReindexingCell(int index)
        {
            foreach (var flow in _entities.OfType<FlowEntity>().Where(fl => fl.Index >= index).OrderBy(fl => fl.Index))
            {
                flow.Index = index++;
            }

            for (int i = 0; i < _flows.Count; i++)
            {
                _flows[i].ViewIndex = i;
            }
        }

        public Cell FindFlow(int viewIndex)
        {
            if (_flows.Count == 0)
            {
                return null;
            }

            Cell cell = _flows[viewIndex];
            return cell;
        }

        public Sector FindSector(int index)
        {
            Cell cell = _flows.Where(c => c.FlowIndex == index).First();
            return cell.Sector;
        }

        public Segment FindSegment(int index)
        {
            Cell cell = _flows.Where(c => c.FlowIndex == index).First();
            return cell.Segment;
        }

        public IEnumerable<Segment> FindSegments(Sector sector)
        {
            IEnumerable<Segment> segments = sector.Children.OfType<Segment>();
            return segments;
        }

        public IEnumerable<T> FindStep<T>(Segment segment)
        {
            IEnumerable<T> entities = segment.Children.OfType<T>();
            return entities;
        }

        public void DeleteEntities()
        {
            foreach (IEntity entity in _entities)
            {
                entity.Dispose();
            }
            _entities.Clear();
            _flows.Clear();
        }

        public void DeleteEntities(Sector sector)
        {
            foreach (IEntity entity in sector.Children)
            {
                entity.Dispose();
            }
            sector.Dispose();

            _flows.RemoveAll(cell => cell.Sector == sector);
        }

        public void DeleteEntities(Segment segment)
        {
            foreach (IEntity entity in segment.Children)
            {
                entity.Dispose();
            }
            segment.Dispose();

            _flows.RemoveAll(cell => cell.Segment == segment);
        }
    }
}
