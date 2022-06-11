using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace HR.Common.Utilities.Tests
{
    [TestClass]
    public class NullableExtensionsTests
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow(default(int))]
        public void IsNullOrDefault_CalledOnNullOrDefaultInt32_ReturnsTrue(int? target)
        {
            // Arrange

            // Act
            bool result = target.IsNullOrDefault();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNullOrDefault_CalledOnNonNullOrDefaultInt32_ReturnsFalse()
        {
            // Arrange
            int? target = 1;

            // Act
            bool result = target.IsNullOrDefault();

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        public void IsNullOrDefault_CalledOnNullOrDefaultDateTime_ReturnsTrue()
        {
            foreach (var target in new DateTime?[] { null, default(DateTime), DateTime.MinValue })
            {
                // Arrange

                // Act
                bool result = target.IsNullOrDefault();

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void IsNullOrDefault_CalledOnNonNullOrDefaultDateTime_ReturnsFalse()
        {
            // Arrange
            DateTime? target = DateTime.MaxValue;

            // Act
            bool result = target.IsNullOrDefault();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
