using System;

namespace HR.Common.Utilities
{
    /// <summary>
    /// Represents the entry point to a set of argument validation functions, a.k.a. guard clauses.
    /// The functions themselves are defined as extension methods on the <see cref="IEnsureArgument"/> interface and throw <see cref="ArgumentException"/> (or one of its derived classes) on failure.
    /// </summary>
    public static class Ensure
    {
        public static readonly IEnsureArgument Argument = new EnsureArgument();

        private sealed class EnsureArgument : IEnsureArgument
        {
        }
    }
}
