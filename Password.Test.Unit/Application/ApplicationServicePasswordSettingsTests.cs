using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Password.Application;
using Password.Application.Dtos;
using Password.Domain;
using Password.Domian.Core.Interfaces.Services;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Password.Test.Unit.Application
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ApplicationServicePasswordSettingsTests
    {
        private Mock<IServicePasswordSettings> _servicePasswordSettingsMock;
        private Mock<IMapper> _mapperMock;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _servicePasswordSettingsMock = new Mock<IServicePasswordSettings>();
            _mapperMock = new Mock<IMapper>();
            _fixture = new Fixture();
        }

        [Test]
        public void AddSettingsPassword_When_NotExistsConfigurationPassword_ShouldReturnResultDto()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 1)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 20)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            var applicationServicePasswordSettings =
                new ApplicationServicePasswordSettings(_servicePasswordSettingsMock.Object, _mapperMock.Object);

            //Act
            var resultDto = applicationServicePasswordSettings.AddSettingsPassword(passwordsSettingsDto);

            //Assert
            Assert.IsNotNull(resultDto);
            Assert.AreEqual(
                "A configuração do password foi cadastrado com sucesso!",
                resultDto.Text);
            Assert.IsFalse(resultDto.ConfigurationExists);

            _servicePasswordSettingsMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void AddSettingsPassword_When_ExistsConfigurationPasswordShouldReturnResultDto()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 1)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 20)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            var passwordsSettings = _fixture.Build<PasswordSettings>()
                .With(x => x.Id, 1)
                .With(x => x.DateRegister, DateTime.Now)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 20)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .CreateMany(1);

            var applicationServicePasswordSettings =
                new ApplicationServicePasswordSettings(_servicePasswordSettingsMock.Object, _mapperMock.Object);

            _servicePasswordSettingsMock.Setup(x => x.GetAll()).Returns(passwordsSettings);

            //Act
            var resultDto = applicationServicePasswordSettings.AddSettingsPassword(passwordsSettingsDto);

            //Assert
            Assert.IsNotNull(resultDto);
            Assert.AreEqual(
                "Não foi possivel cadastrar a configuração, pois já possui uma configuração de senha cadastrado na base de dados!",
                resultDto.Text);
            Assert.IsTrue(resultDto.ConfigurationExists);

            _servicePasswordSettingsMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void RemovePasswordSettings_ShouldReturnResultOk()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 1)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 20)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            var applicationServicePasswordSettings =
                new ApplicationServicePasswordSettings(_servicePasswordSettingsMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServicePasswordSettings.RemovePasswordSettings(passwordsSettingsDto);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(
                "Foi removido com sucesso a configuração do password com sucesso!",
                result);
        }

        [Test]
        public void UpdatePasswordSettings_ShouldReturnResultOk()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 1)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 20)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            var applicationServicePasswordSettings =
                new ApplicationServicePasswordSettings(_servicePasswordSettingsMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServicePasswordSettings.UpdatePasswordSettings(passwordsSettingsDto);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(
                "Foi atualizado com sucesso a configuração do password com sucesso!",
                result);
        }
    }
}