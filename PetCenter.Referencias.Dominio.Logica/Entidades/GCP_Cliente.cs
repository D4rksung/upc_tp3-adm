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
    
    public partial class GCP_Cliente : EntidadBase
    {
        public GCP_Cliente()
        {
            this.GCP_Mascota = new HashSet<GCP_Mascota>();
            this.GCR_Convenio = new HashSet<GCR_Convenio>();
            this.GCR_Liquidaciones = new HashSet<GCR_Liquidaciones>();
        }
    
        public int IdCliente { get; set; }
    
        public string CodigoCliente { get; set; }
    
        public string NombreCliente { get; set; }
    
        public string ApellidoCliente { get; set; }
    
        public string NumeroDocumento { get; set; }
    
        public string Direccion { get; set; }
    
        public string Telefono { get; set; }
    
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
    
        public string Email { get; set; }
    
        public string TipoDocumento { get; set; }
    
    
        public virtual ICollection<GCP_Mascota> GCP_Mascota { get; set; }
        public virtual GCP_PersonaNatural GCP_PersonaNatural { get; set; }
        public virtual ICollection<GCR_Convenio> GCR_Convenio { get; set; }
        public virtual ICollection<GCR_Liquidaciones> GCR_Liquidaciones { get; set; }
        public virtual GCP_PersonaJuridica GCP_PersonaJuridica { get; set; }
        public override string NombreEntidad { get { return "GCP_Cliente"; } }
    }
    
}
