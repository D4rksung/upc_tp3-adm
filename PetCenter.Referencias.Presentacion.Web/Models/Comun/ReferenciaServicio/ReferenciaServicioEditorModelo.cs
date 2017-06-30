using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioServicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ReferenciaConvenioServicio;

namespace PetCenter.Referencias.Presentacion.Web.Models.Comun.ReferenciaServicio
{
    public class ReferenciaServicioEditorModelo
    {
        #region PROPIEDADES
        public ReferenciaConvenioServicioDto ReferenciaConvenioServicio { get; set; }
        public ConvenioServicioDto ConvenioServicio { get; set; }

        #endregion

        #region CONSTRUCTOR
        public ReferenciaServicioEditorModelo()
        {
            ReferenciaConvenioServicio = new ReferenciaConvenioServicioDto();
            ConvenioServicio = new ConvenioServicioDto();
        }
        #endregion  
    }
}