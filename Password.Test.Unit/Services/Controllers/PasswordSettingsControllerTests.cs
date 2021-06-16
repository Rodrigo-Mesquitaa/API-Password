using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Password.Application.Dtos;
using Password.Application.Interfaces;
using Password.Services_Api.Controllers;
using System.Diagnostics.CodeAnalysis;

namespace Password.Test.Unit.Services.Controllers
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PasswordSettingsControllerTests
    {
        private Mock<IApplicationServiceSettingsPassword> _applicationServiceSettingsPasswordMock;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _applicationServiceSettingsPasswordMock = new Mock<IApplicationServiceSettingsPassword>();
            _fixture = new Fixture();
        }

        [Test]
        public void GetPasswordSettings_When_GetSettings_ShouldReturnOkObjectResult()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 2)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 30)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            _applicationServiceSettingsPasswordMock.Setup(x => x.GetSettingsPassword()).Returns(passwordsSettingsDto);

            var passwordSettingsController =
                new PasswordSettingsController(_applicationServiceSettingsPasswordMock.Object);

            //Act
            var actionResult = passwordSettingsController.GetPasswordSettings();

            //Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);
            _applicationServiceSettingsPasswordMock.Verify(x => x.GetSettingsPassword(), Times.Once);
        }

        [Test]
        public void
            CreatePasswordSettings_When_AddSettingsPassword_Then_ConfigurationExists_Is_False_ShouldReturnOkObjectResult()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 2)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 30)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            var resultDto = _fixture.Build<ResultDto>()
                .With(x => x.Text, "A configuração do password foi cadastrado com sucesso!")
                .With(x => x.ConfigurationExists, false)
                .Create();

            _applicationServiceSettingsPasswordMock.Setup(x => x.AddSettingsPassword(passwordsSettingsDto))
                .Returns(resultDto);

            var passwordSettingsController =
                new PasswordSettingsController(_applicationServiceSettingsPasswordMock.Object);

            //Act
            var actionResult = passwordSettingsController.CreatePasswordSettings(passwordsSettingsDto);

            //Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);
            _applicationServiceSettingsPasswordMock.Verify(x => x.AddSettingsPassword(passwordsSettingsDto),
                Times.Once);
        }

        [Test]
        public void
            CreatePasswordSettings_When_AddSettingsPassword_Then_ConfigurationExists_Is_True_ShouldReturnBadRequestObjectResult()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 2)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 30)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            var resultDto = _fixture.Build<ResultDto>()
                .With(x => x.Text,
                    "Não foi possivel adiconar a configuração, pois já possui uma configuração de senha cadastrado na base de dados!")
                .With(x => x.ConfigurationExists, true)
                .Create();

            _applicationServiceSettingsPasswordMock.Setup(x => x.AddSettingsPassword(passwordsSettingsDto))
                .Returns(resultDto);

            var passwordSettingsController =
                new PasswordSettingsController(_applicationServiceSettingsPasswordMock.Object);

            //Act
            var actionResult = passwordSettingsController.CreatePasswordSettings(passwordsSettingsDto);

            //Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), actionResult);
            _applicationServiceSettingsPasswordMock.Verify(x => x.AddSettingsPassword(passwordsSettingsDto),
                Times.Once);
        }

        [Test]
        public void UpdatePasswordSettings_When_ShouldReturnOkObjectResult()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 2)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 30)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            var result = "Foi atualizado com sucesso a configuração do password com sucesso!";

            _applicationServiceSettingsPasswordMock.Setup(x => x.UpdatePasswordSettings(passwordsSettingsDto))
                .Returns(result);

            var passwordSettingsController =
                new PasswordSettingsController(_applicationServiceSettingsPasswordMock.Object);

            //Act
            var actionResult = passwordSettingsController.UpdatePasswordSettings(passwordsSettingsDto);

            //Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);
            _applicationServiceSettingsPasswordMock.Verify(x => x.UpdatePasswordSettings(passwordsSettingsDto),
                Times.Once);
        }

        [Test]
        public void RemovePasswordSettings_When_ShouldReturnOkObjectResult()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 2)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 30)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            var result = "Foi removido com sucesso a configuração do password com sucesso!";

            _applicationServiceSettingsPasswordMock.Setup(x => x.RemovePasswordSettings(passwordsSettingsDto))
                .Returns(result);

            var passwordSettingsController =
                new PasswordSettingsController(_applicationServiceSettingsPasswordMock.Object);

            //Act
            var actionResult = passwordSettingsController.RemovePasswordSettings(passwordsSettingsDto);

            //Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);
            _applicationServiceSettingsPasswordMock.Verify(x => x.RemovePasswordSettings(passwordsSettingsDto),
                Times.Once);
        }
    }
}