using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;
using Voodoo.Reports.RenderingLogic;
using Voodoo.Reports.RenderingLogic.BorderBuilders;
using Color = System.Drawing.Color;

namespace Voodoo.Reports.Tests.RenderingLogic
{

    public class BorderBuilderTest
    {
        protected Table table;
        protected List<CellPositionMap> map;
        protected OuterBorder outerBorder;
        protected InnerBorder innerBorder;
        protected CellPositionMap getCell(int column, int row) => map.Where(c => c.Position.Column == column && c.Position.Row == row).First();
        
        public BorderBuilderTest()
        {
            this.table = new Table();
            foreach (var r in Enumerable.Range(1, 3))
            {
                var row = table.AddRow();
                foreach (var C in Enumerable.Range(1, 3))
                {
                    row.AddCell();
                }
            }
            table.SetOuterBorders(Color.Red, BorderStyle.Solid, table.Children());
            table.SetInnerBorders(Color.Blue, BorderStyle.Solid, table.Children());
            table.HandlePrerendingTasks();
            var allCells = table.GetAllCells();
            map = new CellPositionMapper(table, allCells).CellPositionMaps;
            this.outerBorder = table.OuterBorders.First();
            this.innerBorder = table.InternalBorders.First();
        }
   
        [TestMethod]
        public void SetTopBorder_Outer_IsOk()
        {
            var top = map.Where(c => c.Position.Row == 0).ToArray();
            top.Count().Should().Be(3);
            var notTop = map.Where(c => c.Position.Row != 0).ToArray();
            notTop.Count().Should().Be(6);

            foreach (var cell in top)
            {
                var factory = new TopBorderBuilder(cell, map, outerBorder);
                factory.SetTopBorder();

                factory.IsTopRow().Should().Be(true);
                factory.ShouldApplyTopBorder().Should().Be(true);
            }
            foreach (var cell in notTop)
            {
                var factory = new TopBorderBuilder(cell, map, outerBorder);
                factory.SetTopBorder();

                factory.IsTopRow().Should().Be(false);
                factory.ShouldApplyTopBorder().Should().Be(false);

            }
        }
        [TestMethod]
        public void SetTopBorder_Inner_IsOk()
        {
            var top = map.Where(c => c.Position.Row == 0).ToArray();
            top.Count().Should().Be(3);
            var notTop = map.Where(c => c.Position.Row != 0).ToArray();
            notTop.Count().Should().Be(6);

            foreach (var cell in top)
            {
                var factory = new TopBorderBuilder(cell, map, innerBorder);
                factory.SetTopBorder();

                factory.IsTopRow().Should().Be(true);
                factory.ShouldApplyTopBorder().Should().Be(false);
            }
            foreach (var cell in notTop)
            {
                var factory = new TopBorderBuilder(cell, map, innerBorder);
                factory.SetTopBorder();

                factory.IsTopRow().Should().Be(false);
                factory.ShouldApplyTopBorder().Should().Be(true);

            }
        }


        [TestMethod]
        public void SetLeftBorder_Outer_IsOk()
        {
            var left = map.Where(c => c.Position.Column == 0).ToArray();
            left.Count().Should().Be(3);
            var notLeft = map.Where(c => c.Position.Column != 0).ToArray();
            notLeft.Count().Should().Be(6);

            foreach (var cell in left)
            {
                var factory = new LeftBorderBuilder(cell, map, outerBorder);
                factory.SetLeftBorder();

                factory.IsLeftMost().Should().Be(true);
                factory.ShouldApplyLeftBorder().Should().Be(true);
            }
            foreach (var cell in notLeft)
            {
                var factory = new LeftBorderBuilder(cell, map, outerBorder);
                factory.SetLeftBorder();

                factory.IsLeftMost().Should().Be(false);
                factory.ShouldApplyLeftBorder().Should().Be(false);

            }
        }
    }
}
