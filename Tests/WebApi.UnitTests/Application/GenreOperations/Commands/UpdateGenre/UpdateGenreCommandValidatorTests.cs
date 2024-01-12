using System;
using BookStoreWebApi.Application.GenreOperations.Commands.UpdateGenre;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    
    public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Gen")]
        [InlineData("G")]
        [InlineData("Ge")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            //arrange
            UpdateGenreCommand command = new UpdateGenreCommand(null);

            command.Model = new UpdateGenreModel() { Name = name, IsActive = true};
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }

    }
}
