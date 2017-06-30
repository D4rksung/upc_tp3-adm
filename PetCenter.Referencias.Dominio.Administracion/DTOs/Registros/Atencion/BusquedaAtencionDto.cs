using PetCenter.Referencias.Dominio.Administracion.DTOs.Comun;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion
{
    public class BusquedaAtencionDto
    {
        public AtencionDto TablaFilter { get; set; }
        public CriterioPaginarDto CriterioPaginar { get; set; }
    }
}
