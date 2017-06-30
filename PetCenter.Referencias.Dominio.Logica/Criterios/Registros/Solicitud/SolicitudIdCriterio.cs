using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud;
using System;
using System.Linq.Expressions;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Solicitud
{
    public class SolicitudIdCriterio : Criterio<e.GCR_Solicitud_Convenio>
    {
        #region VARIABLES

        /// <summary>
        /// _area
        /// </summary>
        private readonly int _idSolicitud;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="solicitud">AreaVob</param>
        public SolicitudIdCriterio(int idSolicitud)
        {
            _idSolicitud = idSolicitud;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        /// <summary>
        /// Expresión de satisfacción
        /// </summary>
        /// <returns>Expresion de funcion de especificación de plan</returns>
        public override Expression<Func<e.GCR_Solicitud_Convenio, bool>> SatisfacePara()
        {
            return t => t.NroSolicitud == _idSolicitud;
        }

        #endregion
    }
}
