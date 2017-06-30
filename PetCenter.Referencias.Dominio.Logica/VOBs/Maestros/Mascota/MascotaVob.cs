using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Mascota
{
    public class MascotaVob
    {
        public int IdMascota { get; set; }

        public Nullable<int> IdRaza { get; set; }

        public Nullable<int> IdEspecie { get; set; }

        public Nullable<int> IdCliente { get; set; }

        public string NombreMascota { get; set; }

        public Nullable<System.DateTime> FechaNacimiento { get; set; }

        public string Tamaño { get; set; }

        public string Genero { get; set; }

        public Nullable<decimal> Peso { get; set; }

        public string NombreEspecie { get; set; }
        public string NombreRaza { get; set; }
    }
}
