using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.TestData;

namespace Voodoo.Reports.Tests.Rendering
{
    [TestClass]
    public class FormatStringTests : BaseTest
    {
        [TestMethod]
        public void RenderReport_ValidData_IsOk()
        {
            var data = GetFormatStringData();
            var report = new FormatStringsReport();
            report.Build(data);
            base.WriteFile(report);
        }

        private List<FormatStringTestClass> GetFormatStringData()
        {
            var result = new List<FormatStringTestClass>();
            for(var i = 0; i < 100; i ++)
            {
                var model = new FormatStringTestClass();
                TestHelper.Randomizer.Randomize(model);
                model.PercentValue = TestHelper.Data.Double(0, 1).To<decimal>();
                result.Add(model);
            }


            return result;

        }

        public override string Name => "FormatStringTests";
    }
}