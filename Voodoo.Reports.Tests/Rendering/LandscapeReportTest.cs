using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voodoo.Reports.Tests.Rendering
{

   [TestClass]
    public class LandscapeReportTest : BaseTest
    {
        [TestMethod]
        public void RenderReport_ValidData_IsOk()
        {
            var data = base.GetData();
            var report = new LandscapeReport();
            report.Build(data);
            report.Body.AddVerticalSpacer(.5);
            report.Build(data);
            base.WriteFile(report);
        }

        public override string Name => "SimpleLandscapeReport";
    }
}