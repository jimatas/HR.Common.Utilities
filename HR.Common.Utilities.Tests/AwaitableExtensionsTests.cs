using HR.Common.Utilities.Tests.Fixture;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HR.Common.Utilities.Tests
{
    [TestClass]
    public class AwaitableExtensionsTests
    {
        [TestMethod]
        public void WithoutCapturingContext_CalledOnTask_ReturnsConfiguredTaskAwaitable()
        {
            // Arrange
            Task task = Task.CompletedTask;

            // Act
            var awaitable = task.WithoutCapturingContext();

            // Assert
            Assert.IsInstanceOfType(awaitable, typeof(ConfiguredTaskAwaitable));
        }

        [TestMethod]
        public void WithoutCapturingContext_CalledOnTaskOfTResult_ReturnsConfiguredTaskAwaitable()
        {
            // Arrange
            Task<object> task = Task.FromResult(new object());

            // Act
            var awaitable = task.WithoutCapturingContext();

            // Assert
            Assert.IsInstanceOfType(awaitable, typeof(ConfiguredTaskAwaitable<object>));
        }

        [TestMethod]
        public void WithoutCapturingContext_CalledOnValueTask_ReturnsConfiguredValueTaskAwaitable()
        {
            // Arrange
            ValueTask valueTask = ValueTask.CompletedTask;

            // Act
            var awaitable = valueTask.WithoutCapturingContext();

            // Assert
            Assert.IsInstanceOfType(awaitable, typeof(ConfiguredValueTaskAwaitable));
        }

        [TestMethod]
        public void WithoutCapturingContext_CalledOnValueTaskOfTResult_ReturnsConfiguredValueTaskAwaitable()
        {
            // Arrange
            ValueTask<object> valueTask = ValueTask.FromResult(new object());

            // Act
            var awaitable = valueTask.WithoutCapturingContext();

            // Assert
            Assert.IsInstanceOfType(awaitable, typeof(ConfiguredValueTaskAwaitable<object>));
        }

        [TestMethod]
        public void WithoutCapturingContext_CalledOnAsyncDisposable_ReturnsConfiguredAsyncDisposable()
        {
            // Arrange
            IAsyncDisposable disposable = new AsyncDisposable();

            // Act
            var awaitable = disposable.WithoutCapturingContext();

            // Assert
            Assert.IsInstanceOfType(awaitable, typeof(ConfiguredAsyncDisposable));
        }

        [TestMethod]
        public void WithoutCapturingContext_CalledOnAsyncEnumerableOfT_ReturnsConfiguredCancelableAsyncEnumerable()
        {
            // Arrange
            IAsyncEnumerable<object> enumerable = new AsyncEnumerable<object>(Array.Empty<object>());

            // Act
            var awaitable = enumerable.WithoutCapturingContext();

            // Assert
            Assert.IsInstanceOfType(awaitable, typeof(ConfiguredCancelableAsyncEnumerable<object>));
        }
    }
}
