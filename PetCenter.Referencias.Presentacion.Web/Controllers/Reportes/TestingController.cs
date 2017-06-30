using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Reportes
{
    public class TestingController : Controller
    {

        public ActionResult Index2()
        {
            return View("_Index2");
        }

        public ActionResult Index3()
        {
            return View("_Index3");
        }


        public ActionResult GetData()
        {
            var data = new[] { new Entry() { value = 20, year = 2008 }, new Entry() { value = 10, year = 2009 } };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public class Entry
        {
            public int year { get; set; }
            public int value { get; set; }
        }
    }
}