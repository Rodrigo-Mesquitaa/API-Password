using AutoFixture;
using Moq;
using NUnit.Framework;
using Password.Application;
using Password.Application.Dtos;
using Password.Application.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Password.Test.Unit.Application
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ApplicationServicePasswordTests
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
        [TestCase("", ExpectedResult = false, TestName = "Password Invalid - Input Empty")]
        [TestCase("aa", ExpectedResult = false, TestName = "Password Invalid - Two characters - Input(aa) ")]
[TestCase("ab", ExpectedResult = false, TestName = "Password Invalid - Two characters - Input(ab)")]
        [TestCase("AAAbbbCc", ExpectedResult = false, TestName = "Password Invalid - Repeated characters - Input(AAAbbbCc)")]
        [TestCase("AbTp9!foo", ExpectedResult = false, TestName = "Password Invalid - Repeated characters and special characters - Input(AbTp9!foo)")]
        [TestCase("AbTp9!foA", ExpectedResult = false, TestName = "Password Invalid - Repeated characters and special characters - Input(AbTp9!foA)")]
        [TestCase("AbTp9 fok", ExpectedResult = false, TestName = "Password Invalid - Blank spaces should not be considered valid characters - Input(AbTp9 fok)")]
        [TestCase("AbTp9/fok", ExpectedResult = false, TestName = "Password Invalid - Invalid character special - Input(AbTp9/fok)")]
        [TestCase("AbTp9{fok", ExpectedResult = false, TestName = "Password Invalid - Invalid character special - Input(AbTp9{fok)")]
        [TestCase("AbTp9}fok", ExpectedResult = false, TestName = "Password Invalid - Invalid character special - Input(AbTp9}fok)")]
        [TestCase("AbTp9!fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9!fok)")]
        [TestCase("AbTp9@fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9@fok)")]
        [TestCase("AbTp9#fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9#fok)")]
        [TestCase("AbTp9$fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9$fok)")]
        [TestCase("AbTp9%fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9%fok)")]
        [TestCase("AbTp9^fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9^fok)")]
        [TestCase("AbTp9&fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9&fok)")]
        [TestCase("AbTp9*fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9*fok)")]
        [TestCase("AbTp9(fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9(fok)")]
        [TestCase("AbTp9)fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9)fok)")]
        [TestCase("AbTp9+fok", ExpectedResult = true, TestName = "Password Invalid - Valid characters - Input(AbTp9+fok)")]
        public bool PasswordValidation_When_PasswordValidation_Then_SpecialCharacterRequiredAndStrongPasswordRequired_Is_True_ShouldReturnTestCasesPass(string password)
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 1)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 20)
                .With(x => x.SpecialCharacterRequired, true)
                .With(x => x.StrongPasswordRequired, true)
                .Create();

            _applicationServiceSettingsPasswordMock.Setup(x => x.GetSettingsPassword()).Returns(passwordsSettingsDto);

            var applicationServicePassword =
                new ApplicationServicePassword(_applicationServiceSettingsPasswordMock.Object);
return applicationServicePassword.PasswordValidation(password);
        }

        [Test]
[TestCase("", ExpectedResult = false, TestName = "Password Invalid - Input Empty")]
        [TestCase("aa", ExpectedResult = true, TestName = "Password Invalid - Two characters - Input(aa) ")]
        [TestCase("ab", ExpectedResult = true, TestName = "Password Invalid - Two characters - Input(ab)")]
        [TestCase("AAAbbbCc", ExpectedResult = true, TestName = "Password Invalid - Repeated characters - Input(AAAbbbCc)")]
        [TestCase("AbTp9!foo", ExpectedResult = false, TestName = "Password Invalid - Repeated characters and special characters - Input(AbTp9!foo)")]
        [TestCase("AbTp9!foA", ExpectedResult = false, TestName = "Password Invalid - Repeated characters and special characters - Input(AbTp9!foA)")]
        [TestCase("AbTp9 fok", ExpectedResult = false, TestName = "Password Invalid - Blank spaces should not be considered valid characters - Input(AbTp9 fok)")]
        [TestCase("AbTp9!fok", ExpectedResult = false, TestName = "Password Invalid - Valid characters - Input(AbTp9!fok)")]
        public bool PasswordValidation_When_PasswordValidation_Then_SpecialCharacterRequiredAndStrongPasswordRequired_Is_False_ShouldReturnTestCasesPass(string password)
        {
            //Arrange
            var passwordsSettingsDto = _fixture.Build<PasswordSettingsDto>()
                .With(x => x.Id, 1)
                .With(x => x.MinimumSize, 9)
                .With(x => x.MaximumSize, 20)
                .With(x => x.SpecialCharacterRequired, false)
                .With(x => x.StrongPasswordRequired, false)
                .Create();

            _applicationServiceSettingsPasswordMock.Setup(x => x.GetSettingsPassword()).Returns(passwordsSettingsDto);

            var applicationServicePassword =
                new ApplicationServicePassword(_applicationServiceSettingsPasswordMock.Object);

            return applicationServicePassword.PasswordValidation(password);
        }
    }
}