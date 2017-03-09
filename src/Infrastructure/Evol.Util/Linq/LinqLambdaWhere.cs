using System;
using System.Collections.Generic;
using System.Linq;

namespace Evol.Util.Linq
{



    public class LambdaWhere<T>
    {

        public static LambdaWhere<T> Create()
        {
            return new LambdaWhere<T>();
        }

        private List<KeyValuePair<ConstraintType, Func<T, bool>>> _conditions;

        public int ValidCount
        {
            get
            {
                return this._conditions.Count;
            }

        }

        public LambdaWhere()
        {
            _conditions = new List<KeyValuePair<ConstraintType, Func<T, bool>>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt">条件表达式</param>
        /// <param name="value">条件值</param>
        /// <param name="force">为ture则强制执行该条件，无论value值是否有效，默认false</param>
        /// <returns></returns>
        public LambdaWhere<T> Add(Func<T, bool> cdt, object value, bool force = false)
        {
            return this.AddCondition(cdt, value, ConstraintType.And, force);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assert"></param>
        /// <param name="value"></param>
        /// <param name="force">为true:无论value是否有效，均计算该表达式</param>
        /// <returns></returns>
        public LambdaWhere<T> EachAdd(Func<T, string, bool> assert, string[] value, bool force = false)
        {
            if (value == null)
                return this;
            value.ToList().ForEach(v => {
                this.AddCondition(e => assert(e, v), value, ConstraintType.And, force);
            });
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assert"></param>
        /// <param name="value"></param>
        /// <param name="force">为true:无论value是否有效，均计算该表达式</param>
        /// <returns></returns>
        public LambdaWhere<T> EachOr(Func<T, string, bool> assert, string[] value, bool force = false)
        {
            if (value == null)
                return this;
            value.ToList().ForEach(v =>
            {
                this.AddCondition(e => assert(e, v), value, ConstraintType.Or, force);
            });
            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt"></param>
        /// <param name="value"></param>
        /// <param name="force">为true:无论value是否有效，均计算该表达式</param>
        /// <returns></returns>
        public LambdaWhere<T> Or(Func<T, bool> cdt, object value, bool force = false)
        {
            return this.AddCondition(cdt, value, ConstraintType.Or, force);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdt"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="force">为true:无论value是否有效，均计算该表达式</param>
        /// <returns></returns>
        public LambdaWhere<T> AddCondition(Func<T, bool> cdt, object value, ConstraintType type, bool force = false)
        {
            if (!force)
            {
                if (value == null)
                    return this;
                if ((value is string) && String.IsNullOrWhiteSpace(value.ToString()))
                    return this;
                if (value is Array && ((Array)value).Length == 0)
                    return this;
            }

            this._conditions.Add(new KeyValuePair<ConstraintType, Func<T, bool>>(type, cdt));
            return this;

        }

        public LambdaWhere<T> AndExpression(Func<LambdaWhere<T>, LambdaWhere<T>> expression, object value)
        {
            return AddConditionExpression(expression, value, ConstraintType.And);
        }

        public LambdaWhere<T> OrExpression(Func<LambdaWhere<T>, LambdaWhere<T>> expression, object value)
        {
            return AddConditionExpression(expression, value, ConstraintType.Or);
        }

        private LambdaWhere<T> AddConditionExpression(Func<LambdaWhere<T>, LambdaWhere<T>> expression, object value, ConstraintType type)
        {
            var part = expression.Invoke(LambdaWhere<T>.Create());
            if (part.ValidCount == 0)
                return this;

            this.AddCondition(part.ToFunc(), value, type);
            return this;
        }


        public Func<T, bool> ToFunc()
        {
            if (this._conditions.Count == 0)
                return e => { return true; };

            return e =>
            {
                var result = true;
                this._conditions.ForEach(f =>
                {
                    if (f.Key == ConstraintType.And)
                        result = f.Value(e) && result;
                    else
                        result = f.Value(e) || result;
                });
                return result;
            };
        }
    }

    /// <summary>
    /// And, Or
    /// </summary>
    public enum ConstraintType
    {
        /// <summary>
        /// AND operator
        /// </summary>
        And,
        /// <summary>
        /// OR Operator
        /// </summary>
        Or
    }
}
