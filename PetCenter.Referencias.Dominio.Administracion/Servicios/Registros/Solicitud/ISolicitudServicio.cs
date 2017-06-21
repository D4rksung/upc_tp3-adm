using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Solicitud
{
    public interface ISolicitudServicio
    {
        int Registrar(RegistrarSolicitudDto registro);
    }
}
