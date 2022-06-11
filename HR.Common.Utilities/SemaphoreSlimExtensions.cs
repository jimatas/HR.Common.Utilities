using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Utilities
{
    /// <summary>
    /// Provides extensions methods that allow <see cref="SemaphoreSlim"/> to be used in using statements, such as in:
    /// <code>
    /// using (semaphore.WaitAndRelease())
    /// {
    ///   // Do something while semaphore is being awaited.
    /// }
    /// </code>
    /// </summary>
    public static class SemaphoreSlimExtensions
    {
        public static IDisposable WaitAndRelease(this SemaphoreSlim semaphore)
        {
            semaphore.Wait();
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static IDisposable WaitAndRelease(this SemaphoreSlim semaphore, int millisecondsTimeout)
        {
            semaphore.Wait(millisecondsTimeout);
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static IDisposable WaitAndRelease(this SemaphoreSlim semaphore, TimeSpan timeout)
        {
            semaphore.Wait(timeout);
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static async Task<IDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static async Task<IDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, int millisecondsTimeout, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(millisecondsTimeout, cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static async Task<IDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(timeout, cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }

        private struct SemaphoreSlimReleaser : IDisposable
        {
            private SemaphoreSlim semaphore;
            public SemaphoreSlimReleaser(SemaphoreSlim semaphore) => this.semaphore = semaphore;
            public void Dispose() => Interlocked.Exchange(ref semaphore, null)?.Release();
        }
    }
}
