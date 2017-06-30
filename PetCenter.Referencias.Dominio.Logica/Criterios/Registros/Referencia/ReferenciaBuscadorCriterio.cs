using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Referencia;
using PetCenter.Referencias.Transversal.Enumeraciones;
using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Referencia
{
    public class ReferenciaBuscadorCriterio : Criterio<ReferenciaVob>
    {
        #region VARIABLES

        /// <summary>
        /// _area
        /// </summary>
        private readonly ReferenciaVob _referencia;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="referencia">AreaVob</param>
        public ReferenciaBuscadorCriterio(ReferenciaVob referencia)
        {
            _referencia = referencia;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        /// <summary>
        /// SatisfacePara
        /// </summary>
        /// <returns>TupaVob</returns>
        public override Expression<Func<ReferenciaVob, bool>> SatisfacePara()
        {
            string todos = ((int)PrimerValorEnum.Seleccione).ToString();
            Criterio<ReferenciaVob> criterio = new CriterioTrue<ReferenciaVob>();

            #region Filtro            

            //Nro de Referencia
            if (_referencia.NroSolicitudRef != 0)
                criterio &= new CriterioDirect<ReferenciaVob>(p => p.NroSolicitudRef == _referencia.NroSolicitudRef);

            //Ruc
            if (!string.IsNullOrEmpty(_referencia.NroRuc))
                criterio &= new CriterioDirect<ReferenciaVob>(p => p.NroRuc.Contains(_referencia.NroRuc));

            //Razon Social
            if (!string.IsNullOrEmpty(_referencia.RazonSocial))
                criterio &= new CriterioDirect<ReferenciaVob>(p => p.RazonSocial.Contains(_referencia.RazonSocial));

            //Fechas Desde
            criterio &= new CriterioDirect<ReferenciaVob>(p => p.FechaSolicitudRef >= _referencia.FechaSolicitudInicio);

            //Fechas Hasta
            criterio &= new CriterioDirect<ReferenciaVob>(p => p.FechaSolicitudRef <= _referencia.FechaSolicitudFin);

            #endregion

            return criterio.SatisfacePara();
        }

        #endregion
    }
}
