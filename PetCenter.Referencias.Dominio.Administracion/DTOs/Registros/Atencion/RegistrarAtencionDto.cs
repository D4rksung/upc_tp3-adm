using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion
{
    public class RegistrarAtencionDto
    {
        public AtencionDto Atencion { get; set; }
        public MascotaDto Mascota { get; set; }
        public ReferenciaDto Referencia { get; set; }
        public ServicioDto Servicio { get; set; }
    }
}