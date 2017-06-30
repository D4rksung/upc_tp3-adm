namespace PetCenter.Referencias.Presentacion.Web.Models.Comun.Buscador
{
    /// <summary>
    /// Modelo buscador paginado
    /// </summary>
    public class BuscadorModel
    {

        #region PROPIEDADES

        /// <summary>
        /// BuscadorFiltro
        /// </summary>
        public string BuscadorFiltro { get; set; }

        /// <summary>
        /// BuscadorAccion
        /// </summary>
        public string BuscadorAccion { get; set; }

        /// <summary>
        /// BuscadorControlador
        /// </summary>
        public string BuscadorControlador { get; set; }

        /// <summary>
        /// BuscadorParametros
        /// </summary>
        public string BuscadorParametros { get; set; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="accion">accion</param>
        /// <param name="controlador">controlador</param>
        public BuscadorModel(string accion, string controlador, string parametros)
        {
            BuscadorAccion = accion;
            BuscadorControlador = controlador;
            BuscadorParametros = parametros;
        }

        #endregion

    }
}