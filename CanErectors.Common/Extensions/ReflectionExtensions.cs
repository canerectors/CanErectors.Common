using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace CanErectors.Common
{
    public static class ReflectionExtensions
    {
        public static PropertyInfo GetProperty<TEntity, TProperty>(this Expression<Func<TEntity, TProperty>> source)
        {
            //TODO: check TEntity, if needed. Now it's ignored

            var member = source.Body as MemberExpression;

            if (member == null)
                throw new ArgumentException($"Expression '{source}' refers to a method, not a property.");
            
            var propertyInfo = member.Member as PropertyInfo;

            if (propertyInfo == null)
                throw new ArgumentException($"Expression '{source}' refers to a field, not a property.");
            
            return propertyInfo;
        }

        public static string GetPropertyName<TEntity, TProperty>(this Expression<Func<TEntity, TProperty>> source)
        {

            return source.GetProperty().Name;
        }
    }
}
