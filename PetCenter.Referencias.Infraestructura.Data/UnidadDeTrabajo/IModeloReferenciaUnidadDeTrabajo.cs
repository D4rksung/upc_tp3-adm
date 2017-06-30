﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo
{
    using PetCenter.Referencias.Dominio.Logica.Entidades;
    using PetCenter.Referencias.Infraestructura.Data.Base;
    using System.Data.Entity;
    
    public interface IModeloReferenciaUnidadDeTrabajo : IConsultableUnidadDeTrabajo
    {
        DbSet<GCP_Cliente> GCP_Cliente { get; set; }
        DbSet<GCP_Especie> GCP_Especie { get; set; }
        DbSet<GCP_Mascota> GCP_Mascota { get; set; }
        DbSet<GCP_PersonaJuridica> GCP_PersonaJuridica { get; set; }
        DbSet<GCP_PersonaNatural> GCP_PersonaNatural { get; set; }
        DbSet<GCP_Raza> GCP_Raza { get; set; }
        DbSet<GCR_Atenciones> GCR_Atenciones { get; set; }
        DbSet<GCR_Convenio> GCR_Convenio { get; set; }
        DbSet<GCR_ConvenioServicio> GCR_ConvenioServicio { get; set; }
        DbSet<GCR_DocumentoRechazo> GCR_DocumentoRechazo { get; set; }
        DbSet<GCR_Liquidaciones> GCR_Liquidaciones { get; set; }
        DbSet<GCR_RepresentanteClinica> GCR_RepresentanteClinica { get; set; }
        DbSet<GCR_Solicitud_Convenio> GCR_Solicitud_Convenio { get; set; }
        DbSet<GCR_SolicitudRef> GCR_SolicitudRef { get; set; }
        DbSet<GCR_SolicitudRef_Servicio> GCR_SolicitudRef_Servicio { get; set; }
        DbSet<GG_Banco> GG_Banco { get; set; }
        DbSet<GG_Moneda> GG_Moneda { get; set; }
        DbSet<GG_Servicio> GG_Servicio { get; set; }
        DbSet<GRC_ConvenioDescuento> GRC_ConvenioDescuento { get; set; }
        DbSet<GCR_ContraReferencia> GCR_ContraReferencia { get; set; }
        DbSet<GCR_Veterinario> GCR_Veterinario { get; set; }
    }
}
