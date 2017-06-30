using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Atencion
{
    public class AtencionEditorModelo : MensajeModelo
    {
        #region PROPIEDADES
        public ReferenciaDto Referencia { get; set; }
        public AtencionDto Atencion { get; set; }
        public MascotaDto Mascota { get; set; }
        public ServicioDto Servicio { get; set; }
        #endregion

        #region CONSTRUCTOR
        public AtencionEditorModelo()
        {
            Referencia = new ReferenciaDto();
            Atencion = new AtencionDto();
            Mascota = new MascotaDto();
            Servicio = new ServicioDto();
        }
        #endregion
    }
}