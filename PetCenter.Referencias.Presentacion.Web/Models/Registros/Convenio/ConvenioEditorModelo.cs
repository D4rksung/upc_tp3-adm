using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Convenio
{
    public class ConvenioEditorModelo : MensajeModelo
    {
        #region PROPIEDADES
        public ConvenioDto Convenio { get; set; }
        public SolicitudDto Solicitud { get; set; }

        #endregion

        #region CONSTRUCTOR
        public ConvenioEditorModelo()
        {
            Convenio = new ConvenioDto();
            Solicitud = new SolicitudDto();
        }
        #endregion
    }
}