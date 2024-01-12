using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebApi.Application.AuthorOprations.Commands.DeleteAuthor;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenInvalidAuthorIdInputsAreGiven_Validator_ShouldBeReturnErrors(int authorId)
        {
            //arrange
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);

            command.AuthorId = authorId;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
