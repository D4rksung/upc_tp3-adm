using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.ContraReferencia;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Convenio;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Liquidacion;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Referencia;
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

        public IConvenioServicio ConvenioServicio { get { return Dependencia.Resolve<IConvenioServicio>(); } }

        public IReferenciaServicio ReferenciaServicio { get { return Dependencia.Resolve<IReferenciaServicio>(); } }

        public IAtencionServicio AtencionServicio { get { return Dependencia.Resolve<IAtencionServicio>(); } }

        public ILiquidacionServicio LiquidacionServicio { get { return Dependencia.Resolve<ILiquidacionServicio>(); } }

        public IContraReferenciaServicio ContraReferenciaServicio { get { return Dependencia.Resolve<IContraReferenciaServicio>(); } }

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
