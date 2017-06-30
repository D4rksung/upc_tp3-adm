using System;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud
{
    public class SolicitudVob
    {

        public int NroSolicitud { get; set; }

        public Nullable<System.DateTime> FechaSolicitud { get; set; }

        public string Estado { get; set; }

        public string NroRUC { get; set; }

        public string Direccion { get; set; }

        public string RazonSocial { get; set; }

        public string Referencia { get; set; }

        public string Telefono { get; set; }

        public string Web { get; set; }

        public string TpoDocRep { get; set; }

        public string NroDocRep { get; set; }

        public string NombreRep { get; set; }

        public string TelefonoRep { get; set; }

        public string CorreoRep { get; set; }

        public string Nrogarantia { get; set; }

        public Nullable<System.DateTime> FechaVencimientoG { get; set; }

        public Nullable<int> IdBanco { get; set; }

        public Nullable<int> IdMoneda { get; set; }

        public Nullable<decimal> ImporteGarantia { get; set; }

        public string DocReciboTitulo { get; set; }

        public byte[] DocReciboObjeto { get; set; }

        public string DocColegiaturaTitulo { get; set; }

        public byte[] DocColegiaturaObjeto { get; set; }

        public string DocSunatTitulo { get; set; }

        public byte[] DocSunatObjeto { get; set; }

        public string DocLicenciaTitulo { get; set; }

        public byte[] DocLicenciaObjeto { get; set; }

        public string DocCentralTitulo { get; set; }

        public byte[] DocCentralObjeto { get; set; }

        public string DesEstado { get; set; }

        public System.DateTime FechaSolicitudInicio { get; set; }
        public System.DateTime FechaSolicitudHasta { get; set; }

        public string NroSolicitudFormato { get; set; }

    }
}
