using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using PetCenter.Referencias.Transversal.Util;
using System.Linq;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Solicitud
{
    public class SolicitudRepositorio : Repositorio<e.GCR_Solicitud_Convenio>, ISolicitudRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public SolicitudRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        #region PAGINACION

        /// <summary>
        /// Paginado
        /// </summary>
        /// <param name="criterio">ICriterio TupaVob</param>
        /// <param name="indicePagina">int</param>
        /// <param name="tamanioPagina">int</param>
        /// <param name="orden">string</param>
        /// <param name="ordenDir">string</param>
        /// <returns>PaginadoVob TupaVob</returns>
        public PaginadoVob<SolicitudVob> Paginado(ICriterio<SolicitudVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from sol in set.GCR_Solicitud_Convenio
                                //where sol.Are_cEstado == EstadoRegistro.Activo
                            select new SolicitudVob
                            {
                                NroSolicitud = sol.NroSolicitud,
                                FechaSolicitud = sol.FechaSolicitud.Value,
                                NroRUC = sol.NroRUC,
                                RazonSocial = sol.RazonSocial,
                                ImporteGarantia = sol.ImporteGarantia,
                                NombreRep = sol.NombreRep,
                                Estado = sol.Estado,
                                DesEstado = sol.Estado == "1" ? "Emitido" :
                                            sol.Estado == "2" ? "Aceptado" :
                                            sol.Estado == "3" ? "Rechazado" :
                                            sol.Estado == "4" ? "Activado" :
                                            sol.Estado == "0" ? "Anulado" : "",
                                //NroSolicitudFormato = StringExtensions.GenerarCodigo(sol.NroSolicitud)
                            });
            return ListarPorCriterio(consulta, criterio, indicePagina, tamanioPagina, orden, ordenDir);//El ordern y la direccion puede ir como parametros si en el presentación se ordenan 
        }

        #endregion

        public SolicitudVob Buscar(int idSolicitud)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from sol in set.GCR_Solicitud_Convenio
                            where sol.NroSolicitud == idSolicitud
                            select new SolicitudVob
                            {
                                NroSolicitud = sol.NroSolicitud,
                                FechaSolicitud = sol.FechaSolicitud.Value,
                                NroRUC = sol.NroRUC,
                                Direccion = sol.Direccion,
                                Referencia = sol.Referencia,
                                RazonSocial = sol.RazonSocial,
                                Telefono = sol.Telefono,
                                Web = sol.Web,
                                TpoDocRep = sol.TpoDocRep,
                                NroDocRep = sol.NroDocRep,
                                NombreRep = sol.NombreRep,
                                CorreoRep = sol.CorreoRep,
                                TelefonoRep = sol.TelefonoRep,
                                IdBanco = sol.IdBanco.Value,
                                IdMoneda = sol.IdMoneda.Value,
                                ImporteGarantia = sol.ImporteGarantia,
                                Nrogarantia = sol.Nrogarantia,
                                FechaVencimientoG = sol.FechaVencimientoG.Value,
                                DocReciboObjeto = sol.DocReciboObjeto,
                                DocReciboTitulo = sol.DocReciboTitulo,
                                DocColegiaturaObjeto = sol.DocColegiaturaObjeto,
                                DocColegiaturaTitulo = sol.DocColegiaturaTitulo,
                                DocSunatObjeto = sol.DocSunatObjeto,
                                DocSunatTitulo = sol.DocSunatTitulo,
                                DocLicenciaObjeto = sol.DocLicenciaObjeto,
                                DocLicenciaTitulo = sol.DocLicenciaTitulo,
                                DocCentralObjeto = sol.DocCentralObjeto,
                                DocCentralTitulo = sol.DocCentralTitulo,
                                Estado = sol.Estado,
                                DesEstado = sol.Estado == "1" ? "Emitido" :
                                            sol.Estado == "2" ? "Aceptado" :
                                            sol.Estado == "3" ? "Rechazado" :
                                            sol.Estado == "4" ? "Activado" :
                                            sol.Estado == "0" ? "Anulado" : "",
                                //NroSolicitudFormato = StringExtensions.GenerarCodigo(sol.NroSolicitud)
                            });
            return consulta.FirstOrDefault();
        }
    }
}
