using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace HR.Common.Utilities.Tests
{
    [TestClass]
    public class ExceptionExtensionsTests
    {
        [TestMethod]
        public void DetailMessage_ByDefault_ReturnsMessage()
        {
            // Arrange
            var exception = new Exception("<Exception-1>");

            // Act
            var detailMessage = exception.DetailMessage();

            // Assert
            Assert.IsTrue(detailMessage.Contains("<Exception-1>"));
        }

        [TestMethod]
        public void DetailMessage_CalledOnExceptionWithInnerException_ReturnsInnerExceptionDetailsInMessage()
        {
            // Arrange
            var exception = new Exception("<Exception-1>", new Exception("<InnerException-1>"));

            // Act
            var detailMessage = exception.DetailMessage();

            // Assert
            Assert.IsTrue(detailMessage.Contains("<InnerException-1>"));
        }

        [TestMethod]
        public void DetailMessage_CalledOnExceptionWithNestedInnerExceptions_ReturnsAllInnerExceptionDetailsInMessage()
        {
            // Arrange
            var exception = new Exception("<Exception-1>", new Exception("<InnerException-1>", new Exception("<InnerException-2>")));

            // Act
            var detailMessage = exception.DetailMessage();

            // Assert
            Assert.IsTrue(detailMessage.Contains("<InnerException-1>") && detailMessage.Contains("<InnerException-2>"));
        }

        [TestMethod]
        public void DetailMessage_CalledOnExceptionWithInnerExceptionGivenFalse_ExludesInnerExceptionDetailsFromMessage()
        {
            // Arrange
            var exception = new Exception("<Exception-1>", new Exception("<InnerException-1>"));

            // Act
            var detailMessage = exception.DetailMessage(includeInnerExceptions: false);

            // Assert
            Assert.IsFalse(detailMessage.Contains("<InnerException-1>"));
        }
    }
}
