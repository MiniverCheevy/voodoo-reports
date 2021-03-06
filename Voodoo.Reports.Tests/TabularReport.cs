﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;
using Voodoo.TestData;
using Voodoo.TestData.Models;

namespace Voodoo.Reports.Tests
{
    public class TabularReport : Report
    {
        private Table table;

        public TabularReport()
        {
            this.MarginInInches.HeaderDistance = .4m;
            this.Body.Border(BorderPosition.Top, BorderPosition.Bottom);
            addHeader();
            AddDefaultFooter();
            //ShowRuler = true;
        }
        private void addHeader()
        {
            var header = Header.AddTable().Italics().ForeColor(System.Drawing.Color.Blue);
            header.NoBorder();
            header.AddColumn(1.5);
            header.AddColumn(4);
            header.AddColumn(1.5);

            var image = new Images.Images().Hat;
            var row = header.AddRow(.7);
            var left = row.AddCell().AddImage(image, .7);
            var middle = row.AddCell().Bold().Big().Big().Big()
                .Center().Middle().AddFragment("Title");
            var right = row.AddCell();
        }


        public void Build(List<RandomPerson> data)
        {
            table = this.Body.AddTable();
            table.AddColumn(1.8);
            table.AddColumn(1.8);
            table.AddColumn(1.8);
            table.AddColumn(1.8);
            addHeaderRow();
            data.ForEach(addRow);
        }

        private void addHeaderRow()
        {
            var header = this.table.AddRow().Bold().Big().Header();
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

        private static void cramAsManyFeaturesAsPossibleIntoOneCell(Cell cell)
        {
            cell.BackColor(Color.WhiteSmoke).Right().UseNonBreakingSpaces();
            var number = TestHelper.Data.Double(-10, 10);
            var foreColor = number >= 0 ? Color.Green : Color.Red;

            cell.AddFragment("Measure:").Bold();
            cell.AddFragment(number.ToString("N").PadLeft(18))
                .ForeColor(foreColor)
                .FontFamily("Courier New")
                .FontSize(8);
        }
    }
}