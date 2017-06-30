using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Referencia
{
    public class ReferenciaEditorModelo : MensajeModelo
    {
        #region PROPIEDADES
        public ConvenioDto Convenio { get; set; }
        public ReferenciaDto Referencia { get; set; }
        public MascotaDto Mascota { get; set; }
        #endregion

        #region CONSTRUCTOR
        public ReferenciaEditorModelo()
        {
            Convenio = new ConvenioDto();
            Referencia = new ReferenciaDto();
            Mascota = new MascotaDto();
        }
        #endregion
    }
}