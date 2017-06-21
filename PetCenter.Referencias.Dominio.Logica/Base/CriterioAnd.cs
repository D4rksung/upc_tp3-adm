using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Base
{
    public sealed class CriterioAnd<T> : CriterioElementos<T> where T : class
    {
        #region VARIABLES

        private ICriterio<T> _criterioIzquierda = null;
        private ICriterio<T> _criterioDerecha = null;

        #endregion

        #region CONSTRUCTOR

        public CriterioAnd(ICriterio<T> ladoIzquierda, ICriterio<T> ladoDerecha)
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
            Expression<Func<T, bool>> izquierda = _criterioIzquierda.SatisfacePara();
            Expression<Func<T, bool>> derecha = _criterioDerecha.SatisfacePara();

            return (izquierda.And(derecha));

        }

        #endregion
    }
}
