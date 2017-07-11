using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Referencia;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Referencia
{
    public class ReferenciaRepositorio : Repositorio<GCR_SolicitudRef>, IReferenciaRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public ReferenciaRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public PaginadoVob<ReferenciaVob> Paginado(ICriterio<ReferenciaVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from sol in set.GCR_SolicitudRef
                            select new ReferenciaVob
                            {
                                NroSolicitudRef = sol.NroSolicitudRef,
                                NroConvenio = sol.NroConvenio,
                                IdMascota = sol.IdMascota,
                                FechaSolicitudRef = sol.FechaSolicitudRef,
                                Diagnostico = sol.Diagnostico,
                                FechaTraslado = sol.FechaTraslado,
                                Estado = sol.Estado,
                                Anamnesis = sol.Anamnesis,
                                ExamenFisico = sol.ExamenFisico,
                                ExamenAuxiliar = sol.ExamenAuxiliar,
                                NombreRefiere = sol.NombreRefiere,
                                NroRuc = sol.GCR_Convenio.GCP_Cliente.GCP_PersonaJuridica.RUC,
                                RazonSocial = sol.GCR_Convenio.GCP_Cliente.GCP_PersonaJuridica.RazonSocial,
                                NombreMascota = sol.GCP_Mascota.NombreMascota
                            });
            return ListarPorCriterio(consulta, criterio, indicePagina, tamanioPagina, orden, ordenDir);//El ordern y la direccion puede ir como parametros si en el presentación se ordenan 
        }

        public ReferenciaVob Buscar(int idReferencia)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from sol in set.GCR_SolicitudRef
                            where sol.NroSolicitudRef == idReferencia
                            select new ReferenciaVob
                            {
                                NroSolicitudRef = sol.NroSolicitudRef,
                                NroConvenio = sol.NroConvenio,
                                IdMascota = sol.IdMascota,
                                FechaSolicitudRef = sol.FechaSolicitudRef,
                                Diagnostico = sol.Diagnostico,
                                FechaTraslado = sol.FechaTraslado,
                                Estado = sol.Estado,
                                Anamnesis = sol.Anamnesis,
                                ExamenFisico = sol.ExamenFisico,
                                ExamenAuxiliar = sol.ExamenAuxiliar,
                                NombreRefiere = sol.NombreRefiere,
                                NroRuc = sol.GCR_Convenio.GCP_Cliente.GCP_PersonaJuridica.RUC,
                                RazonSocial = sol.GCR_Convenio.GCP_Cliente.GCP_PersonaJuridica.RazonSocial,
                                NombreMascota = sol.GCP_Mascota.NombreMascota,
                                IdCliente = sol.GCR_Convenio.IdCliente.Value
                            });
            return consulta.FirstOrDefault();
        }

        public IEnumerable<EspeciesCantidadVob> ObtenerEspecies()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from sol in set.GCR_SolicitudRef
                            let g = new
                            {
                                IdEspecie = sol.GCP_Mascota.GCP_Raza.CodigoEspecie,
                                NombreEspecie = sol.GCP_Mascota.GCP_Raza.GCP_Especie.DescripcionEspecie
                            }
                            group sol by g into p
                            select new EspeciesCantidadVob
                            {
                                Cantidad = p.Count(),
                                NombreEspecie = p.Key.NombreEspecie
                            });
            return consulta.AsEnumerable();
        }

        public IEnumerable<RazasCantidadVob> ObtenerRaza(int idEspecie)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from sol in set.GCR_SolicitudRef
                            where sol.GCP_Mascota.GCP_Raza.GCP_Especie.CodigoEspecie == idEspecie
                            let g = new
                            {
                                IdRaza = sol.GCP_Mascota.GCP_Raza.CodigoRaza,
                                NombreRaza = sol.GCP_Mascota.GCP_Raza.NombreRaza
                            }
                            group sol by g into p
                            select new RazasCantidadVob
                            {
                                Cantidad = p.Count(),
                                NombreRaza = p.Key.NombreRaza
                            });
            return consulta.AsEnumerable();

        }      

    }
}
