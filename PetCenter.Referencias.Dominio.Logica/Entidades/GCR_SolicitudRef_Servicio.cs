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
    
    public partial class GCR_SolicitudRef_Servicio : EntidadBase
    {
        public GCR_SolicitudRef_Servicio()
        {
            this.GCR_Atenciones = new HashSet<GCR_Atenciones>();
        }
    
        public int NroSolicitudRef { get; set; }
    
        public int IdServicio { get; set; }
    
        public int NroConvenio { get; set; }
    
        public Nullable<int> Cantidad { get; set; }
    
        public string Observaciones { get; set; }
    
        public Nullable<decimal> TarifaBase { get; set; }
    
        public Nullable<decimal> ValorBruto { get; set; }
    
        public Nullable<decimal> Descuento { get; set; }
    
        public Nullable<decimal> ValorNeto { get; set; }
    
    
        public virtual ICollection<GCR_Atenciones> GCR_Atenciones { get; set; }
        public virtual GCR_ConvenioServicio GCR_ConvenioServicio { get; set; }
        public virtual GCR_SolicitudRef GCR_SolicitudRef { get; set; }
        public override string NombreEntidad { get { return "GCR_SolicitudRef_Servicio"; } }
    }
    
}