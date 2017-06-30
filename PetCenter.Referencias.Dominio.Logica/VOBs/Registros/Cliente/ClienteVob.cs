using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Cliente
{
    public class ClienteVob
    {
        public int IdCliente { get; set; }

        public string NombreCliente { get; set; }

        public string EmailCliente { get; set; }

        public string AutorizaUsoDatos { get; set; }
    }
}
