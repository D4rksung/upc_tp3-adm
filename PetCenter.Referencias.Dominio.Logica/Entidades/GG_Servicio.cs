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
    
    public partial class GG_Servicio : EntidadBase
    {
        public GG_Servicio()
        {
            this.GCR_ConvenioServicio = new HashSet<GCR_ConvenioServicio>();
        }
    
        public int IdServicio { get; set; }
    
        public string NombreServicio { get; set; }
    
        public string DescripcionServicio { get; set; }
    
        public Nullable<decimal> TarifaBase { get; set; }
    
        public string Estado { get; set; }
    
    
        public virtual ICollection<GCR_ConvenioServicio> GCR_ConvenioServicio { get; set; }
        public override string NombreEntidad { get { return "GG_Servicio"; } }
    }
    
}