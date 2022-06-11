using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HR.Common.Utilities
{
    [DebuggerStepThrough]
    public static partial class EnsureArgumentExtensions
    {
        #region NotNull
        [return: NotNull]
        public static T NotNull<T>(this IEnsureArgument ensureArgument, T value, string paramName)
        {
            return ensureArgument.NotNull(value, paramName, message: "Value cannot be null.");
        }

        [return: NotNull]
        public static T NotNull<T>(this IEnsureArgument _, T value, string paramName, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }
        #endregion

        #region NotNullOrEmpty
        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, string value, string paramName)
        {
            ensureArgument.NotNull(value, paramName);

            if (value.Length == 0)
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, string value, string paramName, string message)
        {
            ensureArgument.NotNull(value, paramName, message);

            if (value.Length == 0)
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }

        [return: NotNull]
        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Guid? value, string paramName)
        {
            ensureArgument.NotNull(value, paramName);

            if (value == Guid.Empty)
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        [return: NotNull]
        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Guid? value, string paramName, string message)
        {
            ensureArgument.NotNull(value, paramName, message);

            if (value == Guid.Empty)
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, IEnumerable<T> value, string paramName)
        {
            ensureArgument.NotNull(value, paramName);

            if (!value.Any())
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, IEnumerable<T> value, string paramName, string message)
        {
            ensureArgument.NotNull(value, paramName, message);

            if (!value.Any())
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }
        #endregion

        #region NotNullOrWhiteSpace
        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, string value, string paramName)
        {
            ensureArgument.NotNullOrEmpty(value, paramName);

            if (value.Trim().Length == 0)
            {
                throw new ArgumentException(message: "Value cannot be whitespace.", paramName);
            }

            return value;
        }

        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, string value, string paramName, string message)
        {
            ensureArgument.NotNullOrEmpty(value, paramName, message);

            if (value.Trim().Length == 0)
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }
        #endregion

        #region NotOutOfRange
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, IComparable<T> value, string paramName, IComparable<T> minValue = null, IComparable<T> maxValue = null)
        {
            return ensureArgument.NotOutOfRange(value, paramName, DefaultMessage(), minValue, maxValue);

            string DefaultMessage()
            {
                var message = "Value cannot be";
                if (minValue != null)
                {
                    message += $" less than {minValue}";
                }

                if (maxValue != null)
                {
                    if (minValue != null)
                    {
                        message += " or";
                    }
                    message += $" greater than {maxValue}";
                }
                message += ".";

                return message;
            }
        }

        public static T NotOutOfRange<T>(this IEnsureArgument _, IComparable<T> value, string paramName, string message, IComparable<T> minValue = null, IComparable<T> maxValue = null)
        {
            if ((minValue != null && Comparer<T>.Default.Compare((T)value, (T)minValue) < 0) ||
                (maxValue != null && Comparer<T>.Default.Compare((T)value, (T)maxValue) > 0))
            {
                throw new ArgumentOutOfRangeException(paramName, value, message);
            }

            return (T)value;
        }

        public static TEnum NotOutOfRange<TEnum>(this IEnsureArgument _, TEnum value, string paramName)
            where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                throw new InvalidEnumArgumentException(paramName, Convert.ToInt32(value), typeof(TEnum));
            }

            return value;
        }
        #endregion
    }
}
