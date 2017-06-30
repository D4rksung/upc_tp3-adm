using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioServicio;

namespace PetCenter.Referencias.Presentacion.Web.Models.Comun.Servicio
{
    public class ServicioEditorModelo
    {
        #region PROPIEDADES
        public ConvenioServicioDto ConvenioServicio { get; set; }
       

        #endregion

        #region CONSTRUCTOR
        public ServicioEditorModelo()
        {
            ConvenioServicio = new ConvenioServicioDto();
        }
        #endregion
    }
}