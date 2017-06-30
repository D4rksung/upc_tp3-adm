using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Atencion
{
    public interface IAtencionServicio
    {
        RespuestaAtencionDto Busqueda(BusquedaAtencionDto solicitud);
        AtencionDto BuscarPorClienteReferencia(int idCliente, int idReferencia);
        AtencionDto BuscarPorRefServConv(int idReferencia, int idServicio, int idConvenio);
        int Registrar(RegistrarAtencionDto editor);
        IEnumerable<AtencionDto> ListarPorClienteReferencia(int idCliente, int idReferencia);
        IEnumerable<AtencionTotalMesDto> ObtenerTotalAtencionesPorMes();
        IEnumerable<ServiciosPorAtencionDto> ObtenerServiciosPorAtencion();
    }
}
