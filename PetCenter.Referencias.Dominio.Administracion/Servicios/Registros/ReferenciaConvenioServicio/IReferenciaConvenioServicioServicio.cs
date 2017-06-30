using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ReferenciaConvenioServicio;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.ReferenciaConvenioServicio
{
    public interface IReferenciaConvenioServicioServicio
    {
        
        IEnumerable<ReferenciaConvenioServicioDto> Listar(int idReferencia);
    }
}
