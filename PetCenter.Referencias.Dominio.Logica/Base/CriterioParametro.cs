using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Base
{

    public sealed class CriterioParametro : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

      
        public CriterioParametro(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
       
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new CriterioParametro(map).Visit(exp);
        }
      
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }

            return base.VisitParameter(p);
        }

    }
}
