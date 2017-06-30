using PetCenter.Referencias.Presentacion.Web.Models.Comun;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Solicitud
{
    public class SolicitudPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public SolicitudFiltroModelo Filtro { get; set; }

        public SolicitudGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public SolicitudPaginadoModelo()
        {
            Filtro = new SolicitudFiltroModelo();
        }

        #endregion
    }
}