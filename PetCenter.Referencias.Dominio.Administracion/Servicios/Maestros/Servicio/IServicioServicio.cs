using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Servicio
{
    public interface IServicioServicio
    {
        IEnumerable<ServicioDto> Listar();

        ServicioDto Buscar(int idServicio);
    }
}
