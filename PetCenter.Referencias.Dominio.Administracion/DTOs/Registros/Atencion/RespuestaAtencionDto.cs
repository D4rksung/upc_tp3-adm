using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion
{
    public class RespuestaAtencionDto
    {
        public IEnumerable<AtencionDto> lista { get; set; }
        public int TotalElementos { get; set; }
    }
}
