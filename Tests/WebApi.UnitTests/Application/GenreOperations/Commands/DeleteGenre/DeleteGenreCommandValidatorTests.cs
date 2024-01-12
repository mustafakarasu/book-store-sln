using BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenInvalidGenreIdInputsAreGiven_Validator_ShouldBeReturnErrors(int genreId)
        {
            //arrange
            DeleteGenreCommand command = new DeleteGenreCommand(null);

            command.GenreId = genreId;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
