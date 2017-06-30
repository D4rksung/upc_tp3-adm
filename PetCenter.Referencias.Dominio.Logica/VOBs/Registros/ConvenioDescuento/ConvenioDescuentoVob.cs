using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioDescuento
{
    public class ConvenioDescuentoVob
    {
        public int NroConvenio { get; set; }

        public int Item { get; set; }

        public string Descripcion { get; set; }

        public Nullable<int> Minimo { get; set; }

        public Nullable<int> Maximo { get; set; }

        public Nullable<decimal> FactorDcto { get; set; }
    }
}
