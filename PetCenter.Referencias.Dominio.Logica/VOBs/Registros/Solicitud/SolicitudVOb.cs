using System;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud
{
    public class SolicitudVob
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string NroRuc { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Web { get; set; }
        public int IdTipoDocumento { get; set; }
        public string DesTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string NombresCompletos { get; set; }
        public string Email { get; set; }
        public string TelefonoRep { get; set; }
        public int IdBanco { get; set; }
        public string DesBanco { get; set; }
        public int IdMoneda { get; set; }
        public string DesMoneda { get; set; }
        public string Monto { get; set; }
        public string NroReferencia { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
