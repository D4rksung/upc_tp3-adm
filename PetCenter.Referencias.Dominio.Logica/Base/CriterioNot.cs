using System;
using System.Linq.Expressions;
using System.Linq;

namespace PetCenter.Referencias.Dominio.Logica.Base
{

    public sealed class CriterioNot<TEntidad> : Criterio<TEntidad> where TEntidad : class
    {
        #region VARAIBLES

        Expression<Func<TEntidad, bool>> _criterioOriginal;

        #endregion

        #region CONSTRUCTOR

        public CriterioNot(ICriterio<TEntidad> criterioOriginal)
        {

            if (criterioOriginal == (ICriterio<TEntidad>)null)
                throw new ArgumentNullException("criterioOriginal");

            _criterioOriginal = criterioOriginal.SatisfacePara();
        }

        public CriterioNot(Expression<Func<TEntidad, bool>> criterioOriginal)
        {
            if (criterioOriginal == (Expression<Func<TEntidad, bool>>)null)
                throw new ArgumentNullException("criterioOriginal");

            _criterioOriginal = criterioOriginal;
        }

        #endregion

        #region MÉTODOS

        public override Expression<Func<TEntidad, bool>> SatisfacePara()
        {
            return Expression.Lambda<Func<TEntidad, bool>>(Expression.Not(_criterioOriginal.Body), _criterioOriginal.Parameters.Single());
        }

        #endregion
    }
}
