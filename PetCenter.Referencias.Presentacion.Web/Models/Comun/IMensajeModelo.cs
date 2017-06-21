namespace PetCenter.Referencias.Presentacion.Web.Models.Comun
{
    /// <summary>
    /// MensajeModelo
    /// </summary>
    public interface IMensajeModelo
    {
        /// <summary>
        /// ExisteMensaje
        /// </summary>
        bool ExisteMensaje { get; set; }

        /// <summary>
        /// Satisfactorio
        /// </summary>
        string Satisfactorio { get; set; }

        /// <summary>
        /// Info
        /// </summary>
        string Informativo { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        string Error { get; set; }

        /// <summary>
        /// Peligro
        /// </summary>
        string Peligro { get; set; }

        /// <summary>
        /// Advertencia
        /// </summary>
        string Advertencia { get; set; }

        /// <summary>
        /// Alerta
        /// </summary>
        string Alerta { get; set; }
    }
}