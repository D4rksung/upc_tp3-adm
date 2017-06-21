using PetCenter.Referencias.Presentacion.Web.Resources;
//using Framework.Log.LogApp;
using System;

namespace PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones
{
    /// <summary>
    /// Métodos de extensión de captura de error.
    /// </summary>
    public static class ErrorHandler
    {

        ///// <summary>
        ///// LogHelper
        ///// </summary>
        //private readonly static LogHelper LogHelper = new LogHelper();

        /// <summary>
        /// CapturarError
        /// </summary>
        /// <param name="error">error</param>
        /// <param name="controlador">controlador</param>
        /// <param name="accion">accion</param>
        public static void CapturarError(this Exception error, string controlador = "", string accion = "")
        {
            //var identificador = Guid.NewGuid().ToString();
            //var usuario = AdministradorSesion.Usuario.Login;
            //var comentario = string.Format(@"El Usuario [{0}] ejecutó la accion: [{1}/{2}]", usuario, controlador, accion);
            //LogHelper.AddError(Mensajes.MsjErroAppSga, identificador, error, comentario);
        }

    }
}