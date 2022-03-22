using HR.Common.Utilities.Tests.Fixture;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HR.Common.Utilities.Tests
{
    [TestClass]
    public class EnsureArgumentTests
    {
        [TestMethod]
        public void NotNull_GivenNonNullValue_ReturnsValue()
        {
            // Arrange
            var nonNullValues = new[]
            {
                new object(),
                string.Empty,
                (int?)0
            };

            foreach (var value in nonNullValues)
            {
                // Act
                var returnValue = Ensure.Argument.NotNull(value, nameof(value));

                // Assert
                Assert.AreEqual(value, returnValue);
            }
        }

        [TestMethod]
        public void NotNull_GivenNullObject_ThrowsArgumentNullException()
        {
            // Arrange
            object value = null;

            // Act
            void action() => Ensure.Argument.NotNull(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNull_GivenNullObject_ThrowsArgumentNullExceptionWithProvidedMessage()
        {
            // Arrange
            const string message = "The object supplied was null.";
            object value = null;

            // Act
            void action() => Ensure.Argument.NotNull(value, nameof(value), message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNull_GivenExpressionEvaluatingToNonNullValue_ReturnsValue()
        {
            // Arrange
            var nonNullValues = new[]
            {
                new object(),
                string.Empty,
                (int?)0
            };

            foreach (var value in nonNullValues)
            {
                // Act
                var returnValue = Ensure.Argument.NotNull(() => value);

                // Assert
                Assert.AreEqual(value, returnValue);
            }
        }

        [TestMethod]
        public void NotNull_GivenExpressionEvaluatingToNull_ThrowsArgumentNullException()
        {
            // Arrange
            object value = null;

            // Act
            void action() => Ensure.Argument.NotNull(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNull_GivenExpressionEvaluatingToBoxedNull_ThrowsArgumentNullException()
        {
            // Arrange
            int? value = null;

            // Act
            void action() => Ensure.Argument.NotNull(() => value);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual(nameof(value), exception.ParamName);
        }

        [TestMethod]
        public void NotNull_GivenExpressionEvaluatingToNull_ThrowsArgumentNullExceptionWithProvidedMessage()
        {
            // Arrange
            const string message = "The object supplied was null.";
            object value = null;

            // Act
            void action() => Ensure.Argument.NotNull(() => value, message);

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"{message} (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNullString_ThrowsArgumentNullExceptionWithExpectedMessage()
        {
            // Arrange
            string value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"Value cannot be null. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenEmptyString_ThrowsArgumentExceptionWithExpectedMessage()
        {
            // Arrange
            var value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"Value cannot be empty. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNonEmptyString_ReturnsString()
        {
            // Arrange
            var value = "String with value";

            // Act
            var returnedValue = Ensure.Argument.NotNullOrEmpty(value, nameof(value));

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
            Assert.AreEqual($"Value cannot be null. (Parameter '{nameof(value)}')", exception.Message);
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
            Assert.AreEqual($"Value cannot be empty. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNewGuid_ReturnsGuid()
        {
            // Arrange
            var value = Guid.NewGuid();

            // Act
            var returnedValue = Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNullList_ThrowsArgumentNullExceptionWithExpectedMessage()
        {
            // Arrange
            IList<object> value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"Value cannot be null. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNullEnumerable_ThrowsArgumentNullExceptionWithExpectedMessage()
        {
            // Arrange
            IEnumerable<object> value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"Value cannot be null. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenEmptyEnumerable_ThrowsArgumentExceptionWithExpectedMessage()
        {
            // Arrange
            IEnumerable<object> value = Array.Empty<object>();

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"Value cannot be empty. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenEmptyList_ThrowsArgumentExceptionWithExpectedMessage()
        {
            // Arrange
            IList<object> value = new List<object>();

            // Act
            void action() => Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"Value cannot be empty. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNonEmptyEnumerable_ReturnsEnumerable()
        {
            // Arrange
            IEnumerable<object> value = new[] { new object(), new object() };

            // Act
            var returnedValue = Ensure.Argument.NotNullOrEmpty(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotNullOrEmpty_GivenNonEmptyList_ReturnsList()
        {
            // Arrange
            IList<object> value = new List<object>(new[] { new object(), new object() });

            // Act
            IList<object> returnedValue = Ensure.Argument.NotNullOrEmpty<IList<object>, object>(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenNullString_ThrowsArgumentNullExceptionWithExpectedMessage()
        {
            // Arrange
            string value = null;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual($"Value cannot be null. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenEmptyString_ThrowsArgumentExceptionWithExpectedMessage()
        {
            // Arrange
            var value = string.Empty;

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"Value cannot be empty. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenAllWhiteSpaceString_ThrowsArgumentExceptionWithExpectedMessage()
        {
            // Arrange
            var value = " \r\n\t";

            // Act
            void action() => Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value));

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual($"Value cannot be whitespace. (Parameter '{nameof(value)}')", exception.Message);
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_GivenValidString_ReturnsString()
        {
            // Arrange
            var value = "String with value\r\n";

            // Act
            var returnedValue = Ensure.Argument.NotNullOrWhiteSpace(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValidTimeSpanForLowerBound_ReturnsTimeSpan()
        {
            // Arrange
            var value = TimeSpan.Zero;

            // Act
            var returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value), lowerBound: TimeSpan.Zero);

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValidTimeSpanForBothBounds_ReturnsTimeSpan()
        {
            // Arrange
            var value = TimeSpan.Zero;

            // Act
            var returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value), lowerBound: TimeSpan.Zero, upperBound: TimeSpan.FromMinutes(10));

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenNegativeTimeSpanAndLowerBoundOfZero_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var value = TimeSpan.FromSeconds(-1);

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value), lowerBound: TimeSpan.Zero);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }

        [TestMethod]
        public void NotOutOfRange_GivenNegativeValueAndLowerBound_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var value = -1;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value), lowerBound: 0);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be less than 0. (Parameter '{nameof(value)}')\r\nActual value was -1.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenTooLargeValueAndUpperBound_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var value = 11;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value), upperBound: 10);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be greater than 10. (Parameter '{nameof(value)}')\r\nActual value was 11.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenNegativeValueAndBothBounds_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var value = -1;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value), lowerBound: 0, upperBound: 10);

            // Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual($"Value cannot be less than 0 or greater than 10. (Parameter '{nameof(value)}')\r\nActual value was -1.", exception.Message);
        }

        [TestMethod]
        public void NotOutOfRange_GivenValidEnumMember_ReturnsMember()
        {
            // Arrange
            const Level value = Level.High;

            // Act
            var returnedValue = Ensure.Argument.NotOutOfRange(value, nameof(value));

            // Assert
            Assert.AreEqual(value, returnedValue);
        }

        [TestMethod]
        public void NotOutOfRange_GivenInvalidEnumMember_ThrowsAppropriateException()
        {
            // Arrange
            const Level value = (Level)int.MaxValue;

            // Act
            void action() => Ensure.Argument.NotOutOfRange(value, nameof(value));

            // Assert
            Assert.ThrowsException<InvalidEnumArgumentException>(action);
        }
    }
}
