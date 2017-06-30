using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Veterinario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Veterinario
{
    public interface IVeterinarioServicio
    {
        IEnumerable<VeterinarioDto> Listar();
    }
}
