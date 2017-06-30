using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio
{
    public class RegistrarConvenioDto
    {
        public ConvenioDto Convenio { get; set; }
        public SolicitudDto Solicitud { get; set; }
    }
}
