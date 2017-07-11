//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetCenter.Referencias.Dominio.Logica.Entidades
{
    using System;
    using System.Collections.Generic;
    using PetCenter.Referencias.Dominio.Logica.Base;
    
    public partial class GCR_SolicitudRef : EntidadBase
    {
        public GCR_SolicitudRef()
        {
            this.GCR_ContraReferencia = new HashSet<GCR_ContraReferencia>();
            this.GCR_SolicitudRef_Servicio = new HashSet<GCR_SolicitudRef_Servicio>();
        }
    
        public int NroSolicitudRef { get; set; }
    
        public Nullable<int> NroConvenio { get; set; }
    
        public Nullable<int> IdMascota { get; set; }
    
        public Nullable<System.DateTime> FechaSolicitudRef { get; set; }
    
        public string Diagnostico { get; set; }
    
        public Nullable<System.DateTime> FechaTraslado { get; set; }
    
        public string Estado { get; set; }
    
        public string Anamnesis { get; set; }
    
        public string ExamenFisico { get; set; }
    
        public string ExamenAuxiliar { get; set; }
    
        public string NombreRefiere { get; set; }
    
    
        public virtual GCP_Mascota GCP_Mascota { get; set; }
        public virtual ICollection<GCR_ContraReferencia> GCR_ContraReferencia { get; set; }
        public virtual ICollection<GCR_SolicitudRef_Servicio> GCR_SolicitudRef_Servicio { get; set; }
        public virtual GCR_Convenio GCR_Convenio { get; set; }
        public override string NombreEntidad { get { return "GCR_SolicitudRef"; } }
    }
    
}
