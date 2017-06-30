using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Veterinario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Veterinario
{
    public interface IVeterinarioRepositorio : IRepositorio<GCR_Veterinario>
    {
        IEnumerable<VeterinarioVob> Listar();
    }
}
