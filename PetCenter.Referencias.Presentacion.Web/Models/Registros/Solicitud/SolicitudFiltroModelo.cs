using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Solicitud
{
    public class SolicitudFiltroModelo
    {
        #region PROPIEDADES

        public SolicitudDto Solicitud { get; set; }

        #endregion

        #region CONSTRUCTOR

        public SolicitudFiltroModelo() { }

        public SolicitudFiltroModelo(SolicitudDto _Solicitud)
        {
            Solicitud = _Solicitud;
        }

        #endregion
    }
}