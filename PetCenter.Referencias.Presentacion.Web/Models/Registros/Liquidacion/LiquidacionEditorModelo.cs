using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Liquidacion;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System.Collections.Generic;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Liquidacion
{
    public class LiquidacionEditorModelo : MensajeModelo
    {
        #region PROPIEDADES
        public AtencionDto Atencion { get; set; }
        public List<AtencionDto> ListaAtencion { get; set; }
        public LiquidacionDto Liquidacion { get; set; }
      
        #endregion

        #region CONSTRUCTOR
        public LiquidacionEditorModelo()
        {
            Atencion = new AtencionDto();
            ListaAtencion = new List<AtencionDto>();
            Liquidacion = new LiquidacionDto();
        }
        #endregion
    }
}