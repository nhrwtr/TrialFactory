using System.Collections.Generic;
using System.ComponentModel;
using Flow.Entity;

namespace Product
{
    public class FlowManager
    {
        protected FlowData _flowData = null;
        private Root _root = null;

        public Root Root => _root;

        protected BindingList<Cell> _dataGridItems = null;

        public BindingList<Cell> DataGridItems => _dataGridItems;

#if DEBUG
        public IEnumerable<IEntity> Entities => _flowData.Entities;
#endif

        public FlowManager()
        {

        }

        public void Init(Root root)
        {
            _flowData = new FlowData();
            _dataGridItems = new BindingList<Cell>(_flowData.Flows);
            _root = root;
        }

        public int ViewIndexToFlowIndex(int viewIndex)
        {
            int index = 0;
            Cell srcCell = _flowData.FindFlow(viewIndex);
            if (srcCell != null)
            {
                index = srcCell.FlowIndex;
            }
            return index;
        }

        public void AddSectorUp(int viewIndex)
        {
            int index = ViewIndexToFlowIndex(viewIndex);

            string sectorId = "AAAA";
            Sector sector = Sector.Create(_root, sectorId);
            _flowData.AddEntity(sector);

            string segmentId = "AAAA";
            Segment segment = Segment.Create(_root, sector, segmentId);
            _flowData.AddEntity(segment);

            FlowEntity flow = FlowEntity.Create(_root, sector, segment, index);
            _flowData.AddEntity(flow);

            Cell cell = new Cell();
            cell.Flow = flow;
            cell.Sector = sector;
            cell.Segment = segment;
            cell.SegmentDetail = null;
            _flowData.InsertCell(index, cell);
        }

        public void AddSegmentUp(int viewIndex)
        {
            int index = ViewIndexToFlowIndex(viewIndex);

            Sector sector = _flowData.FindSector(index);

            string segmentId = "AAAA";
            Segment segment = Segment.Create(_root, sector, segmentId);
            _flowData.AddEntity(segment);

            FlowEntity flow = FlowEntity.Create(_root, sector, segment, index);
            _flowData.AddEntity(flow);

            Cell cell = new Cell();
            cell.Flow = flow;
            cell.Sector = sector;
            cell.Segment = segment;
            cell.SegmentDetail = null;
            _flowData.InsertCell(index, cell);
        }

    }
}
