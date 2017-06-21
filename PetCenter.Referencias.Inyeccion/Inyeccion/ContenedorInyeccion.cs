#region ESPACIOS DE NOMBRES

using Microsoft.Practices.Unity;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Banco;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.TipoDocumento;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Solicitud;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Banco;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.TipoDocumento;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Banco;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Moneda;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Solicitud;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.TipoDocumento;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using PetCenter.Referencias.Transversal.Mapeo;

#endregion

namespace PetCenter.Referencias.Inyeccion
{
    /// <summary>
    /// Contenedor de Contratos y Implementacion
    /// </summary>
    public sealed class ContenedorInyeccion
    {
        #region BASE

        /// <summary>
        /// Flujo base
        /// </summary>
        /// <param name="container">container</param>
        public static void ObtenerRegistros(IUnityContainer container)
        {
            RegistroBase(container);

            RegistroRepositorios(container);

            RegistroServicios(container);
           
        }

        /// <summary>
        /// RegistroBase
        /// </summary>
        /// <param name="container">container</param>
        private static void RegistroBase(IUnityContainer container)
        {
            //BASE
            container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());//Singleton
            container.RegisterType<IModeloReferenciaUnidadDeTrabajo, ModeloReferenciaUnidadDeTrabajo>(new CicloVidaPorPeticion(), new InjectionConstructor());
        }

        #endregion

        #region REPOSITORIO

        /// <summary>
        /// RegistroRepositorios
        /// </summary>
        /// <param name="container">container</param>
        private static void RegistroRepositorios(IUnityContainer container)
        {
            container.RegisterType<IMonedaRepositorio, MonedaRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IBancoRepositorio, BancoRepositorio>(new TransientLifetimeManager());
            container.RegisterType<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>(new TransientLifetimeManager());
            container.RegisterType<ISolicitudRepositorio, SolicitudRepositorio>(new TransientLifetimeManager());
        }

        #endregion

        #region SERVICIO

        /// <summary>
        /// RegistroServicios
        /// </summary>
        /// <param name="container">container</param>
        private static void RegistroServicios(IUnityContainer container)
        {
            container.RegisterType<IMonedaServicio, MonedaServicio>(new TransientLifetimeManager());
            container.RegisterType<IBancoServicio, BancoServicio>(new TransientLifetimeManager());
            container.RegisterType<ITipoDocumentoServicio, TipoDocumentoServicio>(new TransientLifetimeManager());
            container.RegisterType<ISolicitudServicio, SolicitudServicio>(new TransientLifetimeManager());
        }

        #endregion

    }
}