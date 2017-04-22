# voodoo-reports

A series of ~~tubes~~ adapters over a reporting abstraction to programatically generate reports.  Uses [MigraDoc](http://www.pdfsharp.net) for PDF generation.

# Roadmap
-Add an adapter for OpenXml to generate excel files
-Add an adapter for html

  - Tablular Reports 

   ![Tabular Report](https://raw.githubusercontent.com/MiniverCheevy/voodoo-reports/master/Samples/TabularReport.png "Tabular Report")

[TabularReport](https://raw.githubusercontent.com/MiniverCheevy/voodoo-reports/master/Samples//TabularReport.pdf)
```cs
private void addHeaderRow()  
        {
            var header = this.table.AddRow().Bold().Big();
            header.NoBorder(BorderPosition.Top);

            header.AddCell("Name");
            header.AddCell("Address").NotBold();
            header.AddCell(string.Empty); 
            header.AddCell(string.Empty);
        }

        private void addRow(RandomPerson person)
        { 
            var row = table.AddRow();
            
            row.AddCell($"{person.LastName},{person.FirstName}");
            row.AddCell(person.Address.Address1);
            row.AddCell($"{person.Address.City},{person.Address.State} {person.Address.ZipCode}");
            
            cramAsManyFeaturesAsPossibleIntoOneCell(row.AddCell());
        }
```
 - Row and Column Span 

   ![Row and Column Span](https://raw.githubusercontent.com/MiniverCheevy/voodoo-reports/master/Samples//RowAndColumnSpanReport.png "Tabular Report")

[Row and Column Span](https://raw.githubusercontent.com/MiniverCheevy/voodoo-reports/master/Samples//RowAndColumnSpanReport.pdf)

```cs
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
```

- Borders And Shading

   ![Borders And Shading](https://raw.githubusercontent.com/MiniverCheevy/voodoo-reports/master/Samples//BordersAndShadingReport.png "Tabular Report")

[Borders And Shading](https://raw.githubusercontent.com/MiniverCheevy/voodoo-reports/master/Samples//BordersAndShadingReport.pdf)

```cs
 public void Build(List<RandomPerson> data)
        {
            var table = getTable();
            Row row = null;
            Cell cell = null;

            foreach (var r in Enumerable.Range(1, 4))
            {
                row = table.AddRow();
                foreach (var c in Enumerable.Range(1, 4))
                {
                    cell = row.AddCell("X");
                }
            }
            var cells = getJaggedOutline(table);
            cells.ForEach(c => c.BackColor(Color.LightGray));
            table.SetInnerBorders(Color.Red, Models.BorderStyle.Solid, cells);            
            table.SetOuterBorders(Color.Blue, Models.BorderStyle.Solid, cells);

            table = getTable();
            row = table.AddRow(.25).Big().Big().Bold().Border(BorderPosition.Bottom);
            cell = row.AddCell("Title").ColSpan(4).Center();
            row = table.AddRow(.2).Big().Bold().BackColor(Color.LightGray);
            row.AddCell("Left").ColSpan(2).Right().ForeColor(Color.Blue);
            row.AddCell("Right").ColSpan(2).Left().ForeColor(Color.Red);
            row = table.AddRow().Center();
            row.AddCell("A").Row.AddCell("B").Row.AddCell("C").Row.AddCell("D");
        }

        private Cell[] getJaggedOutline(Table table)
        {
            var rows = table.Children().Select(c => c as Row).ToArray();
            var cells = new List<Cell>();
            cells.AddRange(rows[0].Children().Take(4).ToArray());
            cells.AddRange(rows[1].Children().Take(3).ToArray());
            cells.AddRange(rows[2].Children().Take(2).ToArray());
            cells.AddRange(rows[3].Children().Take(1).ToArray());
            return cells.ToArray();
        }
```

  

MIT

