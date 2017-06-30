using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Mascota;
using System.Collections.Generic;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Mascota
{
    public interface IMascotaRepositorio : IRepositorio<e.GCP_Mascota>
    {
        IEnumerable<MascotaVob> Listar(int idCliente);
        PaginadoVob<MascotaVob> Paginado(ICriterio<MascotaVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir);
        MascotaVob Buscar(int idMascota);
    }
}
