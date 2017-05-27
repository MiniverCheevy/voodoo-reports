using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo.Reports.Models;
using Voodoo.TestData;
using Voodoo.TestData.Models;

namespace Voodoo.Reports.Tests
{
    public abstract class BaseTest
    {

        private Dictionary<ReportFormat, string> formats = new Dictionary<ReportFormat, string> { { ReportFormat.Pdf, "pdf" } };
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
