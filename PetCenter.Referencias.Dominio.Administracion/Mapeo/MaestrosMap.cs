using PetCenter.Referencias.Dominio.Logica.Entidades;
using AutoMapper;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Banco;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Banco;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Veterinario;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Veterinario;

namespace PetCenter.Referencias.Dominio.Administracion.Mapeo
{
    public class MaestrosMap : Profile
    {
        public MaestrosMap()
        {
            CreateMap<BancoVob, BancoDto>().ReverseMap();
            CreateMap<BancoVob, GG_Banco>().ReverseMap();
            CreateMap<BancoDto, GG_Banco>().ReverseMap();

            CreateMap<MonedaVob, MonedaDto>().ReverseMap();
            CreateMap<MonedaVob, GG_Moneda>().ReverseMap();
            CreateMap<MonedaDto, GG_Moneda>().ReverseMap();

            //CreateMap<TipoDocumentoVob, TipoDocumentoDto>().ReverseMap();
            //CreateMap<TipoDocumentoVob, TipoDocumento>().ReverseMap();
            //CreateMap<TipoDocumentoDto, TipoDocumento>().ReverseMap();

            CreateMap<ServicioVob, ServicioDto>().ReverseMap();
            //CreateMap<ServicioVob, GG_Servicio>().ReverseMap();
            //CreateMap<ServicioDto, GG_Servicio>().ReverseMap();

            CreateMap<ServicioVob, GG_Servicio>()
                .ForMember(t => t.idServicio, f => f.MapFrom(c => c.IdServicio))
                .ForMember(t => t.nombre, f => f.MapFrom(c => c.NombreServicio))
                .ForMember(t => t.descripcion, f => f.MapFrom(c => c.DescripcionServicio))
                .ForMember(t => t.TarifaBase, f => f.MapFrom(c => c.TarifaBase))
                .ForMember(t => t.Estado, f => f.MapFrom(c => c.Estado))
                ;
            CreateMap<GG_Servicio, ServicioVob>()
              .ForMember(t => t.IdServicio, f => f.MapFrom(c => c.idServicio))
              .ForMember(t => t.NombreServicio, f => f.MapFrom(c => c.nombre))
              .ForMember(t => t.DescripcionServicio, f => f.MapFrom(c => c.descripcion))
              .ForMember(t => t.TarifaBase, f => f.MapFrom(c => c.TarifaBase))
              .ForMember(t => t.Estado, f => f.MapFrom(c => c.Estado))
              ;
            CreateMap<ServicioDto, GG_Servicio>()
               .ForMember(t => t.idServicio, f => f.MapFrom(c => c.IdServicio))
               .ForMember(t => t.nombre, f => f.MapFrom(c => c.NombreServicio))
               .ForMember(t => t.descripcion, f => f.MapFrom(c => c.DescripcionServicio))
               .ForMember(t => t.TarifaBase, f => f.MapFrom(c => c.TarifaBase))
               .ForMember(t => t.Estado, f => f.MapFrom(c => c.Estado))
               ;
            CreateMap<GG_Servicio, ServicioDto>()
            .ForMember(t => t.IdServicio, f => f.MapFrom(c => c.idServicio))
            .ForMember(t => t.NombreServicio, f => f.MapFrom(c => c.nombre))
            .ForMember(t => t.DescripcionServicio, f => f.MapFrom(c => c.descripcion))
            .ForMember(t => t.TarifaBase, f => f.MapFrom(c => c.TarifaBase))
            .ForMember(t => t.Estado, f => f.MapFrom(c => c.Estado))
            ;

            CreateMap<MascotaVob, MascotaDto>().ReverseMap();
            CreateMap<MascotaVob, GCP_Mascota>().ReverseMap();
            CreateMap<MascotaDto, GCP_Mascota>().ReverseMap();

            CreateMap<VeterinarioVob, VeterinarioDto>().ReverseMap();
            CreateMap<VeterinarioVob, GCR_Veterinario>().ReverseMap();
            CreateMap<VeterinarioDto, GCR_Veterinario>().ReverseMap();
        }
    }
}
