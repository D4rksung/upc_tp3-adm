using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Solicitud;
using PetCenter.Referencias.Inyeccion;

namespace PetCenter.Referencias.Dominio.Servicio
{
    public class RegistrosServicio
    {
        #region PROPIEDADES

        /// <summary>
        /// _registros
        /// </summary>
        private static RegistrosServicio _registros = null;

        /// <summary>
        /// ObraCursoServicio
        /// </summary>
        public ISolicitudServicio SolicitudServicio { get { return Dependencia.Resolve<ISolicitudServicio>(); } }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// ObraServicio
        /// </summary>
        public RegistrosServicio() { }

        /// <summary>
        /// ObtenerServicio
        /// </summary>
        /// <returns></returns>
        public static RegistrosServicio ObtenerServicio()
        {
            if (_registros == null)
                _registros = new RegistrosServicio();
            return _registros;
        }

        #endregion
    }
}
