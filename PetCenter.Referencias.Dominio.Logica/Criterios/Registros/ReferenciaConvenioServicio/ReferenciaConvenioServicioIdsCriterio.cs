using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Registros.ReferenciaConvenioServicio
{
    public class ReferenciaConvenioServicioIdsCriterio : Criterio<GCR_SolicitudRef_Servicio>
    {
        #region VARIABLES
        private readonly int _idReferencia;
        private readonly int _idServicio;
        private readonly int _idConvenio;
        #endregion

        #region CONSTRUCTORES
        public ReferenciaConvenioServicioIdsCriterio(int idReferencia, int idServicio, int idConvenio)
        {
            _idReferencia = idReferencia;
            _idServicio = idServicio;
            _idConvenio = idConvenio;
        }
        #endregion

        #region MÉTODOS REEMPLAZADOS

        public override Expression<Func<GCR_SolicitudRef_Servicio, bool>> SatisfacePara()
        {
            return t => t.NroSolicitudRef == _idReferencia && t.IdServicio == _idServicio && t.NroConvenio == _idConvenio;
        }

        #endregion
    }
}