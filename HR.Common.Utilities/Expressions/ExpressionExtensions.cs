using System;
using System.Linq.Expressions;

namespace HR.Common.Utilities
{
    internal static class ExpressionExtensions
    {
        public static string GetName<T>(this Expression<Func<T>> expression)
        {
            return (expression.Body as MemberExpression ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression)?.Member.Name;
        }

        public static T GetValue<T>(this Expression<Func<T>> expression) => expression.Compile().Invoke();
    }
}
