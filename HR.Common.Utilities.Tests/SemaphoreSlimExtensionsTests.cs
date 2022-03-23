using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Utilities.Tests
{
    [TestClass]
    public class SemaphoreSlimExtensionsTests
    {
        [TestMethod]
        public void WaitAndRelease_ByDefault_ReturnsDisposable()
        {
            // Arrange
            SemaphoreSlim semaphore = new(initialCount: 1, maxCount: 1);

            // Act
            IDisposable disposable = semaphore.WaitAndRelease();

            // Assert
            Assert.IsNotNull(disposable);
            Assert.IsInstanceOfType(disposable, typeof(IDisposable));
        }

        [TestMethod]
        public void WaitAndRelease_Disposing_ReleasesSemaphore()
        {
            // Arrange
            SemaphoreSlim semaphore = new(initialCount: 1, maxCount: 1);
            var countBeforeWait = semaphore.CurrentCount;

            // Act
            IDisposable disposable = semaphore.WaitAndRelease();
            var countBeforeRelease = semaphore.CurrentCount;
            disposable.Dispose();
            var countAfterRelease = semaphore.CurrentCount;

            // Assert
            Assert.AreEqual(1, countBeforeWait);
            Assert.AreEqual(0, countBeforeRelease);
            Assert.AreEqual(1, countAfterRelease);
        }

        [TestMethod]
        public async Task WaitAndReleaseAsync_ByDefault_ReturnsDisposable()
        {
            // Arrange
            SemaphoreSlim semaphore = new(initialCount: 1, maxCount: 1);

            // Act
            IDisposable disposable = await semaphore.WaitAndReleaseAsync();

            // Assert
            Assert.IsNotNull(disposable);
            Assert.IsInstanceOfType(disposable, typeof(IDisposable));
        }

        [TestMethod]
        public async Task WaitAndReleaseAsync_Disposing_ReleasesSemaphore()
        {
            // Arrange
            SemaphoreSlim semaphore = new(initialCount: 1, maxCount: 1);
            var countBeforeWait = semaphore.CurrentCount;

            // Act
            IDisposable disposable = await semaphore.WaitAndReleaseAsync();
            var countBeforeRelease = semaphore.CurrentCount;
            disposable.Dispose();
            var countAfterRelease = semaphore.CurrentCount;

            // Assert
            Assert.AreEqual(1, countBeforeWait);
            Assert.AreEqual(0, countBeforeRelease);
            Assert.AreEqual(1, countAfterRelease);
        }
    }
}
