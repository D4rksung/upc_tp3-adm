using PetCenter.Referencias.Dominio.Administracion.DTOs.Comun;
namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud
{
    public class BusquedaSolicitudDto
    {
        public SolicitudDto TablaFilter { get; set; }
        public CriterioPaginarDto CriterioPaginar { get; set; }
    }
}