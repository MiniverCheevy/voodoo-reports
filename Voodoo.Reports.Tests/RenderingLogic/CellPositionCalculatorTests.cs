using System.Diagnostics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo.Reports.RenderingLogic;

namespace Voodoo.Reports.Tests.RenderingLogic
{
    [TestClass]
    public class CellPositionCalculatorTests : BaseTest
    {
        [TestMethod]
        public void GetOffset_Row1Cell1_Returns0()
        {
            var data = base.GetData();
            var report = new RowSpanReport();
            report.Build(data);
            var row = report.Table.Children()[1];
            var cell = row.Children()[0];

            var calculator = new CellPositionCalculator(report.Table);
            Debug.WriteLine(calculator.ToString());
            var position = calculator.PositionDictionary[cell].Column;
            position.Should().Be(0);
        }

        [TestMethod]
        public void GetOffset_Row2Cell2_Returns1()
        {
            var data = base.GetData();
            var report = new RowSpanReport();
            report.Build(data);
            var row = report.Table.Children()[2];
            var cell = row.Children()[0];

            var calculator = new CellPositionCalculator(report.Table);
            var position = calculator.PositionDictionary[cell].Column;
            Debug.WriteLine(calculator.ToString());
            position.Should().Be(1);
        }

        [TestMethod]
        public void GetOffset_Row2Cell3_Returns3()
        {
            var data = base.GetData();
            var report = new RowSpanReport();
            report.Build(data);
            var row = report.Table.Children()[2];
            var cell = row.Children()[2];

            var calculator = new CellPositionCalculator(report.Table);
            var position = calculator.PositionDictionary[cell].Column;
            Debug.WriteLine(calculator.ToString());
            position.Should().Be(3);
        }

        [TestMethod]
        public void GetOffset_Row2Cell1_Returns1()
        {
            var data = base.GetData();
            var report = new RowSpanReport();
            report.Build(data);
            var row = report.Table.Children()[2];
            var cell = row.Children()[0];

            var calculator = new CellPositionCalculator(report.Table);
            var position = calculator.PositionDictionary[cell].Column;
            Debug.WriteLine(calculator.ToString());
            position.Should().Be(1);
        }

        [TestMethod]
        public void GetOffset_Row4Cell0_Returns0()
        {
            var data = base.GetData();
            var report = new RowSpanReport();
            report.Build(data);
            var row = report.Table.Children()[3];
            var cell = row.Children()[0];

            var calculator = new CellPositionCalculator(report.Table);
            var position = calculator.PositionDictionary[cell].Column;
            Debug.WriteLine(calculator.ToString());
            position.Should().Be(1);
        }

        public override string Name => nameof(CellPositionCalculatorTests);
    }
}