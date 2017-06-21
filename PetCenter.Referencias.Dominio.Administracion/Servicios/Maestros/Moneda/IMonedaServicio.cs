using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Moneda;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Moneda
{
    public interface IMonedaServicio
    {
        IEnumerable<MonedaDto> Listar();
    }
}
