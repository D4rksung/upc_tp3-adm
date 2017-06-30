using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Liquidacion;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Liquidacion
{
    public interface ILiquidacionServicio
    {
        LiquidacionDto Calcular(IEnumerable<AtencionDto> listaAtencion);
        int Registrar(RegistrarLiquidacionDto editor);
        IEnumerable<LiquidacionTotalConvenioDto> ObtenerTotalPorConvenio();
    }
}
