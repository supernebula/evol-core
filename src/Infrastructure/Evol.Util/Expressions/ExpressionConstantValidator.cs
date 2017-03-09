using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Evol.Util.Expressions
{
    public class ExpressionConstantValidator : ExpressionVisitor
    {

        /// <summary>
        /// 常量有效性验证方法
        /// </summary>
        private Func<object, bool> ValidateFunc { get; set; }

        /// <summary>
        /// 所有常量
        /// </summary>
        public List<KeyValuePair<object, bool>> Constants { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="validateFunc"></param>
        public ExpressionConstantValidator(Func<object, bool> validateFunc)
        {
            ValidateFunc = validateFunc;
            Constants = new List<KeyValuePair<object, bool>>();
        }

        /// <summary>
        /// 验证表达式常量节点有效性
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public bool Validate(Expression expr)
        {
            Visit(expr);
            return !Constants.Any(e => e.Value == false);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Constants.Add(new KeyValuePair<object, bool>(node.Value, ValidateFunc(node.Value)));
            return node;
        }


        protected override Expression VisitMember(MemberExpression node)
        {

            if (node.Expression.NodeType == ExpressionType.Parameter)
                return node;

            if (node.Member.MemberType == MemberTypes.Property)
            {
                PropertyInfo outerProp = (PropertyInfo)node.Member;
                MemberExpression innerMember = (MemberExpression)node.Expression;
                FieldInfo innerField = (FieldInfo)innerMember.Member;
                ConstantExpression ce = (ConstantExpression)innerMember.Expression;
                object innerObj = ce.Value;
                object outerObj = innerField.GetValue(innerObj);
                var value = outerProp.GetValue(outerObj, null);
                Constants.Add(new KeyValuePair<object, bool>(value, ValidateFunc(value)));

            }
            else if (node.Member.MemberType == MemberTypes.Field)
            {
                FieldInfo innerField = (FieldInfo)node.Member;
                ConstantExpression ce = (ConstantExpression)node.Expression;
                object innerObj = ce.Value;
                object value = innerField.GetValue(innerObj);
                Constants.Add(new KeyValuePair<object, bool>(value, ValidateFunc(value)));
            }

            return node;
        }
    }

}
