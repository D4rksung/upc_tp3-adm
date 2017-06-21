using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Banco;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Banco
{
    public interface IBancoServicio
    {
        IEnumerable<BancoDto> Listar();
    }
}
