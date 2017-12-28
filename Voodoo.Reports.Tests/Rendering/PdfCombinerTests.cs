using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voodoo.Reports.Tests.Rendering
{
    [TestClass]
    public class PdfCombinerTests : BaseTest          
    {
        [TestMethod]
        public void RenderReport_ValidData_IsOk()
        {
            var binder = new PdfCombiner();
            var data = base.GetData();
            var report1 = new BordersAndShadingReport();
            report1.Build(data);
            binder.AddPdf(report1.Render(ReportFormat.Pdf));

            var report2 = new RowSpanReport();
            report2.Build(data);
            binder.AddPdf(report2.Render(ReportFormat.Pdf));

            var path = IoNic.PathCombineLocal(OutputPath, $"{Name}.pdf");
            IoNic.MakeDir(OutputPath);
            File.WriteAllBytes(path, binder.GetOutput());
        }

        public override string Name => "CombinedPdf";
    }
}
