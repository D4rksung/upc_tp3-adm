using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota
{
    public class RespuestaMascotaDto
    {
        public IEnumerable<MascotaDto> lista { get; set; }
        public int TotalElementos { get; set; }
    }
}
