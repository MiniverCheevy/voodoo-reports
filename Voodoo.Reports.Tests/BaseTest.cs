using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo.Reports.Adapters;
using MigraDocReportAdapter = Voodoo.Reports.Adapters.MigraDocs.ReportAdapter;
using ClosedXmlReportAdapter = Voodoo.Reports.Adapters.ClosedXml.ReportAdapter;
using Voodoo.Reports.Models;
using Voodoo.TestData;
using Voodoo.TestData.Models;

namespace Voodoo.Reports.Tests
{
    public abstract class BaseTest
    {
        private Dictionary<IReportAdapter, string> formats =
            new Dictionary<IReportAdapter, string>
            {
                {new MigraDocReportAdapter(), "pdf"},
                {new ClosedXmlReportAdapter(), "xlsx"}
            };

        public void WriteFile(Report report)
        {
            foreach (var format in formats.Keys)
            {
                var extension = formats[format];

                var bytes = report.Render(format);

                var path = IoNic.PathCombineLocal(OutputPath, $"{Name}.{extension}");
                IoNic.MakeDir(OutputPath);
                File.WriteAllBytes(path, bytes);

                Assert.IsTrue(File.Exists(path));
            }
        }

        public string OutputPath => @"C:\temp\reports";
        public abstract string Name { get; }

        public List<RandomPerson> GetData()
        {
            var data = new List<RandomPerson>();
            for (var i = 0; i < 100; i++)
            {
                data.Add(TestHelper.Data.Person());
            }
            return data;
        }
    }
}