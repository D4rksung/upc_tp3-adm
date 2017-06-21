using PetCenter.Referencias.Dominio.Logica.Entidades;
using AutoMapper;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Banco;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Banco;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.TipoDocumento;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.TipoDocumento;

namespace PetCenter.Referencias.Dominio.Administracion.Mapeo
{
    public class MaestrosMap : Profile
    {
        public MaestrosMap()
        {
            CreateMap<BancoVob, BancoDto>().ReverseMap();
            CreateMap<BancoVob, Banco>().ReverseMap();
            CreateMap<BancoDto, Banco>().ReverseMap();

            CreateMap<MonedaVob, MonedaDto>().ReverseMap();
            CreateMap<MonedaVob, Moneda>().ReverseMap();
            CreateMap<MonedaDto, Moneda>().ReverseMap();

            CreateMap<TipoDocumentoVob, TipoDocumentoDto>().ReverseMap();
            CreateMap<TipoDocumentoVob, TipoDocumento>().ReverseMap();
            CreateMap<TipoDocumentoDto, TipoDocumento>().ReverseMap();
        }
    }
}
