using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Referencia
{
    public interface IReferenciaServicio
    {
        int Registrar(RegistrarReferenciaDto registro);

        RespuestaReferenciaDto Busqueda(BusquedaReferenciaDto solicitud);
        ReferenciaDto Buscar(int idReferencia);
        IEnumerable<EspeciesCantidadDto> ObtenerEspecies();
        IEnumerable<RazasCantidadDto> ObtenerRaza(int idEspecie);

    }
}
