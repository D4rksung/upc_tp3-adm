using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Atencion;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Atencion
{
    public class AtencionRepositorio : Repositorio<GCR_Atenciones>, IAtencionRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public AtencionRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public PaginadoVob<AtencionVob> Paginado(ICriterio<AtencionVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from ate in set.GCR_Atenciones
                            let g = new
                            {
                                IdCliente = ate.GCR_SolicitudRef_Servicio.GCR_SolicitudRef.GCR_Convenio.IdCliente,
                                RazonSocial = ate.GCR_SolicitudRef_Servicio.GCR_SolicitudRef.GCR_Convenio.GCP_Cliente.GCP_PersonaJuridica.RazonSocial,
                                NroLiquidacion = !ate.NroLiquidacion.HasValue ? 0 : ate.NroLiquidacion.Value,
                                Anio = ate.FechaAtencion.Value.Year.ToString(),
                                Mes = ate.FechaAtencion.Value.Month.ToString(),
                                NroSolicitudRef = ate.NroSolicitudRef
                            }
                            group ate by g into p
                            select new AtencionVob
                            {
                                IdCliente = p.Key.IdCliente.Value,
                                RazonSocial = p.Key.RazonSocial,
                                NroAtenciones = p.Count(),
                                ValorBruto = p.Sum(x => x.ValorBruto),
                                Descuento = p.Sum(x => x.ValorBruto) - p.Sum(x => x.ValorNeto),
                                ValorNeto = p.Sum(x => x.ValorNeto),
                                NroLiquidacion = p.Key.NroLiquidacion,
                                Anio = p.Key.Anio,
                                Mes = p.Key.Mes,
                                NroSolicitudRef = p.Key.NroSolicitudRef
                            });
            return ListarPorCriterio(consulta, criterio, indicePagina, tamanioPagina, orden, ordenDir);//El ordern y la direccion puede ir como parametros si en el presentación se ordenan 
        }

        public AtencionVob BuscarPorClienteReferencia(int idCliente, int idReferencia)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from ate in set.GCR_Atenciones
                            where ate.NroSolicitudRef == idReferencia && ate.GCR_SolicitudRef_Servicio.GCR_SolicitudRef.GCR_Convenio.IdCliente == idCliente
                            let g = new
                            {
                                IdCliente = ate.GCR_SolicitudRef_Servicio.GCR_SolicitudRef.GCR_Convenio.IdCliente,
                                RazonSocial = ate.GCR_SolicitudRef_Servicio.GCR_SolicitudRef.GCR_Convenio.GCP_Cliente.GCP_PersonaJuridica.RazonSocial,
                                NroLiquidacion = !ate.NroLiquidacion.HasValue ? 0 : ate.NroLiquidacion.Value,
                                Anio = ate.FechaAtencion.Value.Year.ToString(),
                                Mes = ate.FechaAtencion.Value.Month.ToString(),
                                NroSolicitudRef = ate.NroSolicitudRef
                            }
                            group ate by g into p
                            select new AtencionVob
                            {
                                IdCliente = p.Key.IdCliente.Value,
                                RazonSocial = p.Key.RazonSocial,
                                NroLiquidacion = p.Key.NroLiquidacion,
                                Anio = p.Key.Anio,
                                Mes = p.Key.Mes,
                                NroSolicitudRef = p.Key.NroSolicitudRef
                            });

            return consulta.FirstOrDefault();
        }

        public IEnumerable<AtencionVob> ListarPorClienteReferencia(int idCliente, int idReferencia)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from ate in set.GCR_Atenciones
                            where ate.NroSolicitudRef == idReferencia && ate.GCR_SolicitudRef_Servicio.GCR_SolicitudRef.GCR_Convenio.IdCliente == idCliente
                            select new AtencionVob
                            {
                                IdAtencion = ate.IdAtencion,
                                NroSolicitudRef = ate.NroSolicitudRef,
                                IdServicio = ate.IdServicio,
                                NombreServicio = ate.GCR_SolicitudRef_Servicio.GCR_ConvenioServicio.GG_Servicio.nombre,
                                NroConvenio = ate.NroConvenio,
                                Cantidad = ate.Cantidad,
                                TarifaBase = ate.TarifaBase,
                                ValorBruto = ate.ValorBruto,
                                Descuento = ate.Descuento,
                                ValorNeto = ate.ValorNeto,
                                NroLiquidacion = ate.NroLiquidacion,
                                Resultado = ate.Resultado,
                                ResultadoTitulo = ate.ResultadoTitulo,
                                ResultadoObjeto = ate.ResultadoObjeto,
                                Estado = ate.Estado,
                                FechaAtencion = ate.FechaAtencion
                            });
            return consulta.AsEnumerable();
        }

        public AtencionVob BuscarPorRefServConv(int idReferencia, int idServicio, int idConvenio)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from ate in set.GCR_Atenciones
                            where ate.NroSolicitudRef == idReferencia && ate.IdServicio == idServicio && ate.NroConvenio == idConvenio
                            select new AtencionVob
                            {
                                IdAtencion = ate.IdAtencion,
                                NroSolicitudRef = ate.NroSolicitudRef,
                                IdServicio = ate.IdServicio,
                                NroConvenio = ate.NroConvenio,
                                Cantidad = ate.Cantidad,
                                TarifaBase = ate.TarifaBase,
                                ValorBruto = ate.ValorBruto,
                                Descuento = ate.Descuento,
                                ValorNeto = ate.ValorNeto,
                                NroLiquidacion = ate.NroLiquidacion,
                                Resultado = ate.Resultado,
                                ResultadoTitulo = ate.ResultadoTitulo,
                                ResultadoObjeto = ate.ResultadoObjeto,
                                Estado = ate.Estado,
                                FechaAtencion = ate.FechaAtencion
                            });
            return consulta.FirstOrDefault();
        }

        public IEnumerable<AtencionVob> ListarPorClientePeriodoMes(int idCliente, string anio, string mes)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from ate in set.GCR_Atenciones
                            where ate.GCR_SolicitudRef_Servicio.GCR_SolicitudRef.GCR_Convenio.IdCliente == idCliente
                            && ate.FechaAtencion.Value.Year.ToString() == anio
                            && ate.FechaAtencion.Value.Month.ToString() == mes
                            && !ate.NroLiquidacion.HasValue
                            select new AtencionVob
                            {
                                IdAtencion = ate.IdAtencion,
                                NroSolicitudRef = ate.NroSolicitudRef,
                                IdServicio = ate.IdServicio,
                                NombreServicio = ate.GCR_SolicitudRef_Servicio.GCR_ConvenioServicio.GG_Servicio.nombre,
                                NroConvenio = ate.NroConvenio,
                                Cantidad = ate.Cantidad,
                                TarifaBase = ate.TarifaBase,
                                ValorBruto = ate.ValorBruto,
                                Descuento = ate.Descuento,
                                ValorNeto = ate.ValorNeto,
                                NroLiquidacion = ate.NroLiquidacion,
                                Resultado = ate.Resultado,
                                ResultadoTitulo = ate.ResultadoTitulo,
                                ResultadoObjeto = ate.ResultadoObjeto,
                                Estado = ate.Estado,
                                FechaAtencion = ate.FechaAtencion
                            });
            return consulta.AsEnumerable();
        }

        public IEnumerable<AtencionTotalMesVob> ObtenerTotalAtencionesPorMes()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from ate in set.GCR_Atenciones
                            let g = new
                            {
                                Anio = ate.FechaAtencion.Value.Year,
                                Mes = ate.FechaAtencion.Value.Month
                            }
                            group ate by g into p
                            select new AtencionTotalMesVob
                            {
                                Anio = p.Key.Anio,
                                Mes = p.Key.Mes,
                                Cantidad = p.Count(),
                                Total = p.Sum(q => q.ValorNeto.Value)
                            });
            return consulta.AsEnumerable();
        }

        public IEnumerable<ServiciosPorAtencionVob> ObtenerServiciosPorAtencion()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from ate in set.GCR_Atenciones
                            let g = new
                            {
                                IdServicio = ate.IdServicio,
                                NombreServicio = ate.GCR_SolicitudRef_Servicio.GCR_ConvenioServicio.GG_Servicio.nombre
                            }
                            group ate by g into p
                            select new ServiciosPorAtencionVob
                            {
                                Cantidad = p.Count(),
                                NombreServicio = p.Key.NombreServicio
                            });

            return consulta.AsEnumerable();
        }
    }
}