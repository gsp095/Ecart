using System.Web;
using System.Web.Mvc;

namespace MachineTestNimap_Amol
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
