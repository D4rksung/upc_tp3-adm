using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Solicitud
{
    public interface ISolicitudServicio
    {
        int Registrar(RegistrarSolicitudDto registro);
        int Modificar(RegistrarSolicitudDto registro);
        int Rechazar(RegistrarSolicitudDto registro);
        RespuestaSolicitudDto Busqueda(BusquedaSolicitudDto solicitud);
        SolicitudDto Buscar(int idSolicitud);
    }
}
