using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voodoo.Reports.Tests.Rendering
{
    [TestClass]
    public class UnfilledCellsTest : BaseTest
    {
        [TestMethod]
        public void RenderReport_ValidData_IsOk()
        {
            var data = base.GetData();
            var report = new UnfilledCellsReport();
            report.Build(data);
            base.WriteFile(report);
        }

        public override string Name => "UnfilledCellsReport";
    }
}