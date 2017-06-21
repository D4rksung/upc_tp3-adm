using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Banco;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.TipoDocumento;
using PetCenter.Referencias.Inyeccion;

namespace PetCenter.Referencias.Dominio.Servicio
{
    public class MaestrosServicio
    {
        #region PROPIEDADES

        /// <summary>
        /// _registros
        /// </summary>
        private static MaestrosServicio _maestros = null;

        /// <summary>
        /// EquipoServicio
        /// </summary>
        public IBancoServicio BancoServicio { get { return Dependencia.Resolve<IBancoServicio>(); } }
        /// <summary>
        /// ActivoFijoServicio
        /// </summary>
        public IMonedaServicio MonedaServicio { get { return Dependencia.Resolve<IMonedaServicio>(); } }
        /// <summary>
        /// ObraCursoServicio
        /// </summary>
        public ITipoDocumentoServicio TipoDocumentoServicio { get { return Dependencia.Resolve<ITipoDocumentoServicio>(); } }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// ObraServicio
        /// </summary>
        public MaestrosServicio() { }

        /// <summary>
        /// ObtenerServicio
        /// </summary>
        /// <returns></returns>
        public static MaestrosServicio ObtenerServicio()
        {
            if (_maestros == null)
                _maestros = new MaestrosServicio();
            return _maestros;
        }

        #endregion
    }
}
