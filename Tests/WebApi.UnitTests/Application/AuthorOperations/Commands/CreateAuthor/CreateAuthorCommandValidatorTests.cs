using System;
using BookStoreWebApi.Application.AuthorOprations.Commands.CreateAuthor;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("", "")]
        [InlineData("Ad", "")]
        [InlineData("", "Soyad")]
        public void WhenInvalidStringInputsAreGiven_Validator_ShouldBeReturnErrors(string firstName, string lastName)
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);

            command.Model = new CreateAuthorModel() { FirstName = firstName, LastName = lastName, DateOfBirth = DateTime.Now.AddYears(-11)};
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }

         [Fact]
        public void WhenAgeIsGivenLowerThanTen_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);

            command.Model = new CreateAuthorModel() { FirstName = "Yazar Adý", LastName = "Yazar Soyadý", DateOfBirth = DateTime.Now.AddYears(-5)};
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}