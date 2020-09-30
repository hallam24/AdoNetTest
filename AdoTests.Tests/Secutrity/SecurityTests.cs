using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdoForm.Security;
using AdoForm.Models;

namespace AdoTests.Tests.Secutrity
{
    [TestClass]
    public class SecurityTests
    {
        [TestMethod]
        public void TestTwoHashes()
        {
            // Arrange
            SecurityHandler securityHandler = new SecurityHandler();
            User userOne = new User() { Email = "userOne@email.com", Password = "abc123" };
            User userTwo = new User() { Email = "userTwo@email.com", Password = "def456" };
            // Act
            string userOnePass = securityHandler.HashPassword(userOne.Password);
            string userTwoPass = securityHandler.HashPassword(userOne.Password);
            // Assert
            Assert.AreNotEqual(userOnePass, userTwoPass);
        }
        [TestMethod]
        public void TestCompareSamePassword()
        {
            // Arrange
            SecurityHandler securityHandler = new SecurityHandler();
            User userOne = new User() { Email = "userOne@email.com", Password = "abc123" };
            // Act
            string userOnePass = securityHandler.HashPassword(userOne.Password);
            bool samePassword = securityHandler.ArePasswordsSame(userOnePass, "abc123");

            // Assert
            Assert.IsTrue(samePassword);
        }
        [TestMethod]
        public void TestCompareDifferentPassword()
        {
            // Arrange
            SecurityHandler securityHandler = new SecurityHandler();
            User userOne = new User() { Email = "userOne@email.com", Password = "abc123" };
            // Act
            string userOnePass = securityHandler.HashPassword(userOne.Password);
            bool samePassword = securityHandler.ArePasswordsSame(userOnePass, "def456");

            // Assert
            Assert.IsFalse(samePassword);
        }
    }
}
