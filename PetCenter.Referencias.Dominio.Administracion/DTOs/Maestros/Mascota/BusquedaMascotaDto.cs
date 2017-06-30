using PetCenter.Referencias.Dominio.Administracion.DTOs.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota
{
    public class BusquedaMascotaDto
    {
        public MascotaDto TablaFilter { get; set; }
        public CriterioPaginarDto CriterioPaginar { get; set; }
    }
}
