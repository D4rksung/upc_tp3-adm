using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ReferenciaConvenioServicio
{
    public class ReferenciaConvenioServicioVob
    {
        public int NroSolicitudRef { get; set; }

        public int IdServicio { get; set; }

        public int NroConvenio { get; set; }

        public Nullable<int> Cantidad { get; set; }

        public string Observaciones { get; set; }

        public Nullable<decimal> TarifaBase { get; set; }

        public Nullable<decimal> ValorBruto { get; set; }

        public Nullable<decimal> Descuento { get; set; }

        public Nullable<decimal> ValorNeto { get; set; }

        public string NombreServicio { get; set; }
    }
}
