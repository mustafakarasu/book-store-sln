using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebApi.Application.AuthorOprations.Commands.UpdateAuthor;
using BookStoreWebApi.Application.AuthorOprations.Commands.UpdateAuthor;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("", "")]
        [InlineData("Ad", "")]
        [InlineData("", "Soyad")]
        public void WhenInvalidStringInputsAreGiven_Validator_ShouldBeReturnErrors(string firstName, string lastName)
        {
            //arrange
            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);

            command.Model = new UpdateAuthorModel() { FirstName = firstName, LastName = lastName, DateOfBirth = DateTime.Now.AddYears(-11) };
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenAgeIsGivenLowerThanTen_Validator_ShouldBeReturnError()
        {
            //arrange
            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);

            command.Model = new UpdateAuthorModel() { FirstName = "Yazar Adı", LastName = "Yazar Soyadı", DateOfBirth = DateTime.Now.AddYears(-5) };
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
