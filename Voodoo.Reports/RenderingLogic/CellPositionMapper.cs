using System.Collections.Generic;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.RenderingLogic
{
    internal class CellPositionMapper
    {
        private Table table;
        private Cell[] cells;

        public CellPositionMapper(Table table, Cell[] cells)
        {
            this.table = table;
            this.cells = cells;
            buildMap();
        }

        public List<CellPositionMap> CellPositionMaps { get; private set; } = new List<CellPositionMap>();

        private void buildMap()
        {
            foreach (var cell in cells)
            {
                var position = table.CellPositionCalculator.PositionDictionary[cell];
                var map = new CellPositionMap{ Cell = cell, Position = position };
                this.CellPositionMaps.Add(map);
            }
        }

    }
}