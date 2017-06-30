using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Banco;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.ConvenioServicio;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.General;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Veterinario;
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
        //public ITipoDocumentoServicio TipoDocumentoServicio { get { return Dependencia.Resolve<ITipoDocumentoServicio>(); } }

        public IServicioServicio ServicioServicio { get { return Dependencia.Resolve<IServicioServicio>(); } }

        public IMascotaServicio MascotaServicio { get { return Dependencia.Resolve<IMascotaServicio>(); } }

        public IConvenioServicioServicio ConvenioServicioServicio { get { return Dependencia.Resolve<IConvenioServicioServicio>(); } }

        public IGeneralServicio GeneralServicio { get { return Dependencia.Resolve<IGeneralServicio>(); } }

        public IVeterinarioServicio VeterinarioServicio { get { return Dependencia.Resolve<IVeterinarioServicio>(); } }

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
