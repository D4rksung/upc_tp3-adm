using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Base
{
    public sealed class CriterioOr<T> : CriterioElementos<T> where T : class
    {
        #region VARIABLES

        private ICriterio<T> _criterioIzquierda = null;
        private ICriterio<T> _criterioDerecha = null;

        #endregion

        #region CONSTRUCTOR

        public CriterioOr(ICriterio<T> ladoIzquierda, ICriterio<T> ladoDerecha)
        {
            if (ladoIzquierda == (ICriterio<T>)null)
                throw new ArgumentNullException("ladoIzquierda");

            if (ladoDerecha == (ICriterio<T>)null)
                throw new ArgumentNullException("ladoDerecha");

            _criterioIzquierda = ladoIzquierda;
            _criterioDerecha = ladoDerecha;
        }

        #endregion

        #region MÉTODOS

        public override ICriterio<T> CriterioLadoIzquierda
        {
            get { return _criterioIzquierda; }
        }

        public override ICriterio<T> CriterioLadoDerecha
        {
            get { return _criterioDerecha; }
        }

        public override Expression<Func<T, bool>> SatisfacePara()
        {
            Expression<Func<T, bool>> left = _criterioIzquierda.SatisfacePara();
            Expression<Func<T, bool>> right = _criterioDerecha.SatisfacePara();

            return (left.Or(right));
        }

        #endregion
    }
}
