using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel.Tables;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.Models
{
	public class Section: Part
	{        
        public Table[] Children()
        {
            return tables.ToArray();
        }
		private List<Table> tables = new List<Table>();
		public Table AddTable()
		{
			var table = new Table() { Parent = this };
			tables.Add(table);
			return table;
		}        
	}
}
