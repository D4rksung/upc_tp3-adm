using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia
{
    public class RespuestaReferenciaDto
    {
        public IEnumerable<ReferenciaDto> lista { get; set; }
        public int TotalElementos { get; set; }
    }
}