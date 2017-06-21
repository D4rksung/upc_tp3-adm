using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Moneda;
using System.Collections.Generic;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Moneda
{
    public interface IMonedaRepositorio : IRepositorio<e.Moneda>
    {
        IEnumerable<MonedaVob> Listar();
    }
}
