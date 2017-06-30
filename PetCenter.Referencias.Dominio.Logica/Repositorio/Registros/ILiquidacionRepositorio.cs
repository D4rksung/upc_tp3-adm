using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Liquidacion;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface ILiquidacionRepositorio : IRepositorio<GCR_Liquidaciones>
    {
        IEnumerable<LiquidacionTotalConvenioVob> ObtenerTotalPorConvenio();
    }
}
