using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Resources.Enumeraciones;

namespace PetCenter.Referencias.Presentacion.Web.Models.Comun
{
    /// <summary>
    /// MensajeModelo
    /// </summary>
    public class MensajeModelo : IMensajeModelo
    {

        #region PROPIEDADES

        /// <summary>
        /// ExisteMensaje
        /// </summary>
        public bool ExisteMensaje { get; set; }

        /// <summary>
        /// Info
        /// </summary>
        public string Informativo { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Peligro
        /// </summary>
        public string Peligro { get; set; }

        /// <summary>
        /// Advertencia
        /// </summary>
        public string Advertencia { get; set; }

        /// <summary>
        /// Satisfactorio
        /// </summary>
        public string Satisfactorio { get; set; }

        /// <summary>
        /// Alerta
        /// </summary>
        public string Alerta { get; set; }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// AsignarMensaje
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        public void AsignarMensaje(string mensaje)
        {
            if (string.IsNullOrEmpty(mensaje)) return;
            var mensajeMvc = MensajeMvc.ObtenerMensaje(mensaje);

            if (mensajeMvc.Tipo != TipoNotificacionEnum.Ninguno.ToString())
            {
                ExisteMensaje = true;
                if (mensajeMvc.Tipo == TipoNotificacionEnum.Advertencia.ToString())
                    Advertencia = mensajeMvc.Mensaje;
                else if (mensajeMvc.Tipo == TipoNotificacionEnum.Alerta.ToString())
                    Alerta = mensajeMvc.Mensaje;
                else if (mensajeMvc.Tipo == TipoNotificacionEnum.Error.ToString())
                    Error = mensajeMvc.Mensaje;
                else if (mensajeMvc.Tipo == TipoNotificacionEnum.Informativo.ToString())
                    Informativo = mensajeMvc.Mensaje;
                else if (mensajeMvc.Tipo == TipoNotificacionEnum.Peligro.ToString())
                    Peligro = mensajeMvc.Mensaje;
                else if (mensajeMvc.Tipo == TipoNotificacionEnum.Satisfactorio.ToString())
                    Satisfactorio = mensajeMvc.Mensaje;
            }
        }

        #endregion

    }
}