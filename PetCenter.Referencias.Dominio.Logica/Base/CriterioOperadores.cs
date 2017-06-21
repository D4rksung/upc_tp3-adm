using System;
using System.Linq.Expressions;
using System.Linq;

namespace PetCenter.Referencias.Dominio.Logica.Base
{

    public static class CriterioOperadores
    {
        
        public static Expression<T> Componer<T>(this Expression<T> primero, Expression<T> segundo, Func<Expression, Expression, Expression> union)
        {
            var map = primero.Parameters.Select((f, i) => new { f, s = segundo.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            var secondBody = CriterioParametro.ReplaceParameters(map, segundo.Body);
            return Expression.Lambda<T>(union(primero.Body, secondBody), primero.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> primero, Expression<Func<T, bool>> segundo)
        {
            return primero.Componer(segundo, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> primero, Expression<Func<T, bool>> segundo)
        {
            return primero.Componer(segundo, Expression.Or);
        }

    }
}
