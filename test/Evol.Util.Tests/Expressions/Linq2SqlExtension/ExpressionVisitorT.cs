using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TestLINQ
{
	/// <summary>
	/// This class visits every Parameter expression in an expression tree and calls a delegate
	/// to optionally replace the parameter.  This is useful where two expression trees need to
	/// be merged (and they don't share the same ParameterExpressions).
	/// </summary>
	public class ExpressionVisitor<T> : ExpressionVisitor where T : Expression
	{
		Func<T, Expression> visitor;

		public ExpressionVisitor( Func<T, Expression> visitor )
		{
			this.visitor = visitor;
		}

		public static Expression Visit(
			Expression exp,
			Func<T, Expression> visitor )
		{
			return new ExpressionVisitor<T>( visitor ).Visit( exp );
		}

		public static Expression<TDelegate> Visit<TDelegate>(
			Expression<TDelegate> exp,
			Func<T, Expression> visitor )
		{
			return (Expression<TDelegate>)new ExpressionVisitor<T>( visitor ).Visit( exp );
		}

		protected override Expression Visit( Expression exp )
		{
			if ( exp is T && visitor != null ) exp = visitor( (T)exp );

			return base.Visit( exp );
		}
	}
}
