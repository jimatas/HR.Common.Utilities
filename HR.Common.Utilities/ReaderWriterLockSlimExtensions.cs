using System;
using System.Threading;

namespace HR.Common.Utilities
{
    /// <summary>
    /// Provides extension methods that allow <see cref="ReaderWriterLockSlim"/> to be used in using statements, such as in:
    /// <code>
    /// using (rwlock.EnterReadLockAndExit())
    /// {
    ///   // Do something while read lock is held.
    /// }
    /// </code>
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {
        public static IDisposable EnterReadLockAndExit(this ReaderWriterLockSlim readWriteLock)
        {
            readWriteLock.EnterReadLock();
            return new ReaderWriterLockSlimExiter(readWriteLock, isReadLock: true, isWriteLock: false);
        }

        public static IDisposable EnterWriteLockAndExit(this ReaderWriterLockSlim readWriteLock)
        {
            readWriteLock.EnterWriteLock();
            return new ReaderWriterLockSlimExiter(readWriteLock, isReadLock: false, isWriteLock: true);
        }

        public static IDisposable EnterUpgradeableReadLockAndExit(this ReaderWriterLockSlim readWriteLock)
        {
            readWriteLock.EnterUpgradeableReadLock();
            return new ReaderWriterLockSlimExiter(readWriteLock, isReadLock: true, isWriteLock: true);
        }

        private struct ReaderWriterLockSlimExiter : IDisposable
        {
            private ReaderWriterLockSlim readWriteLock;
            private readonly bool isReadLock;
            private readonly bool isWriteLock;

            public ReaderWriterLockSlimExiter(ReaderWriterLockSlim readWriteLock, bool isReadLock, bool isWriteLock)
            {
                this.readWriteLock = readWriteLock;
                this.isReadLock = isReadLock;
                this.isWriteLock = isWriteLock;
            }

            public void Dispose()
            {
                if (readWriteLock != null)
                {
                    ExitReadOrWriteLock();
                    readWriteLock = null;
                }
            }

            private void ExitReadOrWriteLock()
            {
                if (isReadLock)
                {
                    if (isWriteLock)
                    {
                        readWriteLock.ExitUpgradeableReadLock();
                    }
                    else
                    {
                        readWriteLock.ExitReadLock();
                    }
                }
                else if (isWriteLock)
                {
                    readWriteLock.ExitWriteLock();
                }
            }
        }
    }
}
