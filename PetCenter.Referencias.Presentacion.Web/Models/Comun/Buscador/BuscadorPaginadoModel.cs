using System.Collections.Generic;
namespace PetCenter.Referencias.Presentacion.Web.Models.Comun.Buscador
{
    /// <summary>
    /// Modelo buscador paginado
    /// </summary>
    public class BuscadorPaginadoModel<T> where T : class
    {

        #region PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public GridModelo<T> Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public BuscadorPaginadoModel()
        {
            Grid = new GridModelo<T>(new List<T>());
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="elementosPagina">elementosPagina</param>
        /// <param name="tamanioPagina">tamanioPagina</param>
        /// <param name="totalPagina">totalPagina</param>
        public BuscadorPaginadoModel(IEnumerable<T> elementosPagina, int tamanioPagina, int totalPagina)
        {
            Grid = new GridModelo<T>(elementosPagina, tamanioPagina, totalPagina);
        }

        #endregion
    }
}