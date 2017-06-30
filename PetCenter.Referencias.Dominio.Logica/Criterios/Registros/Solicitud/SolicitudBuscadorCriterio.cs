using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud;
using PetCenter.Referencias.Transversal.Enumeraciones;
using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Solicitud
{
    public class SolicitudBuscadorCriterio : Criterio<SolicitudVob>
    {
        #region VARIABLES

        /// <summary>
        /// _area
        /// </summary>
        private readonly SolicitudVob _solicitud;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="solicitud">AreaVob</param>
        public SolicitudBuscadorCriterio(SolicitudVob solicitud)
        {
            _solicitud = solicitud;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        /// <summary>
        /// SatisfacePara
        /// </summary>
        /// <returns>TupaVob</returns>
        public override Expression<Func<SolicitudVob, bool>> SatisfacePara()
        {
            string todos = ((int)PrimerValorEnum.Seleccione).ToString();
            Criterio<SolicitudVob> criterio = new CriterioTrue<SolicitudVob>();

            #region Filtro            

            //Nro de Ruc
            if (!string.IsNullOrEmpty(_solicitud.NroRUC))
                criterio &= new CriterioDirect<SolicitudVob>(p => p.NroRUC.Contains(_solicitud.NroRUC));

            //Razon Social
            if (!string.IsNullOrEmpty(_solicitud.RazonSocial))
                criterio &= new CriterioDirect<SolicitudVob>(p => p.RazonSocial.Contains(_solicitud.RazonSocial));

            //Fechas Desde
            criterio &= new CriterioDirect<SolicitudVob>(p => p.FechaSolicitud >= _solicitud.FechaSolicitudInicio);

            //Fechas Hasta
            criterio &= new CriterioDirect<SolicitudVob>(p => p.FechaSolicitud <= _solicitud.FechaSolicitudHasta);

            #endregion

            return criterio.SatisfacePara();
        }

        #endregion
    }
}
