using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ContraReferencia
{
    public class RegistrarContraReferenciaDto
    {
        public ContraReferenciaDto ContraReferencia { get; set; }
        public MascotaDto Mascota { get; set; }
        public ReferenciaDto Referencia { get; set; }
        public ServicioDto Servicio { get; set; }
    }
}