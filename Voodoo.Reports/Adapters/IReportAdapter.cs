using Voodoo.Reports.Models;

namespace Voodoo.Reports.Adapters
{
	public interface IReportAdapter
	{
        byte[] Render(Report report);

    }
}