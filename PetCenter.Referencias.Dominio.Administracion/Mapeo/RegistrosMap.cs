using AutoMapper;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud;

namespace PetCenter.Referencias.Dominio.Administracion.Mapeo
{
    public class RegistrosMap : Profile
    {
        public RegistrosMap()
        {
            CreateMap<SolicitudVob, SolicitudDto>().ReverseMap();
            CreateMap<SolicitudVob, Solicitud>().ReverseMap();
            CreateMap<SolicitudDto, Solicitud>().ReverseMap();
        }
    }
}
