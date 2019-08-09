using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voodoo.Reports.Tests
{
    public class LandscapeReport : TabularReport
    {
        public LandscapeReport()
        {
            base.Orientation = Reports.Models.Orientation.Landscape;
        }
    }
}
