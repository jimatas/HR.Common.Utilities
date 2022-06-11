using HR.Common.Utilities.Tests.Fixture;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HR.Common.Utilities.Tests
{
    [TestClass]
    public class EnsureArgumentTests
    {
        #region NotNull
        [TestMethod]
        public void NotNull_GivenNonNullValue_ReturnsValue()
        {
            // Arrange
            object?[] nonNullValues = new[]
            {
                new object(),
                string.Empty,
                0
            };

            foreach (var value in nonNullValues)
            {
                // Act
                object returnValue = Ensure.Argument.NotNull(value, nameof(value));

                // Assert
                Assert.AreEqual(value, returnValue);
            }
        }

        [TestMethod]
        public void NotNullWithMessage_GivenNonNullValue_ReturnsValue()
        {
            // Arrange
            object?[] nonNullValues = new[]
            {
                new object(),
                string.Empty,
                0
            };

            foreach (var value in nonNullValues)
            {
                // Act
                object returnValue = Ensure.Argument.NotNull(value, nameof(value), "Cannot be null.");

                // Assert
                Assert.AreEqual(value, returnValue);
            }
        }

        [TestMethod]
        public void NotNull_GivenNullValue_ThrowsArgumentNullException()
        {
            // Arrange
            object? value = null;

            // Act
            void action() => Ensure.Argument.NotNull(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullWithMessage_GivenNullValue_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null.";
            object? value = null;

            // Act
            void action() => Ensure.Argument.NotNull(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNull_GivenExpressionReturningNonNullValue_ReturnsValue()
        {
            // Arrange
            object?[] nonNullValues = new[]
            {
                new object(),
                string.Empty,
                0
            };

            foreach (var value in nonNullValues)
            {
                // Act
                object returnValue = Ensure.Argument.NotNull(() => value);

                // Assert
                Assert.AreEqual(value, returnValue);
            }
        }

        [TestMethod]
        public void NotNullWithMessage_GivenExpressionReturningNonNullValue_ReturnsValue()
        {
            // Arrange
            object?[] nonNullValues = new[]
            {
                new object(),
                string.Empty,
                0
            };

            foreach (var value in nonNullValues)
            {
                // Act
                object returnValue = Ensure.Argument.NotNull(() => value, "Cannot be null.");

                // Assert
                Assert.AreEqual(value, returnValue);
            }
        }

        [TestMethod]
        public void NotNull_GivenExpressionReturningNullValue_ThrowsArgumentNullException()
        {
            // Arrange
            object? value = null;

            // Act
            void action() => Ensure.Argument.NotNull(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullWithMessage_GivenExpressionReturningNullValue_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null.";
            object? value = null;

            // Act
            void action() => Ensure.Argument.NotNull(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }
        #endregion

        #region NotNullOrEmpty<string>
        [TestMethod]
        public void NotNullOrEmpty_GivenNonNullOrEmptyString_ReturnsString()
        {
            // Arrange
            string? value = "Non-null or empty string";
            string returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenNonNullOrEmptyString_ReturnsString()
        {
            // Arrange
            string? value = "Non-null or empty string";
            string returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrEmpty(value, nameof(value), "Cannot be null or empty");

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNullString_ThrowsArgumentNullException()
        {
            // Arrange
            string? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenNullString_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            string? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenEmptyString_ThrowsArgumentException()
        {
            // Arrange
            string? value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenEmptyString_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            string? value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningNonNullOrEmptyString_ReturnsString()
        {
            // Arrange
            string? value = "Non-null or empty string";
            string returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningNonNullOrEmptyString_ReturnsString()
        {
            // Arrange
            string? value = "Non-null or empty string";
            string returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrEmpty(() => value, "Cannot be null or empty");

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningNullString_ThrowsArgumentNullException()
        {
            // Arrange
            string? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningNullString_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            string? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningEmptyString_ThrowsArgumentException()
        {
            // Arrange
            string? value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningEmptyString_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            string? value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }
        #endregion

        #region NotNullOrEmpty<Guid>
        [TestMethod]
        public void NotNullOrEmpty_GivenNonNullOrEmptyGuid_ReturnsGuid()
        {
            // Arrange
            Guid? value = Guid.NewGuid();

            // Act
            Guid returnedValue = (Guid)Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenNonNullOrEmptyGuid_ReturnsGuid()
        {
            // Arrange
            Guid? value = Guid.NewGuid();

            // Act
            Guid returnedValue = (Guid)Ensure.Argument.NotNullOrEmpty(value, nameof(value), "Cannot be null or empty.");

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNullGuid_ThrowsArgumentNullException()
        {
            // Arrange
            Guid? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenNullGuid_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            Guid? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenEmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            var value = Guid.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenEmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            var value = Guid.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningNonNullOrEmptyGuid_ReturnsGuid()
        {
            // Arrange
            Guid? value = Guid.NewGuid();

            // Act
            Guid returnedValue = (Guid)Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningNonNullOrEmptyGuid_ReturnsGuid()
        {
            // Arrange
            Guid? value = Guid.NewGuid();

            // Act
            Guid returnedValue = (Guid)Ensure.Argument.NotNullOrEmpty(() => value, "Cannot be null or empty.");

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningNullGuid_ThrowsArgumentNullException()
        {
            // Arrange
            Guid? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningNullGuid_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            Guid? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningEmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            var value = Guid.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningEmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            var value = Guid.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }
        #endregion

        #region NotNullOrEmpty<IEnumerable<T>>
        [TestMethod]
        public void NotNullOrEmpty_GivenNonNullEnumerable_ReturnsEnumerable()
        {
            // Arrange
            IEnumerable<object>? value = new List<object>(new object[] { new(), new() });
            IEnumerable<object> returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenNonNullEnumerable_ReturnsEnumerable()
        {
            // Arrange
            IEnumerable<object>? value = new List<object>(new object[] { new(), new() });
            IEnumerable<object> returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrEmpty(value, nameof(value), "Cannot be null or empty.");

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNullEnumerable_ThrowsArgumentNullException()
        {
            // Arrange
            IEnumerable<object>? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenNullEnumerable_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            IEnumerable<object>? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenEmptyEnumerable_ThrowsArgumentException()
        {
            // Arrange
            IEnumerable<object>? value = Enumerable.Empty<object>();

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenEmptyEnumerable_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            IEnumerable<object>? value = Enumerable.Empty<object>();

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningNonNullEnumerable_ReturnsEnumerable()
        {
            // Arrange
            IEnumerable<object>? value = new List<object>(new object[] { new(), new() });
            IEnumerable<object> returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningNonNullEnumerable_ReturnsEnumerable()
        {
            // Arrange
            IEnumerable<object>? value = new List<object>(new object[] { new(), new() });
            IEnumerable<object> returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrEmpty(() => value, "Cannot be null or empty.");

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningNullEnumerable_ThrowsArgumentNullException()
        {
            // Arrange
            IEnumerable<object>? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningNullEnumerable_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            IEnumerable<object>? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenExpressionReturningEmptyEnumerable_ThrowsArgumentException()
        {
            // Arrange
            IEnumerable<object>? value = Enumerable.Empty<object>();

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrEmptyWithMessage_GivenExpressionReturningEmptyEnumerable_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or empty.";
            IEnumerable<object>? value = Enumerable.Empty<object>();

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }
        #endregion

        #region NotNullOrWhiteSpace
        [TestMethod]
        public void NotNullOrWhiteSpace_GivenNonNullOrWhiteString_ReturnsString()
        {
            // Arrange
            string? value = "Non-null or white string";
            string returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithMessage_GivenNonNullOrWhiteString_ReturnsString()
        {
            // Arrange
            string? value = "Non-null or white string";
            string returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value), "Cannot be null or whitespace.");

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenNullString_ThrowsArgumentNullException()
        {
            // Arrange
            string? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithMessage_GivenNullString_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null or whitespace.";
            string? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenEmptyString_ThrowsArgumentException()
        {
            // Arrange
            string? value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithMessage_GivenEmptyString_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or whitespace.";
            string? value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenWhiteSpaceString_ThrowsArgumentException()
        {
            // Arrange
            string? value = "\r\n";

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithMessage_GivenWhiteSpaceString_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or whitespace.";
            string? value = "\r\n";

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenExpressionReturningNonNullOrWhiteString_ReturnsString()
        {
            // Arrange
            string? value = "Non-null or white string";
            string returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrWhiteSpace(() => value);

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithMessage_GivenExpressionReturningNonNullOrWhiteString_ReturnsString()
        {
            // Arrange
            string? value = "Non-null or white string";
            string returnValue;

            // Act
            returnValue = Ensure.Argument.NotNullOrWhiteSpace(() => value, "Cannot be null or whitespace.");

            // Assert
            Assert.AreEqual(value, returnValue);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenExpressionReturningNullString_ThrowsArgumentNullException()
        {
            // Arrange
            string? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithMessage_GivenExpressionReturningNullString_ThrowsArgumentNullException()
        {
            // Arrange
            const string message = "Cannot be null or whitespace.";
            string? value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenExpressionReturningEmptyString_ThrowsArgumentException()
        {
            // Arrange
            string? value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithMessage_GivenExpressionReturningEmptyString_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or whitespace.";
            string? value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenExpressionReturningWhiteSpaceString_ThrowsArgumentException()
        {
            // Arrange
            string? value = "\r\n";

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithMessage_GivenExpressionReturningWhiteSpaceString_ThrowsArgumentException()
        {
            // Arrange
            const string message = "Cannot be null or whitespace.";
            string? value = "\r\n";

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }
        #endregion

        #region NotOutOfRange
        [TestMethod]
        public void NotOutOfRange_GivenValueGreaterThanMinValue_ReturnsValue()
        {
            // Arrange
            TimeSpan value = TimeSpan.FromTicks(1);

            // Act
            TimeSpan returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value), minValue: TimeSpan.Zero);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValueEqualToMinValue_ReturnsValue()
        {
            // Arrange
            TimeSpan value = TimeSpan.FromTicks(0);

            // Act
            TimeSpan returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value), minValue: TimeSpan.Zero);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValueLessThanMaxValue_ReturnsValue()
        {
            // Arrange
            double value = 0.0;

            // Act
            double returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value), maxValue: 1.0);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValueEqualToMaxValue_ReturnsValue()
        {
            // Arrange
            double value = 1.0;

            // Act
            double returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value), maxValue: 1.0);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValueBetweenMinAndMaxValue_ReturnsValue()
        {
            // Arrange
            int value = 10;

            // Act
            int returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value), minValue: 1, maxValue: 20);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRangeWithMessage_GivenValueBetweenMinAndMaxValue_ReturnsValue()
        {
            // Arrange
            int value = 10;

            // Act
            int returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value), "Must be in range.", minValue: 1, maxValue: 20);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValueLessThanMinValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int value = -1;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value), minValue: 0);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be less than 0. (Parameter '{nameof(value)}')\r\nActual value was -1.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValueGreaterThanMaxValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int value = 10;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value), maxValue: 5);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be greater than 5. (Parameter '{nameof(value)}')\r\nActual value was 10.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenOutOfRangeValueAndMinAndMaxValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int value = -1;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value), minValue: 0, maxValue: 10);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be less than 0 or greater than 10. (Parameter '{nameof(value)}')\r\nActual value was -1.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRangeWithMessage_GivenOutOfRangeValueAndMinAndMaxValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            const string message = "Must be in range.";
            int value = -1;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value), message, minValue: 0, maxValue: 10);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')\r\nActual value was -1.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValidEnumMember_ReturnsMember()
        {
            // Arrange
            Level value = Level.High;

            // Act
            Level returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenInvalidEnumMember_ThrowsInvalidEnumArgumentException()
        {
            // Arrange
            Level value = (Level)int.MaxValue;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value));

            // Assert
            Assert.ThrowsException<InvalidEnumArgumentException>(action);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningValueGreaterThanMinValue_ReturnsValue()
        {
            // Arrange
            TimeSpan value = TimeSpan.FromTicks(1);

            // Act
            TimeSpan returnedValue = Ensure.Argument.NotOutOfRange(() => value, minValue: TimeSpan.Zero);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningValueEqualToMinValue_ReturnsValue()
        {
            // Arrange
            TimeSpan value = TimeSpan.FromTicks(0);

            // Act
            TimeSpan returnedValue = Ensure.Argument.NotOutOfRange(() => value, minValue: TimeSpan.Zero);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningValueLessThanMaxValue_ReturnsValue()
        {
            // Arrange
            double value = 0.0;

            // Act
            double returnedValue = Ensure.Argument.NotOutOfRange(() => value, maxValue: 1.0);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningValueEqualToMaxValue_ReturnsValue()
        {
            // Arrange
            double value = 1.0;

            // Act
            double returnedValue = Ensure.Argument.NotOutOfRange(() => value, maxValue: 1.0);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningValueBetweenMinAndMaxValue_ReturnsValue()
        {
            // Arrange
            int value = 10;

            // Act
            int returnedValue = Ensure.Argument.NotOutOfRange(() => value, minValue: 1, maxValue: 20);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRangeWithMessage_GivenExpressionReturningValueBetweenMinAndMaxValue_ReturnsValue()
        {
            // Arrange
            int value = 10;

            // Act
            int returnedValue = Ensure.Argument.NotOutOfRange(() => value, "Must be in range.", minValue: 1, maxValue: 20);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningValueLessThanMinValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int value = -1;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(() => value, minValue: 0);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be less than 0. (Parameter '{nameof(value)}')\r\nActual value was -1.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningValueGreaterThanMaxValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int value = 10;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(() => value, maxValue: 5);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be greater than 5. (Parameter '{nameof(value)}')\r\nActual value was 10.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningOutOfRangeValueAndMinAndMaxValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int value = -1;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(() => value, minValue: 0, maxValue: 10);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be less than 0 or greater than 10. (Parameter '{nameof(value)}')\r\nActual value was -1.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRangeWithMessage_GivenExpressionReturningOutOfRangeValueAndMinAndMaxValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            const string message = "Must be in range.";
            int value = -1;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(() => value, message, minValue: 0, maxValue: 10);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')\r\nActual value was -1.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningValidEnumMember_ReturnsMember()
        {
            // Arrange
            Level value = Level.High;

            // Act
            Level returnedValue = Ensure.Argument.NotOutOfRange(() => value);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenExpressionReturningInvalidEnumMember_ThrowsInvalidEnumArgumentException()
        {
            // Arrange
            Level value = (Level)int.MaxValue;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(() => value);

            // Assert
            Assert.ThrowsException<InvalidEnumArgumentException>(action);
        }
        #endregion
    }
}
