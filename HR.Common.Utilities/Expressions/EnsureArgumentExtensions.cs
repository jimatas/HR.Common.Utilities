using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace HR.Common.Utilities
{
    public static partial class EnsureArgumentExtensions
    {
        #region NotNull
        [return: NotNull]
        public static T NotNull<T>(this IEnsureArgument ensureArgument, Expression<Func<T>> argument)
        {
            return ensureArgument.NotNull(argument.GetValue(), argument.GetName());
        }

        [return: NotNull]
        public static T NotNull<T>(this IEnsureArgument ensureArgument, Expression<Func<T>> argument, string message)
        {
            return ensureArgument.NotNull(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotNullOrEmpty
        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<string>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<string>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }

        [return: NotNull]
        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<Guid?>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        [return: NotNull]
        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<Guid?>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, Expression<Func<IEnumerable<T>>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, Expression<Func<IEnumerable<T>>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotNullOrWhiteSpace
        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, Expression<Func<string>> argument)
        {
            return ensureArgument.NotNullOrWhiteSpace(argument.GetValue(), argument.GetName());
        }

        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, Expression<Func<string>> argument, string message)
        {
            return ensureArgument.NotNullOrWhiteSpace(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotOutOfRange
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, Expression<Func<IComparable<T>>> argument, IComparable<T> minValue = null, IComparable<T> maxValue = null)
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName(), minValue, maxValue);
        }

        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, Expression<Func<IComparable<T>>> argument, string message, IComparable<T> minValue = null, IComparable<T> maxValue = null)
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName(), message, minValue, maxValue);
        }

        public static TEnum NotOutOfRange<TEnum>(this IEnsureArgument ensureArgument, Expression<Func<TEnum>> argument)
            where TEnum : struct, Enum
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName());
        }
        #endregion
    }
}
