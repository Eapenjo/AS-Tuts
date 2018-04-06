using System;
using System.Reflection;
using System.Linq.Expressions;

namespace Fasetto.Word
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and geths the functions return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lamba">The expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba)
        {
            return lamba.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying property value to the given value, from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lamba">The expression to compile</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamba, T value)
        {
            ///Converts a laba () => some.Property, to sompe.Property
            var expression = (lamba as LambdaExpression).Body as MemberExpression;

            //Geet the property information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //set the property value
            propertyInfo.SetValue(target, value);

        }

    }
}
