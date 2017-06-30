using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia
{
    public class RegistrarReferenciaDto
    {
        public ConvenioDto Convenio { get; set; }
        public ReferenciaDto Referencia { get; set; }
        public MascotaDto Mascota { get; set; }
    }
}
