using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;

namespace Voodoo.Reports.Adapters.ClosedXmls
{
	public class Pdf
	{
		public Pdf(bool addDefaultStyles = true)
		{
			Document = new Document();

			DefaultSection = Document.AddSection();
			Header = DefaultSection.Headers.Primary;
			Footer = DefaultSection.Footers.Primary;

			if (addDefaultStyles)
				AddDefaultStyles();
		}

		public HeaderFooter Header { get; set; }
		public HeaderFooter Footer { get; set; }
		public MigraDoc.DocumentObjectModel.Section DefaultSection { get; set; }
		public Document Document { get; set; }

		public void AddDefaultStyles()
		{
			DefaultSection.PageSetup.RightMargin = ".5in";
			DefaultSection.PageSetup.LeftMargin = ".5in";
			DefaultSection.PageSetup.TopMargin = "1.25in";
			DefaultSection.PageSetup.BottomMargin = ".5in";

			// Get the predefined style Normal.
			var style = Document.Styles["Normal"];
			// Because all styles are derived from Normal, the next line changes the 
			// font of the whole document. Or, more exactly, it changes the font of
			// all styles and paragraphs that do not redefine the font.
			style.Font.Name = "Verdana";
			style.Font.Size = 7;

			style = Document.Styles[StyleNames.Header];
			style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

			style = Document.Styles[StyleNames.Footer];
			style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

			// Create a new style called Table based on style Normal
			style = Document.Styles.AddStyle("Table", "Normal");
			style.Font.Name = "Verdana";
			style.Font.Size = 7;

			// Create a new style called Reference based on style Normal
			style = Document.Styles.AddStyle("Reference", "Normal");
			style.ParagraphFormat.SpaceBefore = "5mm";
			style.ParagraphFormat.SpaceAfter = "5mm";
			style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
		}

		public byte[] GetBytes()
		{
			var renderer = new DocumentRenderer(Document);
			var pdfRenderer = new PdfDocumentRenderer
			{
				DocumentRenderer = renderer,
				Document = Document
			};
			pdfRenderer.RenderDocument();
			using (var ms = new MemoryStream())
			{
				pdfRenderer.Save(ms, false);
				var buffer = new byte[ms.Length];
				ms.Seek(0, SeekOrigin.Begin);
				ms.Flush();
				ms.Read(buffer, 0, (int)ms.Length);
				return buffer;
			}
		}

		public Paragraph PutTextFrame(TextFrame frame, string left, string top, string width, string text = null)
		{
			frame.RelativeVertical = RelativeVertical.Page;
			frame.Left = left;
			frame.Top = top;
			frame.Width = width;
			var paragraph = text == null ? frame.AddParagraph() : frame.AddParagraph(text);
			return paragraph;
		}
	}
}