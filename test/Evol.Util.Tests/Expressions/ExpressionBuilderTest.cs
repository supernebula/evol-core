using System;
using System.Linq.Expressions;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nebula.Utilities.Test.Expressions
{
    [TestClass]
    public class ExpressionBuilderTest
    {
        public class Product
        {
            public Guid Id { get; set; }
            public string Titile { get; set; }

            public double Price { get; set; }

            public DateTime CreateDate { get; set; }
        }

        [TestMethod]
        public void DynamicExpressionTest()
        {
            var price1 = 1500.00;
            var name1 = "xiaomi";
            Expression<Func<Product, bool>> predicate1 = p => p.Price > price1;
            Expression<Func<Product, bool>> predicate2 = p => p.Titile.Contains(name1);

            var invokeExp2 = Expression.Invoke(predicate2, predicate2.Parameters);
            var query = Expression.Lambda<Func<Product, bool>>(Expression.Or(predicate1.Body, invokeExp2), predicate1.Parameters);

            TraceWriteExpression("Dynamic", query);
        }


        [TestMethod]
        public void ExpressionTest()
        {
            Expression<Func<Product, bool>> query = p => p.Price > 1500;

            var body = query.Body;
            var name = query.Name;
            var nodeType = query.NodeType;
            var parameters = query.Parameters;
            var returnType = query.ReturnType;
            var type = query.Type;

            TraceWriteExpression("Expression<Func<Product, bool>>:",query);

            TraceWriteExpression("query.Body:", query.Body);

            foreach (var ParameterExpression in query.Parameters)
            {
                TraceWriteExpression("query.Parameters:", ParameterExpression);
            }
        }

        private void TraceWriteExpression(string title, System.Linq.Expressions.LambdaExpression expression)
        {
            Trace.WriteLine("--------------------------> " + title);
            Trace.WriteLine(String.Format("Body = {0}", expression.Body));
            Trace.WriteLine(String.Format("Name = {0}", expression.Name));
            Trace.WriteLine(String.Format("NodeType = {0}", expression.NodeType));
            Trace.WriteLine(String.Format("Parameters = {0}", expression.Parameters));
            Trace.WriteLine(String.Format("ReturnType = {0}", expression.ReturnType));
            Trace.WriteLine(String.Format("Type = {0}", expression.Type));
        }


        private void TraceWriteExpression(string title, System.Linq.Expressions.ParameterExpression expression)
        {
            Trace.WriteLine("--------------------------> " + title);
            Trace.WriteLine(String.Format("Name = {0}", expression.Name));
            Trace.WriteLine(String.Format("NodeType = {0}", expression.NodeType));
            Trace.WriteLine(String.Format("Type = {0}", expression.Type));
        }

        private void TraceWriteExpression(string title, System.Linq.Expressions.Expression expression)
        {
            Trace.WriteLine("--------------------------> " + title);
            Trace.WriteLine(String.Format("NodeType = {0}", expression.NodeType));
            Trace.WriteLine(String.Format("Type = {0}", expression.Type));
        }
    }
}
