using System.Collections.Generic;
using System.ComponentModel;

namespace Evol.Web.Mvc.Html
{
    public static  class VueValidatorRuleModelHelper
    {
        public static Dictionary<object, object> GetModelRole<TModel>() where TModel : class
        {
            var modelRoleDic = new Dictionary<object, object>();
            var propDesCollection = TypeDescriptor.GetProperties(typeof(TModel));
            foreach (PropertyDescriptor propDes in propDesCollection)
            {
                var propName = propDes.Name;
                var attributes = propDes.Attributes;
                var role =  VueValidatorRulePropertyHelper.GetPropRole(propDes);
                modelRoleDic.Add(propDes.Name.ToLower(), role);
            }
            return modelRoleDic;
        }
    }
}
