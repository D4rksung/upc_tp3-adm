using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ContraReferencia;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.ContraReferencia
{
    public class ContraReferenciaRepositorio : Repositorio<GCR_ContraReferencia>, IContraReferenciaRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public ContraReferenciaRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public ContraReferenciaVob BuscarPorRefencia(int idReferencia)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from b in set.GCR_ContraReferencia
                            where b.NroSolicitudRef == idReferencia
                            select new ContraReferenciaVob
                            {
                                NroSolicitudRef = b.NroSolicitudRef,
                                FechaCierre = b.FechaCierre,
                                FechaEntrega = b.FechaEntrega,
                                Observaciones = b.Observaciones,
                                Resultados = b.Resultados,
                                NroContraReferencia = b.NroContraReferencia,
                                IdVeterinario = b.IdVeterinario,
                                NomVeterinario = b.GCR_Veterinario.NomVeterinario
                            });
            return consulta.FirstOrDefault();
        }
    }
}
