using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioServicio;
using System.Collections.Generic;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface IConvenioServicioRepositorio : IRepositorio<e.GCR_ConvenioServicio>
    {
        IEnumerable<ConvenioServicioVob> Listar(int idConvenio);
        ConvenioServicioVob Buscar(int idServicio, int idConvenio);
    }
}