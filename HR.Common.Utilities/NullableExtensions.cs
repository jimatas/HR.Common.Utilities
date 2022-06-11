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
    }
}
