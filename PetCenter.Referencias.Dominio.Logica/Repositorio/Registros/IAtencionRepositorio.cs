using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Atencion;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface IAtencionRepositorio : IRepositorio<GCR_Atenciones>
    {
        PaginadoVob<AtencionVob> Paginado(ICriterio<AtencionVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir);
        AtencionVob BuscarPorClienteReferencia(int idCliente, int idReferencia);
        IEnumerable<AtencionVob> ListarPorClienteReferencia(int idCliente, int idReferencia);
        AtencionVob BuscarPorRefServConv(int idReferencia, int idServicio, int idConvenio);
        IEnumerable<AtencionVob> ListarPorClientePeriodoMes(int idCliente, string anio, string mes);
        IEnumerable<AtencionTotalMesVob> ObtenerTotalAtencionesPorMes();
        IEnumerable<ServiciosPorAtencionVob> ObtenerServiciosPorAtencion();
    }
}