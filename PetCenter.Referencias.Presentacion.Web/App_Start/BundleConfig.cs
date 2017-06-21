using System.Web;
using System.Web.Optimization;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Configuration;

namespace PetCenter.Referencias.Presentacion.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region SITIO WEB COLQUISIRI.Asistencia

            bundles.Add(new ScriptBundle("~/js/boostrap").Include(
                        // JS BOOTSTRAP
                        "~/Resources/Bootstrap/js/bootstrap.min.js",
                        "~/Resources/Bootstrap/js/bootstrap-timepicker.js",
                        "~/Resources/Bootstrap/js/bootstrap-datepicker.js",
                        "~/Resources/Bootstrap/js/bootstrap-datepicker.es.js",
                        "~/Resources/Bootstrap/js/bootstrap-datetimepicker.js",
                        "~/Resources/Bootstrap/js/bootstrap-datetimepicker.es.js",
                        "~/Resources/Bootstrap/js/bootpopup.js",
                        "~/Resources/Bootstrap/js/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                          //JS JQUERY
                          "~/Resources/Sitio/js/jquery-1.9.1.min.js",
                          "~/Resources/Sitio/js/jquery.validate.min.js",
                          "~/Resources/Sitio/js/jquery.cookie.js",
                          "~/Resources/Sitio/js/jquery.numeric.js"));

            bundles.Add(new ScriptBundle("~/js/sitio").Include(
                          //JS SITIO
                          "~/Resources/Sitio/js/sitio.js",
                          "~/Resources/Sitio/js/date-es-PE.js"));

            bundles.Add(new ScriptBundle("~/js/vistas").Include(
                          //JS VISTAS
                          "~/Resources/Sitio/js/views/helper.js",
                          "~/Resources/Sitio/js/views/helper.file.js",
                          "~/Resources/Sitio/js/views/helper.grid.js",
                          "~/Resources/Sitio/js/views/helper.extender.js",
                          "~/Resources/Sitio/js/views/view.solicitud.js"
                          ));

            bundles.Add(new StyleImagePathBundle("~/css/bootstrap").Include(
                       // CSS BOOTSTRAP
                       "~/Resources/Bootstrap/css/bootstrap.min.css",
                       "~/Resources/Bootstrap/css/bootstrap.colquisiri.css",
                       "~/Resources/Bootstrap/css/bootstrap-datetimepicker.css",
                       "~/Resources/Bootstrap/css/datepicker.css",
                       "~/Resources/Bootstrap/css/bootstrap-datepicker.css"));

            bundles.Add(new StyleImagePathBundle("~/css/sitio").Include(
                        //SITIO
                        "~/Resources/Sitio/css/sitio.css",
                        "~/Resources/Sitio/css/sitio.icon.css"));

            bundles.Add(new StyleImagePathBundle("~/css/vistas").Include(
                      //VISTAS
                      "~/Resources/Sitio/css/views/view.grid.css",
                      "~/Resources/Sitio/css/views/view.file.css"));

            bundles.IgnoreList.Clear();

            #endregion

            #region MINIFICACION

            var enabledMinificacion = Convert.ToBoolean(ConfigurationManager.AppSettings["HabilitaMinificacion"]);
            if (enabledMinificacion) BundleTable.EnableOptimizations = true;

            #endregion
        }
    }

    #region MINI CSS & JS

    /// <summary>
    /// Minificación correcta de CSS
    /// </summary>
    public class StyleImagePathBundle : Bundle
    {
        /// <summary>
        /// Habilita minificación
        /// </summary>
        private bool _enabledMinificacion = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="virtualPath">StyleImagePathBundle</param>
        public StyleImagePathBundle(string virtualPath)
            : base(virtualPath, new IBundleTransform[1]
                {
                        (IBundleTransform)new CssMinify()
                })
        { _enabledMinificacion = Convert.ToBoolean(ConfigurationManager.AppSettings["HabilitaMinificacion"]); }

        /// <summary>
        /// StyleImagePathBundle
        /// </summary>
        /// <param name="virtualPath">virtualPath</param>
        /// <param name="cdnPath">cdnPath</param>
        public StyleImagePathBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath, new IBundleTransform[1]
                {
                        (IBundleTransform)new CssMinify()
                })

        { _enabledMinificacion = Convert.ToBoolean(ConfigurationManager.AppSettings["HabilitaMinificacion"]); }

        /// <summary>
        /// Sobreescribiendo el método Include
        /// </summary>
        /// <param name="virtualPaths"></param>
        /// <returns></returns>
        public new Bundle Include(params string[] virtualPaths)
        {
            //if (HttpContext.Current.IsDebuggingEnabled)
            if (!_enabledMinificacion)
            {
                // Debugging. Bundling will not occur so act normal and no one gets hurt.
                base.Include(virtualPaths.ToArray());
                return this;
            }

            // In production mode so CSS will be bundled. Correct image paths.
            var bundlePaths = new List<string>();
            var svr = HttpContext.Current.Server;
            foreach (var path in virtualPaths)
            {
                var pattern = new Regex(@"url\s*\(\s*([""']?)([^:)]+)\1\s*\)", RegexOptions.IgnoreCase);
                var contents = System.IO.File.ReadAllText(svr.MapPath(path));
                if (!pattern.IsMatch(contents))
                {
                    bundlePaths.Add(path);
                    continue;
                }


                var bundlePath = (System.IO.Path.GetDirectoryName(path) ?? string.Empty).Replace(@"\", "/") + "/";
                var bundleUrlPath = VirtualPathUtility.ToAbsolute(bundlePath);
                var bundleFilePath = string.Format("{0}{1}.bundle{2}",
                                                   bundlePath,
                                                   System.IO.Path.GetFileNameWithoutExtension(path),
                                                   System.IO.Path.GetExtension(path));
                contents = pattern.Replace(contents, "url($1" + bundleUrlPath + "$2$1)");
                System.IO.File.WriteAllText(svr.MapPath(bundleFilePath), contents);
                bundlePaths.Add(bundleFilePath);
            }
            base.Include(bundlePaths.ToArray());
            return this;
        }
    }

    #endregion
}