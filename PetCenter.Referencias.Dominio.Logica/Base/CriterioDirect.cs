using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Base
{
    public class CriterioDirect
    {
    }

    public sealed class CriterioDirect<TEntidad> : Criterio<TEntidad> where TEntidad : class
    {
        #region Members

        Expression<Func<TEntidad, bool>> _MatchingCriteria;

        #endregion

        #region Constructor

        public CriterioDirect(Expression<Func<TEntidad, bool>> matchingCriteria)
        {
            if (matchingCriteria == (Expression<Func<TEntidad, bool>>)null)
                throw new ArgumentNullException("matchingCriteria");

            _MatchingCriteria = matchingCriteria;
        }

        #endregion

        #region Override

        public override Expression<Func<TEntidad, bool>> SatisfacePara()
        {
            return _MatchingCriteria;
        }

        #endregion
    }

}
