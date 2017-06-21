using System.Configuration;
using System.Globalization;

namespace PetCenter.Referencias.Presentacion.Web.Helpers.Sesion
{
    public static class ReporteSesion
    {
        #region VARIABLES

        /// <summary>
        /// _urlReportServer
        /// </summary>
        private static string _urlReportServer = string.Empty;

        /// <summary>
        /// _urlReportPath
        /// </summary>
        private static string _urlReportPath = string.Empty;

        /// <summary>
        /// _userReport
        /// </summary>
        private static string _userReport = string.Empty;

        /// <summary>
        /// _passwordUserReport
        /// </summary>
        private static string _passwordUserReport = string.Empty;

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// UrlReportServer
        /// </summary>
        public static string UrlReportServer
        {
            get
            {
                if (_urlReportServer == string.Empty)
                    _urlReportServer = ConfigurationManager.AppSettings["KeyUrlReportServer"].ToString(CultureInfo.InvariantCulture);
                return _urlReportServer;
            }
        }

        /// <summary>
        /// UrlReportPath
        /// </summary>
        public static string UrlReportPath
        {
            get
            {
                if (_urlReportPath == string.Empty)
                    _urlReportPath = ConfigurationManager.AppSettings["KeyUrlReportPath"].ToString(CultureInfo.InvariantCulture);
                return _urlReportPath;
            }
        }

        /// <summary>
        /// UserReport
        /// </summary>
        public static string UserReport
        {
            get
            {
                if (_userReport == string.Empty)
                    _userReport = ConfigurationManager.AppSettings["KeyUserReport"].ToString(CultureInfo.InvariantCulture);
                return _userReport;
            }
        }

        /// <summary>
        /// PasswordReport
        /// </summary>
        public static string PasswordUserReport
        {
            get
            {
                if (_passwordUserReport == string.Empty)
                    _passwordUserReport = ConfigurationManager.AppSettings["KeyPasswordUserReport"].ToString(CultureInfo.InvariantCulture);
                return _passwordUserReport;
            }
        }

        #endregion
    }
}