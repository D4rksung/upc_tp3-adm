using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Mascota
{
    public  interface IMascotaServicio 
    {
        IEnumerable<MascotaDto> Listar(int idCliente);
        RespuestaMascotaDto Busqueda(BusquedaMascotaDto solicitud);
        MascotaDto Buscar(int idMascota);
    }
}
