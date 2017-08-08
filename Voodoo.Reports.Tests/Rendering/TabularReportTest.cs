using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voodoo.Reports.Tests.Rendering
{
    [TestClass]
    public class TabularReportTest : BaseTest
    {
        [TestMethod]
        public void RenderReport_ValidData_IsOk()
        {
            var data = base.GetData();
            var report = new TabularReport();
            report.Build(data);
            report.Body.AddVerticalSpacer(.5);
            report.Build(data);
            base.WriteFile(report);
        }

        public override string Name => "SimpleTabularReport";
    }
}