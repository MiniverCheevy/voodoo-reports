using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voodoo.Reports
{
    public class TooManyCellsException:Exception
    {
        public TooManyCellsException()
        {

        }
        public TooManyCellsException(string message):base(message)
        {

        }
    }
}
