using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voodoo.Reports.Tests.Rendering
{
    [TestClass]
    public class ReportWithTooManyCellsTest : BaseTest
    {
        [TestMethod, ExpectedException(typeof(TooManyCellsException))]
        public void RenderReport_ValidData_IsOk()
        {
            var data = base.GetData();
            var report = new ReportWithTooManyCells();
            report.Build(data);
            base.WriteFile(report);
        }

        public override string Name => "ReportWithTooManyCellsTest";
    }
}