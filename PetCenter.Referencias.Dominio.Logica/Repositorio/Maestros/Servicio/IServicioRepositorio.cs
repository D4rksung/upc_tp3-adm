using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Servicio;
using System.Collections.Generic;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Servicio
{
    public interface IServicioRepositorio : IRepositorio<e.GG_Servicio>
    {
        IEnumerable<ServicioVob> Listar();

        ServicioVob Buscar(int idServicio);
    }
}
