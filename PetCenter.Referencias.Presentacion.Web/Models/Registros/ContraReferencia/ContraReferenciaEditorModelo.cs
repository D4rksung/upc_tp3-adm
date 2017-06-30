using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ContraReferencia;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System.Collections.Generic;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.ContraReferencia
{
    public class ContraReferenciaEditorModelo : MensajeModelo
    {
        #region PROPIEDADES
        public ReferenciaDto Referencia { get; set; }
        public ContraReferenciaDto ContraReferencia { get; set; }
        public MascotaDto Mascota { get; set; }
        public ServicioDto Servicio { get; set; }
        public List<AtencionDto> ListaAtenciones { get; set; }
        #endregion

        #region CONSTRUCTOR
        public ContraReferenciaEditorModelo()
        {
            Referencia = new ReferenciaDto();
            ContraReferencia = new ContraReferenciaDto();
            Mascota = new MascotaDto();
            Servicio = new ServicioDto();
            ListaAtenciones = new List<AtencionDto>();
        }
        #endregion
    }
}