using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioDescuento
{
    public class ConvenioDescuentoDto
    {
        public int NroConvenio { get; set; }

        public int Item { get; set; }

        public string Descripcion { get; set; }

        public Nullable<int> Minimo { get; set; }

        public Nullable<int> Maximo { get; set; }

        public Nullable<decimal> FactorDcto { get; set; }
    }
}
