using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ContraReferencia
{
    public class ContraReferenciaVob
    {
        public int NroContraReferencia { get; set; }

        public Nullable<int> NroSolicitudRef { get; set; }

        public Nullable<System.DateTime> FechaCierre { get; set; }

        public Nullable<System.DateTime> FechaEntrega { get; set; }

        public string Observaciones { get; set; }

        public Nullable<int> IdVeterinario { get; set; }

        public string Resultados { get; set; }

        public string NomVeterinario { get; set; }
    }
}
