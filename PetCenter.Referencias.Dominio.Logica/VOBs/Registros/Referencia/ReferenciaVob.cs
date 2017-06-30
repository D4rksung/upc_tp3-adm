using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ReferenciaConvenioServicio;
using System;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Referencia
{
    public class ReferenciaVob
    {
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

        public IEnumerable<ReferenciaConvenioServicioVob> ListaReferenciaConvenioServicio { get; set; }

        public string NroRuc { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaSolicitudInicio { get; set; }
        public DateTime FechaSolicitudFin { get; set; }
        public string NombreMascota { get; set; }
        public int IdCliente { get; set; }
    }
}