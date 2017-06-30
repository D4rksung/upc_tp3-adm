using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface ISolicitudRepositorio : IRepositorio<e.GCR_Solicitud_Convenio>
    {
        PaginadoVob<SolicitudVob> Paginado(ICriterio<SolicitudVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir);
        SolicitudVob Buscar(int idSolicitud);
    }
}
