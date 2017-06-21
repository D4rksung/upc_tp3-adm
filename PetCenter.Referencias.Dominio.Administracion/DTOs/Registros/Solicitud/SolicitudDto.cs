using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud
{
    public class SolicitudDto
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
