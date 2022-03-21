#if NETSTANDARD2_1_OR_GREATER
using System;
using System.Collections.Generic;
#endif
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HR.Common.Utilities
{
    /// <summary>
    /// Provides extension methods that aim to increase the redability of configuring an awaiter to not continue on the captured context.
    /// </summary>
    public static class AwaitableExtensions
    {
        public static ConfiguredTaskAwaitable WithoutCapturingContext(this Task task)
            => task.ConfigureAwait(continueOnCapturedContext: false);

        public static ConfiguredTaskAwaitable<TResult> WithoutCapturingContext<TResult>(this Task<TResult> task)
            => task.ConfigureAwait(continueOnCapturedContext: false);

#if NETSTANDARD2_1_OR_GREATER
        public static ConfiguredValueTaskAwaitable WithoutCapturingContext(this ValueTask valueTask)
            => valueTask.ConfigureAwait(continueOnCapturedContext: false);

        public static ConfiguredValueTaskAwaitable<TResult> WithoutCapturingContext<TResult>(this ValueTask<TResult> valueTask)
            => valueTask.ConfigureAwait(continueOnCapturedContext: false);

        public static ConfiguredAsyncDisposable WithoutCapturingContext(this IAsyncDisposable disposable)
            => disposable.ConfigureAwait(continueOnCapturedContext: false);

        public static ConfiguredCancelableAsyncEnumerable<T> WithoutCapturingContext<T>(this IAsyncEnumerable<T> enumerable)
            => enumerable.ConfigureAwait(continueOnCapturedContext: false);
#endif
    }
}
