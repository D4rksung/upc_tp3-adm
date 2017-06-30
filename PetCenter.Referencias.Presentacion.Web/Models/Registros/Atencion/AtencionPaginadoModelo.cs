using PetCenter.Referencias.Presentacion.Web.Models.Comun;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Atencion
{
    public class AtencionPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public AtencionFiltroModelo Filtro { get; set; }

        public AtencionGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public AtencionPaginadoModelo()
        {
            Filtro = new AtencionFiltroModelo();
        }

        #endregion
    }
}