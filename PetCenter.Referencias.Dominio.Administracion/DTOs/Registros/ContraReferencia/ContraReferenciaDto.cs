using System;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ContraReferencia
{
    public class ContraReferenciaDto
    {
        public int NroContraReferencia { get; set; }

        public Nullable<int> NroSolicitudRef { get; set; }

        public Nullable<System.DateTime> FechaCierre { get; set; }

        public Nullable<System.DateTime> FechaEntrega { get; set; }

        public string Observaciones { get; set; }

        public Nullable<int> IdVeterinario { get; set; }

        public string Resultados { get; set; }

        public string NomVeterinario { get; set; }

        public string NroContraReferenciaFormato { get; set; }
    }
}
