using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioDescuento;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Convenio
{
    public class ConvenioVob
    {
        public int NroConvenio { get; set; }

        public Nullable<int> IdCliente { get; set; }

        public Nullable<int> NroSolicitud { get; set; }

        public Nullable<System.DateTime> FechaConvenio { get; set; }

        public Nullable<System.DateTime> FechaVencimiento { get; set; }

        public Nullable<decimal> ImporteConvenio { get; set; }

        public string Observacion { get; set; }

        public string Estado { get; set; }
        public IEnumerable<ConvenioServicioVob> ListaConvenioServicio { get; set; }
        public IEnumerable<ConvenioDescuentoVob> ListaConvenioDescuento { get; set; }
        public string NroRuc { get; set; }
        public string RazonSocial { get; set; } 
    }
}
