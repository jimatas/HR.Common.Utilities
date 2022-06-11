using System;
using System.Text;

namespace HR.Common.Utilities
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns a more detailed error message for the exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="includeInnerExceptions">Indicates whether to include possible inner exception details in the returned error message.</param>
        /// <returns></returns>
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
