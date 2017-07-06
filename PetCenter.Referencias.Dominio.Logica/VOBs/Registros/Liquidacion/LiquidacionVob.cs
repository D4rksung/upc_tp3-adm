using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Liquidacion
{
    public class LiquidacionVob
    {
        public int NroLiquidacion { get; set; }

        public string Anio { get; set; }

        public string Mes { get; set; }

        public Nullable<int> IdCliente { get; set; }

        public Nullable<System.DateTime> FechaLiquidacion { get; set; }

        public Nullable<decimal> ValorBruto { get; set; }

        public Nullable<decimal> ValorDctoComercial { get; set; }

        public Nullable<decimal> ValorNeto { get; set; }

        public Nullable<decimal> ValorImpuesto { get; set; }

        public Nullable<decimal> ValorTotal { get; set; }

        public Nullable<decimal> ValorAjuste { get; set; }
    }
}
