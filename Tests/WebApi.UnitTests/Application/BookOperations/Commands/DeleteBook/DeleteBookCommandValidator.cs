using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenInvalidBookIdInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId)
        {
            //arrange
            DeleteBookCommand command = new DeleteBookCommand(null);

            command.BookId = bookId;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
