using System;
using System.Threading;

namespace HR.Common.Utilities
{
    /// <summary>
    /// Provides extension methods that allow <see cref="ReaderWriterLockSlim"/> to be used in using statements, such as in:
    /// <code>
    /// using (rwlock.EnterReadLockAndExit())
    /// {
    ///   // Do something while a read lock is being held.
    /// }
    /// </code>
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {
        public static IDisposable EnterReadLockAndExit(this ReaderWriterLockSlim readerWriterLock)
        {
            readerWriterLock.EnterReadLock();
            return new ReaderWriterLockSlimExiter(readerWriterLock, isReadLocked: true, isWriteLocked: false);
        }

        public static IDisposable EnterWriteLockAndExit(this ReaderWriterLockSlim readerWriterLock)
        {
            readerWriterLock.EnterWriteLock();
            return new ReaderWriterLockSlimExiter(readerWriterLock, isReadLocked: false, isWriteLocked: true);
        }

        public static IDisposable EnterUpgradeableReadLockAndExit(this ReaderWriterLockSlim readerWriterLock)
        {
            readerWriterLock.EnterUpgradeableReadLock();
            return new ReaderWriterLockSlimExiter(readerWriterLock, isReadLocked: true, isWriteLocked: true);
        }

        private struct ReaderWriterLockSlimExiter : IDisposable
        {
            private readonly ReaderWriterLockSlim readerWriterLock;
            private readonly bool isReadLocked;
            private readonly bool isWriteLocked;
            private int disposed;

            public ReaderWriterLockSlimExiter(ReaderWriterLockSlim readerWriterLock, bool isReadLocked, bool isWriteLocked)
            {
                this.readerWriterLock = readerWriterLock;
                this.isReadLocked = isReadLocked;
                this.isWriteLocked = isWriteLocked;
                disposed = 0;
            }

            public void Dispose()
            {
                if (Interlocked.Exchange(ref disposed, 1) != 1)
                {
                    ExitReadOrWriteLock();
                }
            }

            private void ExitReadOrWriteLock()
            {
                if (isReadLocked)
                {
                    if (isWriteLocked)
                    {
                        readerWriterLock.ExitUpgradeableReadLock();
                    }
                    else
                    {
                        readerWriterLock.ExitReadLock();
                    }
                }
                else if (isWriteLocked)
                {
                    readerWriterLock.ExitWriteLock();
                }
            }
        }
    }
}
