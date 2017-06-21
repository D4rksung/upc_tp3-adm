using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Base
{
    /// <summary>
    /// Criterio True
    /// </summary>
    /// <typeparam name="TEntidad"></typeparam>
    public sealed class CriterioTrue<TEntidad>: Criterio<TEntidad> where TEntidad : class
    {
        #region 

        /// <summary>
        /// Expresión de satisfacción del criterio
        /// </summary>
        /// <returns>Siempre True</returns>
        public override Expression<Func<TEntidad, bool>> SatisfacePara()
        {
            bool result = true;

            Expression<Func<TEntidad, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }

}
