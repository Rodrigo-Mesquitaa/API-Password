using AutoFixture;
using AutoMapper;
using NUnit.Framework;
using Password.Application.Dtos;
using Password.Application.Mappers;
using Password.Domain;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Password.Test.Unit.Mapper
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MapperTests
    {
        private MapperConfiguration _mapperConfiguration;
        private Fixture _fixture;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<MapperPasswordSettings>());
            _fixture = new Fixture();
            _mapper = _mapperConfiguration.CreateMapper();
        }

        [Test]
        public void MapperPasswordSettings_Configuration_IsValid()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }

        [Test]
        public void
            MapperPasswordSettings_When_MapPasswordSettingsToPasswordSettingsDto_ShouldReturnPasswordSettingsDto()
        {
            //Arrange
            var passwordsSettings = _fixture.Build<PasswordSettings>()
                .With(x => x.Id, 2)
                .With(x => x.DateRegister, DateTime.Now)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 30)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            //Act
            var passwordsSettingsDto = _mapper.Map<PasswordSettingsDto>(passwordsSettings);

            //Assert
            Assert.IsNotNull(passwordsSettingsDto);
            Assert.AreEqual(passwordsSettings.Id, passwordsSettingsDto.Id);
            Assert.AreEqual(passwordsSettings.MinimumSize, passwordsSettingsDto.MinimumSize);
            Assert.AreEqual(passwordsSettings.MaximumSize, passwordsSettingsDto.MaximumSize);
            Assert.AreEqual(passwordsSettings.SpecialCharacterRequired, passwordsSettingsDto.SpecialCharacterRequired);
            Assert.AreEqual(passwordsSettings.StrongPasswordRequired, passwordsSettingsDto.StrongPasswordRequired);
        }
        [Test]
        public void
            MapperPasswordSettings_When_MapPasswordSettingsDtoToPasswordSettings_ShouldReturnPasswordSettings()
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 2)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 30)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            //Act
            var passwordsSettings = _mapper.Map<PasswordSettings>(passwordsSettingsDto);

            //Assert
            Assert.IsNotNull(passwordsSettingsDto);
            Assert.AreEqual(passwordsSettings.Id, passwordsSettingsDto.Id);
            Assert.AreEqual(passwordsSettings.MinimumSize, passwordsSettingsDto.MinimumSize);
            Assert.AreEqual(passwordsSettings.MaximumSize, passwordsSettingsDto.MaximumSize);
            Assert.AreEqual(passwordsSettings.SpecialCharacterRequired, passwordsSettingsDto.SpecialCharacterRequired);
            Assert.AreEqual(passwordsSettings.StrongPasswordRequired, passwordsSettingsDto.StrongPasswordRequired);
        }
    }
}