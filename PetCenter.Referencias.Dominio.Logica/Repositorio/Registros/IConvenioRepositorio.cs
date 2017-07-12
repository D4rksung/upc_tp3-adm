using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Convenio;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface IConvenioRepositorio : IRepositorio<e.GCR_Convenio>
    {
        ConvenioVob Buscar(int idConvenio);
        ConvenioVob BuscarPorSolicitud(int idSolicitud);
    }
}
