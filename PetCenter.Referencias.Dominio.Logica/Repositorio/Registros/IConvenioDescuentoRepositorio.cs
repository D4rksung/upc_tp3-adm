using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioDescuento;
using System.Collections.Generic;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface IConvenioDescuentoRepositorio : IRepositorio<e.GCR_ConvenioDescuento>
    {
        IEnumerable<ConvenioDescuentoVob> Listar(int idConvenio);
    }
}
