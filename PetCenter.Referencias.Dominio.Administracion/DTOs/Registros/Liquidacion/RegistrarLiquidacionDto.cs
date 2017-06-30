using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Liquidacion
{
    public class RegistrarLiquidacionDto
    {
        public AtencionDto Atencion { get; set; }
        public LiquidacionDto Liquidacion {get;set;}
    }
}