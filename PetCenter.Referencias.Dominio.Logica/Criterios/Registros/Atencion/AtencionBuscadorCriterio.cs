using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Atencion;
using PetCenter.Referencias.Transversal.Enumeraciones;
using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Atencion
{
    public class AtencionBuscadorCriterio : Criterio<AtencionVob>
    {
        #region VARIABLES

        /// <summary>
        /// _area
        /// </summary>
        private readonly AtencionVob _atencion;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="atencion">AreaVob</param>
        public AtencionBuscadorCriterio(AtencionVob atencion)
        {
            _atencion = atencion;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        /// <summary>
        /// SatisfacePara
        /// </summary>
        /// <returns>TupaVob</returns>
        public override Expression<Func<AtencionVob, bool>> SatisfacePara()
        {
            string todos = ((int)PrimerValorEnum.Seleccione).ToString();
            Criterio<AtencionVob> criterio = new CriterioTrue<AtencionVob>();

            #region Filtro            

            //Anio
            criterio &= new CriterioDirect<AtencionVob>(p => p.Anio == _atencion.Anio);

            //Mes
            criterio &= new CriterioDirect<AtencionVob>(p => p.Mes == _atencion.Mes);
            
            #endregion

            return criterio.SatisfacePara();
        }

        #endregion
    }
}
