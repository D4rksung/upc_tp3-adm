using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Referencia;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface IReferenciaRepositorio : IRepositorio<GCR_SolicitudRef>
    {
        PaginadoVob<ReferenciaVob> Paginado(ICriterio<ReferenciaVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir);
        PaginadoVob<ReferenciaVob> PaginadoContra(ICriterio<ReferenciaVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir);
        ReferenciaVob Buscar(int idReferencia);
        IEnumerable<EspeciesCantidadVob> ObtenerEspecies();
        IEnumerable<RazasCantidadVob> ObtenerRaza(int idEspecie);
        
    }
}