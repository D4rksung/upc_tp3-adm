using AutoMapper;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ContraReferencia;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioDescuento;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioServicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.DocumentoRechazo;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Liquidacion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ReferenciaConvenioServicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ContraReferencia;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Convenio;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioDescuento;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioServicio;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.DocumentoRechazo;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Liquidacion;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Referencia;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ReferenciaConvenioServicio;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud;

namespace PetCenter.Referencias.Dominio.Administracion.Mapeo
{
    public class RegistrosMap : Profile
    {
        public RegistrosMap()
        {
            CreateMap<SolicitudVob, SolicitudDto>().ReverseMap();
            CreateMap<SolicitudVob, GCR_Solicitud_Convenio>().ReverseMap();
            CreateMap<SolicitudDto, GCR_Solicitud_Convenio>().ReverseMap();

            CreateMap<ConvenioVob, ConvenioDto>().ReverseMap();
            CreateMap<ConvenioVob, GCR_Convenio>().ReverseMap();
            //CreateMap<ConvenioDto, Convenio>().ReverseMap();
            CreateMap<ConvenioDto, GCR_Convenio>()
                .ForMember(t => t.GCR_ConvenioDescuento, f => f.MapFrom(c => c.ListaConvenioDescuento))
                .ForMember(t => t.GCR_ConvenioServicio, f => f.MapFrom(c => c.ListaConvenioServicio))
                .ForMember(t => t.FechaConvenio, f => f.MapFrom(c => c.FechaConvenio))
                .ForMember(t => t.NroSolicitud, f => f.MapFrom(c => c.NroSolicitud))
                .ForMember(t => t.Observacion, f => f.MapFrom(c => c.Observacion))
                .ForMember(t => t.ImporteConvenio, f => f.MapFrom(c => c.ImporteConvenio))
                .ForMember(t => t.FechaVencimiento, f => f.MapFrom(c => c.FechaVencimiento))
                .ForMember(t => t.Estado, f => f.MapFrom(c => c.Estado))
                ;

            CreateMap<GCR_Convenio, ConvenioDto>()
               .ForMember(t => t.ListaConvenioDescuento, f => f.MapFrom(c => c.GCR_ConvenioDescuento))
               .ForMember(t => t.ListaConvenioServicio, f => f.MapFrom(c => c.GCR_ConvenioServicio))
                .ForMember(t => t.FechaConvenio, f => f.MapFrom(c => c.FechaConvenio))
                .ForMember(t => t.NroSolicitud, f => f.MapFrom(c => c.NroSolicitud))
                .ForMember(t => t.Observacion, f => f.MapFrom(c => c.Observacion))
                .ForMember(t => t.ImporteConvenio, f => f.MapFrom(c => c.ImporteConvenio))
                .ForMember(t => t.FechaVencimiento, f => f.MapFrom(c => c.FechaVencimiento))
                .ForMember(t => t.Estado, f => f.MapFrom(c => c.Estado))
               ;

            CreateMap<ConvenioServicioVob, ConvenioServicioDto>().ReverseMap();
            CreateMap<ConvenioServicioVob, GCR_ConvenioServicio>().ReverseMap();
            CreateMap<ConvenioServicioDto, GCR_ConvenioServicio>().ReverseMap();

            CreateMap<ConvenioDescuentoVob, ConvenioDescuentoDto>().ReverseMap();
            CreateMap<ConvenioDescuentoVob, GCR_ConvenioDescuento>().ReverseMap();
            CreateMap<ConvenioDescuentoDto, GCR_ConvenioDescuento>().ReverseMap();

            CreateMap<ReferenciaConvenioServicioVob, ReferenciaConvenioServicioDto>().ReverseMap();
            CreateMap<ReferenciaConvenioServicioVob, GCR_SolicitudRef_Servicio>().ReverseMap();
            CreateMap<ReferenciaConvenioServicioDto, GCR_SolicitudRef_Servicio>().ReverseMap();

            CreateMap<DocumentoRechazoVob, DocumentoRechazoDto>().ReverseMap();
            CreateMap<DocumentoRechazoVob, GCR_DocumentoRechazo>().ReverseMap();
            CreateMap<DocumentoRechazoDto, GCR_DocumentoRechazo>().ReverseMap();


            CreateMap<ReferenciaVob, ReferenciaDto>().ReverseMap();
            CreateMap<ReferenciaVob, GCR_SolicitudRef>().ReverseMap();
            //CreateMap<ConvenioDto, Convenio>().ReverseMap();
            CreateMap<ReferenciaDto, GCR_SolicitudRef>()
                .ForMember(t => t.GCR_SolicitudRef_Servicio, f => f.MapFrom(c => c.ListaReferenciaConvenioServicio))
                .ForMember(t => t.NroSolicitudRef, f => f.MapFrom(c => c.NroSolicitudRef))
                .ForMember(t => t.NroConvenio, f => f.MapFrom(c => c.NroConvenio))
                .ForMember(t => t.IdMascota, f => f.MapFrom(c => c.IdMascota))
                .ForMember(t => t.FechaSolicitudRef, f => f.MapFrom(c => c.FechaSolicitudRef))
                .ForMember(t => t.Diagnostico, f => f.MapFrom(c => c.Diagnostico))
                .ForMember(t => t.FechaTraslado, f => f.MapFrom(c => c.FechaTraslado))
                .ForMember(t => t.Anamnesis, f => f.MapFrom(c => c.Anamnesis))
                .ForMember(t => t.ExamenFisico, f => f.MapFrom(c => c.ExamenFisico))
                .ForMember(t => t.ExamenAuxiliar, f => f.MapFrom(c => c.ExamenAuxiliar))
                .ForMember(t => t.NombreRefiere, f => f.MapFrom(c => c.NombreRefiere))
                .ForMember(t => t.Estado, f => f.MapFrom(c => c.Estado))
                ;

            CreateMap<GCR_SolicitudRef, ReferenciaDto>()
               .ForMember(t => t.ListaReferenciaConvenioServicio, f => f.MapFrom(c => c.GCR_SolicitudRef_Servicio))
                .ForMember(t => t.NroSolicitudRef, f => f.MapFrom(c => c.NroSolicitudRef))
                .ForMember(t => t.NroConvenio, f => f.MapFrom(c => c.NroConvenio))
                .ForMember(t => t.IdMascota, f => f.MapFrom(c => c.IdMascota))
                .ForMember(t => t.FechaSolicitudRef, f => f.MapFrom(c => c.FechaSolicitudRef))
                .ForMember(t => t.Diagnostico, f => f.MapFrom(c => c.Diagnostico))
                .ForMember(t => t.FechaTraslado, f => f.MapFrom(c => c.FechaTraslado))
                .ForMember(t => t.Anamnesis, f => f.MapFrom(c => c.Anamnesis))
                .ForMember(t => t.ExamenFisico, f => f.MapFrom(c => c.ExamenFisico))
                .ForMember(t => t.ExamenAuxiliar, f => f.MapFrom(c => c.ExamenAuxiliar))
                .ForMember(t => t.NombreRefiere, f => f.MapFrom(c => c.NombreRefiere))
                .ForMember(t => t.Estado, f => f.MapFrom(c => c.Estado))
               ;


            CreateMap<AtencionVob, AtencionDto>().ReverseMap();
            CreateMap<AtencionVob, GCR_Atenciones>().ReverseMap();
            CreateMap<AtencionDto, GCR_Atenciones>().ReverseMap();

            CreateMap<AtencionTotalMesDto, AtencionTotalMesVob>().ReverseMap();

            CreateMap<ServiciosPorAtencionDto, ServiciosPorAtencionVob>().ReverseMap();

            CreateMap<LiquidacionVob, LiquidacionDto>().ReverseMap();
            CreateMap<LiquidacionVob, GCR_Liquidaciones>().ReverseMap();
            CreateMap<LiquidacionDto, GCR_Liquidaciones>().ReverseMap();

            CreateMap<LiquidacionTotalConvenioVob, LiquidacionTotalConvenioDto>().ReverseMap();            

            CreateMap<ContraReferenciaVob, ContraReferenciaDto>().ReverseMap();
            CreateMap<ContraReferenciaVob, GCR_ContraReferencia>().ReverseMap();
            CreateMap<ContraReferenciaDto, GCR_ContraReferencia>().ReverseMap();

            CreateMap<EspeciesCantidadDto, EspeciesCantidadVob>().ReverseMap();

            CreateMap<RazasCantidadDto, RazasCantidadVob>().ReverseMap();
        }
    }
}