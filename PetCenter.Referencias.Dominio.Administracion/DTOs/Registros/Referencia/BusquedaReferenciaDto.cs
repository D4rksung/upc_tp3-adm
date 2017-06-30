using PetCenter.Referencias.Dominio.Administracion.DTOs.Comun;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia
{
    public class BusquedaReferenciaDto
    {
        public ReferenciaDto TablaFilter { get; set; }
        public CriterioPaginarDto CriterioPaginar { get; set; }
    }
}
