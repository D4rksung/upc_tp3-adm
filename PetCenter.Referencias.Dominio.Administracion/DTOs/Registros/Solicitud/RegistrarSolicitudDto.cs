using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.DocumentoRechazo;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud
{
    public class RegistrarSolicitudDto
    {
        public SolicitudDto Solicitud { get; set; }
        public DocumentoRechazoDto DocumentoRechazo { get; set; }
    }
}
