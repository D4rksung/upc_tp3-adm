using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleLogErrorAttribute());
            //filters.Add(new AuthorizeAttribute());
            //filters.Add(new AntiForgeryAttribute());
        }
    }
}