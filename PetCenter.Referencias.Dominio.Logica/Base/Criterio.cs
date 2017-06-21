using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Base
{
    /// <summary>
    /// Clase que implementa métodos para el uso de criterios.
    /// </summary>
    /// <typeparam name="TEntidad"></typeparam>
    public abstract class Criterio<TEntidad> : ICriterio<TEntidad> where TEntidad : class
    {
        #region IMPLEMENTADOS

        /// <summary>
        /// Método principal de satisfación del criterio.
        /// </summary>
        /// <returns>Expresión de evaluación</returns>
        public abstract Expression<Func<TEntidad, bool>> SatisfacePara();

        /// <summary>
        /// Método altenativoo de satisfacción de criterio
        /// </summary>
        /// <returns>Expresión de evaluación</returns>
        public virtual Expression<Func<TEntidad, bool>> SatisfacerParaOtro()
        {
            return null;
        }

        #endregion

        #region OPERACIONES

        public static Criterio<TEntidad> operator &(Criterio<TEntidad> criterioLadoIzquierda, Criterio<TEntidad> criterioLadoDerecha)
        {
            return new CriterioAnd<TEntidad>(criterioLadoIzquierda, criterioLadoDerecha);
        }

        public static Criterio<TEntidad> operator |(Criterio<TEntidad> criterioLadoIzquierda, Criterio<TEntidad> criterioLadoDerecha)
        {
            return new CriterioOr<TEntidad>(criterioLadoIzquierda, criterioLadoDerecha);
        }

        public static Criterio<TEntidad> operator !(Criterio<TEntidad> Criterio)
        {
            return new CriterioNot<TEntidad>(Criterio);
        }

        public static bool operator false(Criterio<TEntidad> Criterio)
        {
            return false;
        }

        public static bool operator true(Criterio<TEntidad> Criterio)
        {
            return true;
        }

        #endregion
    }
}
