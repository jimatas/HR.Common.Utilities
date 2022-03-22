using System;
using System.Text;

namespace HR.Common.Utilities
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns a detailed error message for the exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="includeInnerExceptions">Indicates whether to include the details of any inner exceptions.</param>
        /// <returns>A detailed description of the exception, including stack trace information.</returns>
        public static string DetailMessage(this Exception exception, bool includeInnerExceptions = true)
        {
            var detailMessageBuilder = new StringBuilder(exception.BuildDetailMessage());

            if (includeInnerExceptions)
            {
                exception.AppendInnerExceptionsTo(detailMessageBuilder);
            }

            return detailMessageBuilder.ToString();
        }

        private static string BuildDetailMessage(this Exception exception)
        {
            var detailMessage = $"{exception.GetType().FullName}: {exception.Message}";

            if (!string.IsNullOrEmpty(exception.StackTrace))
            {
                detailMessage += Environment.NewLine + exception.StackTrace;
            }

            return detailMessage;
        }

        private static void AppendInnerExceptionsTo(this Exception exception, StringBuilder detailMessageBuilder, int depth = 0)
        {
            if (exception.InnerException != null)
            {
                depth++;
                detailMessageBuilder.Append($" [{nameof(exception.InnerException)} ({depth}): {exception.InnerException.BuildDetailMessage()}]");

                exception.InnerException.AppendInnerExceptionsTo(detailMessageBuilder, depth);
            }
        }
    }
}
