using Voodoo.Reports.Models;

namespace Voodoo.Reports.Adapters.ClosedXmls
{
	public class MigraDocReportAdapter
	{
        public void Render(Report report)
        {
            this.Report = report;
            buildHeader();
            buildBody();
            buildFooter();
        }

	    private void buildHeader()
	    {

        }

	    private void buildBody()
	    {
	        
	    }

	    private void buildFooter()
	    {
	        
	    }

	    public Report Report { get; set; }
	}
}
