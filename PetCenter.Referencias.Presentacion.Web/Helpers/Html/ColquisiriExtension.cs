using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace PetCenter.Referencias.Presentacion.Web.Helpers.Html
{
    /// <summary>
    /// Extensiones de MVC
    /// </summary>
    public static class ColquisiriExtension
    {
        /// <summary>
        /// Extensión de control File
        /// </summary>
        /// <param name="tam"></param>
        /// <param name="sufijo"></param>
        /// <param name="urlFoto"></param>
        /// <returns></returns>
        public static MvcHtmlString FileAmag(int tam = 8, string sufijo = "", string urlFoto = "", string tipo = "")
        {
            sufijo = sufijo.ToLower();
            string html = string.Concat(
                "<div id='main-file" + sufijo + "' name='main-file" + sufijo + "' class='col-sm-", tam, "' tam='", tam, "'>",
                "    <div class='input-group'>",
                "        <span class='input-group-btn'>",
                "            <span class='btn btn-primary btn-file btn-xs'>Examinar&hellip;",
                "                <input id='NameFile" + sufijo + "' type='file' class='asistencia-file-out' tipo='" + tipo + "'/>",// multiple>
                "            </span>",
                "        </span>",
                "        <input type='text' name='nombreArchivo" + sufijo + "' id='nombreArchivo" + sufijo + "' class='form-control asistencia-file-text input-sx-esp' readonly='' required='' placeholder='Nombre Archivo'/>",
                "    </div>",
                "    <div class='none-group'>",
                "       <input name='nombreArchivo" + sufijo + "' id='esp_nombreArchivo" + sufijo + "' type='file' class='asistencia-file-in' tipo='" + tipo + "'/>",// multiple>
                "    </div>",
                "    <div class='asistencia-file-det'>",
                "        <div class='progress'>",
                "            <div id='avance" + sufijo + "' class='progress-bar progress-bar-info' role='progressbar' aria-valuenow='0' aria-valuemin='0'>",
                "                <span id='perUp" + sufijo + "'>0%</span>",
                "            </div>",
                "        </div>",
                "    </div>",
                "</div>",
                "<div id='opt-file" + sufijo + "' name='opt-file" + sufijo + "' class='asistencia-point'>",
                "    <a class='asistencia-width-10 glyphicon glyphicon-circle-arrow-up' title='Ver archivo' onclick=\"helperFilejs.showFile('", sufijo, "')\"></a>",
                "    <a class='asistencia-width-10 glyphicon glyphicon-remove-circle' title='Remover archivo' onclick=\"helperFilejs.removeFile('", sufijo, "', '", urlFoto, "')\"></a>",
                "</div>"
                );

            return new MvcHtmlString(html);

        }

        /// <summary>
        /// Extensión de Form
        /// </summary>
        /// <param name="htmlHelper">htmlHelper</param>
        /// <param name="actionName">actionName</param>
        /// <param name="controllerName">controllerName</param>
        /// <param name="method">method</param>
        /// <param name="htmlAttributes">htmlAttributes</param>
        /// <returns>MvcForm</returns>
        public static MvcForm BeginSecureForm(this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, object htmlAttributes)
        {
            TagBuilder tagBuilder = new TagBuilder("form");

            Dictionary<string, object> htmlAttributesDictionary = new Dictionary<string, object>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes))
                htmlAttributesDictionary.Add(property.Name, property.GetValue(htmlAttributes));

            tagBuilder.MergeAttributes(htmlAttributesDictionary);
            tagBuilder.MergeAttribute("action", UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(), htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true));
            tagBuilder.MergeAttribute("method", HtmlHelper.GetFormMethodString(method), true);
            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
            htmlHelper.ViewContext.Writer.Write(htmlHelper.AntiForgeryToken().ToHtmlString());
            var theForm = new MvcForm(htmlHelper.ViewContext);

            return theForm;
        }

    }
}