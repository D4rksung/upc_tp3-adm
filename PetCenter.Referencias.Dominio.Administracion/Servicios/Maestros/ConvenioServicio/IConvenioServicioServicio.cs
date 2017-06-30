using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioServicio;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.ConvenioServicio
{
    public interface IConvenioServicioServicio
    {
        IEnumerable<ConvenioServicioDto> Listar(int idConvenio);
        ConvenioServicioDto Buscar(int idServicio, int idConvenio);
    }
}