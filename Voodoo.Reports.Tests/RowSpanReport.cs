using System.Collections.Generic;
using Voodoo.Reports.Models;
using Voodoo.TestData.Models;

namespace Voodoo.Reports.Tests
{
    public class RowSpanReport : Report
    {
        public Table Table { get; set; }

        public void Build(List<RandomPerson> data)
        {
            Table = this.Body.AddTable().Border(BorderPosition.All);
            Table.AddColumn(1.8);
            Table.AddColumn(1.8);
            Table.AddColumn(1.8);
            Table.AddColumn(1.8);
            addHeaderRow();
            data.ForEach(addRow);
        }

        private void addHeaderRow()
        {
            var header = this.Table.AddRow().Bold().Big();
            header.Border(BorderPosition.Top, BorderPosition.Bottom);

            header.AddCell("Name");
            header.AddCell("Address").NotBold();
            header.AddCell(string.Empty);
            header.AddCell(string.Empty);
        }

        private void addRow(RandomPerson person)
        {
            var row = Table.AddRow();
            row.AddCell($"{person.LastName},{person.FirstName}").RowSpan(3);
            row.AddCell(person.Address.Address1).ColSpan(2)
                .BackColor(System.Drawing.Color.AliceBlue);
            row = Table.AddRow();
            row.AddCell($"{person.Address.City},{person.Address.State} {person.Address.ZipCode}");
            row = Table.AddRow();
            row.AddCell($"USA, Earth");

        }

    }
}