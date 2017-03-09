using System.Linq.Expressions;

namespace Evol.Util.Expressions
{
    public class ExpressionParameterReplacer<T> : ExpressionVisitor
    {
        public ExpressionParameterReplacer(ParameterExpression paramExpr)
        {
            ParameterExpression = paramExpr;
        }

        public ParameterExpression ParameterExpression { get; private set; }

        public Expression Repalce(Expression expr)
        {
            return Visit(expr);
        }

        protected override Expression VisitParameter(ParameterExpression paramExpr)
        {
            return ParameterExpression;
        }

    }
}
