using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetCenter.Referencias.Presentacion.Web.Helpers.Mvc
{
    public static class Exportar<T>
    {
        public static void ExportarExcel(HttpResponseBase response, IEnumerable<T> lista, string nombre)
        {            
            GridView gv = new GridView();
            gv.DataSource = lista;
            gv.DataBind();

            response.ClearContent();
            response.Buffer = true;
            string header = string.Format("attachment; filename={0}.xls", nombre);            
            response.AddHeader("content-disposition",header);
            response.ContentType = "application/ms-excel";
            response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            response.Output.Write(sw.ToString());
            response.Flush();
            response.End();
        }
    }
}