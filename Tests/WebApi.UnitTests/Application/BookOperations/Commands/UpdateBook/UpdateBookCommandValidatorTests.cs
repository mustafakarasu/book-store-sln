using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord Of The", 0, 0)]
        [InlineData("", 0, 0)]
        [InlineData("", 0, 1)]
        [InlineData("", 100, 1)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lord", 0, 1)]
        [InlineData("Lord", 100, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(null);

            command.Model = new UpdateBookModel() { Title  = title, PageCount = pageCount, PublishDate = DateTime.Now.AddDays(-10), GenreId = genreId };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(null);

            command.Model = new UpdateBookModel() { Title = "Lord Of The Rings", PageCount = 100, PublishDate = DateTime.Now, GenreId = 1 };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
