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
    
    public partial class GCR_DocumentoRechazo : EntidadBase
    {
        public int NroDocumento { get; set; }
    
        public Nullable<int> NroSolicitud { get; set; }
    
        public string Motivo { get; set; }
    
        public Nullable<System.DateTime> FechaRechazo { get; set; }
    
        public string Observaciones { get; set; }
    
    
        public virtual GCR_Solicitud_Convenio GCR_Solicitud_Convenio { get; set; }
        public override string NombreEntidad { get { return "GCR_DocumentoRechazo"; } }
    }
    
}
