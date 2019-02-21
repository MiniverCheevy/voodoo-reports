using System;
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
    public class ReportWithTooManyCells : Report
    {
        private Table table;

        public ReportWithTooManyCells()
        {
            this.Body.Border(BorderPosition.Top, BorderPosition.Bottom);
       
            AddDefaultFooter();
            //ShowRuler = true;
        }
        public void Build(List<RandomPerson> data)
        {
            table = this.Body.AddTable();
            table.AddColumn(1.8);
            table.AddColumn(1.8);        
            data.ForEach(addRow);
        }
        
        private void addRow(RandomPerson person)
        {
            var row = table.AddRow();

            row.AddCell($"{person.LastName},{person.FirstName}");
            row.AddCell(person.Address.Address1);
            row.AddCell($"{person.Address.City},{person.Address.State} {person.Address.ZipCode}");
        }
    }
}