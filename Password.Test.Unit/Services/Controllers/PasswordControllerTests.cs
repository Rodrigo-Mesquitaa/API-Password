using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Password.Application.Interfaces;
using Password.Services_Api.Controllers;
using System.Diagnostics.CodeAnalysis;

namespace Password.Test.Unit.Services.Controllers
{

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PasswordControllerTests
    {
        private Mock<IApplicationServicePassword> _applicationServicePasswordMock;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _applicationServicePasswordMock = new Mock<IApplicationServicePassword>();
            _fixture = new Fixture();
        }

        [Test]
        public void ValidationPasswordSettings_When_PasswordValidation_ShouldReturnOkObjectResult()
        {
            //Arrange
            var password = "AbTp9!fok";

            _applicationServicePasswordMock.Setup(x => x.PasswordValidation(password)).Returns(true);

            var passwordController =
                new PasswordController(_applicationServicePasswordMock.Object);

            //Act
            var actionResult = passwordController.ValidationPasswordSettings(password);

            //Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);
            _applicationServicePasswordMock.Verify(x => x.PasswordValidation(password), Times.Once);
        }
    }
}