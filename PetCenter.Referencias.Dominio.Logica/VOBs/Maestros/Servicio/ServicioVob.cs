using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Servicio
{
    public class ServicioVob
    {
        public int IdServicio { get; set; }

        public string NombreServicio { get; set; }

        public string DescripcionServicio { get; set; }

        public Nullable<decimal> TarifaBase { get; set; }

        public string Estado { get; set; }
    }
}
