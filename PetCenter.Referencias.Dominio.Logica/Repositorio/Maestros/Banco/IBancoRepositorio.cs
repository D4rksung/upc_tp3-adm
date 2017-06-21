using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Banco;
using System.Collections.Generic;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Banco
{
    public interface IBancoRepositorio : IRepositorio<e.Banco>
    {
        IEnumerable<BancoVob> Listar();
    }
}
