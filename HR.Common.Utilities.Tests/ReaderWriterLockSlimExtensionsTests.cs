using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading;

namespace HR.Common.Utilities.Tests
{
    [TestClass]
    public class ReaderWriterLockSlimExtensionsTests
    {
        [TestMethod]
        public void EnterReadLockAndExit_ByDefault_ReturnsDisposable()
        {
            // Arrange
            ReaderWriterLockSlim readWriteLock = new();

            // Act
            IDisposable disposable = readWriteLock.EnterReadLockAndExit();

            // Assert
            Assert.IsNotNull(disposable);
            Assert.IsInstanceOfType(disposable, typeof(IDisposable));
        }

        [TestMethod]
        public void EnterReadLockAndExit_Disposing_ExitsLock()
        {
            // Arrange
            ReaderWriterLockSlim readWriteLock = new();
            var countBeforeEnter = readWriteLock.CurrentReadCount;

            // Act
            IDisposable disposable = readWriteLock.EnterReadLockAndExit();
            var countBeforeExit = readWriteLock.CurrentReadCount;
            disposable.Dispose();
            var countAfterExit = readWriteLock.CurrentReadCount;

            // Assert
            Assert.AreEqual(0, countBeforeEnter);
            Assert.AreEqual(1, countBeforeExit);
            Assert.AreEqual(0, countAfterExit);
        }

        [TestMethod]
        public void EnterWriteLockAndExit_ByDefault_ReturnsDisposable()
        {
            // Arrange
            ReaderWriterLockSlim readWriteLock = new();

            // Act
            IDisposable disposable = readWriteLock.EnterWriteLockAndExit();

            // Assert
            Assert.IsNotNull(disposable);
            Assert.IsInstanceOfType(disposable, typeof(IDisposable));
        }

        [TestMethod]
        public void EnterWriteLockAndExit_Disposing_ExitsLock()
        {
            // Arrange
            ReaderWriterLockSlim readWriteLock = new();
            var isLockedBeforeEnter = readWriteLock.IsWriteLockHeld;

            // Act
            IDisposable disposable = readWriteLock.EnterWriteLockAndExit();
            var isLockedBeforeExit = readWriteLock.IsWriteLockHeld;
            disposable.Dispose();
            var isLockedAfterExit = readWriteLock.IsWriteLockHeld;

            // Assert
            Assert.IsFalse(isLockedBeforeEnter);
            Assert.IsTrue(isLockedBeforeExit);
            Assert.IsFalse(isLockedAfterExit);
        }

        [TestMethod]
        public void EnterUpgradeableReadLockAndExit_ByDefault_ReturnsDisposable()
        {
            // Arrange
            ReaderWriterLockSlim readWriteLock = new();

            // Act
            IDisposable disposable = readWriteLock.EnterUpgradeableReadLockAndExit();

            // Assert
            Assert.IsNotNull(disposable);
            Assert.IsInstanceOfType(disposable, typeof(IDisposable));
        }

        [TestMethod]
        public void EnterUpgradeableReadLockAndExit_Disposing_ExitsLock()
        {
            // Arrange
            ReaderWriterLockSlim readWriteLock = new();
            var isLockedBeforeEnter = readWriteLock.IsUpgradeableReadLockHeld;

            // Act
            IDisposable disposable = readWriteLock.EnterUpgradeableReadLockAndExit();
            var isLockedBeforeExit = readWriteLock.IsUpgradeableReadLockHeld;
            disposable.Dispose();
            var isLockedAfterExit = readWriteLock.IsUpgradeableReadLockHeld;

            // Assert
            Assert.IsFalse(isLockedBeforeEnter);
            Assert.IsTrue(isLockedBeforeExit);
            Assert.IsFalse(isLockedAfterExit);
        }
    }
}
