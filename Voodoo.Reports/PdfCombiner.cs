using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Voodoo.Reports
{
    public class PdfCombiner
    {
        private PdfDocument output = new PdfDocument();

        public void AddPdf(Stream stream)
        {
            add(stream);
        }
        public void AddPdf(Byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                add(stream);
            }
        }

        private void add(Stream stream)
        {
            var inputDocument = PdfReader.Open(stream, PdfDocumentOpenMode.Import);

            // Iterate pages
            var count = inputDocument.PageCount;
            for (var idx = 0; idx < count; idx++)
            {
                // Get the page from the external document...
                PdfPage page = inputDocument.Pages[idx];
                // ...and add it to the output document.
                output.AddPage(page);
            }
        }

        public byte[] GetOutput()
        {
            
            using (var stream = new MemoryStream())
            {
                output.Save(stream);
                return stream.ToArray();
            }
        }

    }
}
