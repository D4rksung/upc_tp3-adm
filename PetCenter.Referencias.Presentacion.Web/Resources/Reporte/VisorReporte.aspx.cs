//using PetCenter.Referencias.Presentacion.Web.Helpers;
//using PetCenter.Referencias.Presentacion.Web.Helpers.Sesion;
//using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Principal;
//using PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones;

namespace PetCenter.Referencias.Presentacion.Web.Resources.Reporte
{
    /// <summary>
    /// Visor de reportes
    /// </summary>
    public partial class VisorReporte : System.Web.UI.Page
    {
        #region PROPIEDADES

        /// <summary>
        /// Indica si hubo error
        /// </summary>
        public bool ConError { get; set; }

        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string MensajeError { get; set; }

        #endregion

        #region LOAD

        /// <summary>
        /// Load de page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //var reporte = string.Empty;
            //try
            //{

            //    if (!IsPostBack)
            //    {
            //        //variables de apoyo
            //        var key = string.Empty;
            //        var value = string.Empty;

            //        //Obtenemos parametros iniciales
            //        NameValueCollection coll = Request.QueryString;
            //        var param = (ReportParameter)null;
            //        var parametros = new List<ReportParameter>();
            //        foreach (var item in coll.AllKeys)
            //        {
            //            key = Server.HtmlEncode(item);
            //            value = Server.HtmlEncode(coll[item]);
            //            if (key == "reporte")
            //            {
            //                reporte = value;
            //                continue;
            //            }
            //            param = new ReportParameter();
            //            param.Name = key;
            //            param.Values.Add(value);
            //            parametros.Add(param);
            //        }

            //        Rpt_View.ShowPrintButton = true;
            //        //Indicamos al control la ruta del reporteador
            //        Rpt_View.ServerReport.ReportServerUrl = new Uri(ReporteSesion.UrlReportServer);

            //        //Indicamos la ruta del reporte
            //        Rpt_View.ServerReport.ReportPath = ReporteSesion.UrlReportPath + reporte;

            //        //Indicamos las credenciales
            //        Rpt_View.ServerReport.ReportServerCredentials = new CredencialesReporte(ReporteSesion.UserReport, ReporteSesion.PasswordUserReport);

            //        //Definimos parámetros adicionales
            //        param = new ReportParameter();
            //        param.Name = "pIdUsuario";
            //        param.Values.Add(AdministradorSesion.Usuario.IdUsuario.ToString());
            //        parametros.Add(param);

            //        //Agregamos el parametro de la ruta del Logo
            //        param = new ReportParameter();
            //        param.Name = "pRutaLogo";
            //        param.Values.Add(Logo());
            //        parametros.Add(param);

            //        //Ahora agregamos el parámetro en al reporte
            //        Rpt_View.ServerReport.SetParameters(parametros.ToArray());

            //    }
            //    ConError = false;
            //}
            //catch (Exception ex)
            //{
            //    ex.CapturarError("VisorReporte", reporte);
            //    ConError = true;
            //    MensajeError = ex.Message;
            //}
        }

        #endregion

        #region LOGO

        /// <summary>
        /// Obtiene el string del logo
        /// </summary>
        /// <returns></returns>
        public string Logo()
        {
            using (var fs = new FileStream(Server.MapPath(ConfigurationManager.AppSettings["RUTA_LOGO"].ToString()), FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                return Convert.ToBase64String(buffer);
            }
        }

        #endregion

    }

    #region CREDENCIALES

    [Serializable]
    internal class CredencialesReporte //: IReportServerCredentials
    {
        //#region PROPIEDADES

        ///// <summary>
        ///// _userName
        ///// </summary>
        //private string _userName;

        ///// <summary>
        ///// _password
        ///// </summary>
        //private string _password;

        //#endregion

        //#region CONSTRUCTOR

        ///// <summary>
        ///// CredencialesReporte
        ///// </summary>
        ///// <param name="userName">userName</param>
        ///// <param name="password">password</param>
        //public CredencialesReporte(string userName, string password)
        //{
        //    _userName = userName;
        //    _password = password;
        //}

        //#endregion

        //#region MÉTODOS IMPLEMENTADOS

        ///// <summary>
        ///// ImpersonationUser
        ///// </summary>
        //public WindowsIdentity ImpersonationUser
        //{
        //    get { return null; }
        //}

        ///// <summary>
        ///// NetworkCredentials
        ///// </summary>
        //public ICredentials NetworkCredentials
        //{
        //    get { return new NetworkCredential(_userName, _password); }
        //}

        ///// <summary>
        ///// GetFormsCredentials
        ///// </summary>
        ///// <param name="authCookie">authCookie</param>
        ///// <param name="userName">userName</param>
        ///// <param name="password">password</param>
        ///// <param name="authority">authority</param>
        ///// <returns></returns>
        //public bool GetFormsCredentials(out Cookie authCookie, out string userName, out string password, out string authority)
        //{
        //    authCookie = null;
        //    userName = null;
        //    password = null;
        //    authority = null;
        //    return false;
        //}

        //#endregion
    }

    #endregion

}