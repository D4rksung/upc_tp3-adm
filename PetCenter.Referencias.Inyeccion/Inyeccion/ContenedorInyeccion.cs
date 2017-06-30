#region ESPACIOS DE NOMBRES

using Microsoft.Practices.Unity;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Banco;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.ConvenioServicio;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.General;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Veterinario;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.ContraReferencia;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Convenio;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Liquidacion;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Referencia;
using PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Solicitud;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Banco;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Servicio;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Veterinario;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Atencion;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Banco;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Cliente;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.ContraReferencia;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Convenio;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.ConvenioDescuento;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.ConvenioServicio;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.DocumentoRechazo;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Liquidacion;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Mascota;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Moneda;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.PersonaJuridica;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Referencia;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.ReferenciaConvenioServicio;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Servicio;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Solicitud;
using PetCenter.Referencias.Infraestructura.Data.Repositorios.Veterinario;
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
            //container.RegisterType<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>(new TransientLifetimeManager());
            container.RegisterType<ISolicitudRepositorio, SolicitudRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IConvenioRepositorio, ConvenioRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IConvenioServicioRepositorio, ConvenioServicioRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IConvenioDescuentoRepositorio, ConvenioDescuentoRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IServicioRepositorio, ServicioRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IMascotaRepositorio, MascotaRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IDocumentoRechazoRepositorio, DocumentoRechazoRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IClienteRepositorio, ClienteRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IPersonaJuridicaRepositorio, PersonaJuridicaRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IReferenciaRepositorio, ReferenciaRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IAtencionRepositorio, AtencionRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IReferenciaConvenioServicioRepositorio, ReferenciaConvenioServicioRepositorio>(new TransientLifetimeManager());
            container.RegisterType<ILiquidacionRepositorio, LiquidacionRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IContraReferenciaRepositorio, ContraReferenciaRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IVeterinarioRepositorio, VeterinarioRepositorio>(new TransientLifetimeManager());
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
            container.RegisterType<IGeneralServicio, GeneralServicio>(new TransientLifetimeManager());
            container.RegisterType<ISolicitudServicio, SolicitudServicio>(new TransientLifetimeManager());
            container.RegisterType<IConvenioServicio, ConvenioServicio>(new TransientLifetimeManager());
            container.RegisterType<IServicioServicio, ServicioServicio>(new TransientLifetimeManager());
            container.RegisterType<IMascotaServicio, MascotaServicio>(new TransientLifetimeManager());
            container.RegisterType<IConvenioServicioServicio, ConvenioServicioServicio>(new TransientLifetimeManager());
            container.RegisterType<IReferenciaServicio, ReferenciaServicio>(new TransientLifetimeManager());
            container.RegisterType<IAtencionServicio, AtencionServicio>(new TransientLifetimeManager());
            container.RegisterType<ILiquidacionServicio, LiquidacionServicio>(new TransientLifetimeManager());
            container.RegisterType<IContraReferenciaServicio, ContraReferenciaServicio>(new TransientLifetimeManager());
            container.RegisterType<IVeterinarioServicio, VeterinarioServicio>(new TransientLifetimeManager());
        }

        #endregion

    }
}