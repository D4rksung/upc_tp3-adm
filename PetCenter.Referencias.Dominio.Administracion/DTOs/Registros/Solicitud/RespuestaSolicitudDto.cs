using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud
{
    public class RespuestaSolicitudDto
    {
        public IEnumerable<SolicitudDto> lista { get; set; }
        public int TotalElementos { get; set; }
    }
}
