using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Evaluacion
{
    public class EvaluacionFiltroModelo
    {
        #region PROPIEDADES

        public SolicitudDto Solicitud { get; set; }

        #endregion

        #region CONSTRUCTOR

        public EvaluacionFiltroModelo() { }

        public EvaluacionFiltroModelo(SolicitudDto _Solicitud)
        {
            Solicitud = _Solicitud;
        }

        #endregion
    }
}