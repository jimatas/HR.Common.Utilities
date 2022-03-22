using System;

namespace HR.Common.Utilities
{
    public static class NullableExtensions
    {
        /// <summary>
        /// Determines whether the <see cref="Nullable{T}"/> is either <c>null</c> or has the default value for its underlying type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrDefault<T>(this T? value) where T : struct
               => value.GetValueOrDefault().Equals(default(T));

        /// <summary>
        /// Provides functionality similar to C# 6.0's null conditional operator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="target">The target object.</param>
        /// <param name="expression">The expression to evaluate if the object is not <c>null</c>.</param>
        /// <returns>If the object is not <c>null</c>, the value returned by the expression; otherwise, the default value for the expression's return type.</returns>
        public static TResult IfNotNull<T, TResult>(this T target, Func<T, TResult> expression)
            => target != null ? expression(target) : default;

        /// <summary>
        /// Provides functionality similar to C# 6.0's null conditional operator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target object.</param>
        /// <param name="expression">The expression to evaluate if the object is not <c>null</c>.</param>
        public static void IfNotNull<T>(this T target, Action<T> expression)
        {
            if (target != null)
            {
                expression(target);
            }
        }
    }
}
