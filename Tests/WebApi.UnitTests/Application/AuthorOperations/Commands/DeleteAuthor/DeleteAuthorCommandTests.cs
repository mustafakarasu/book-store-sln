using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebApi.Application.AuthorOprations.Commands.DeleteAuthor;
using BookStoreWebApi.DBOperations;
using FluentValidation;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(100)]
        [InlineData(150)]
        public void WhenThereIsNoAuthor_InvalidOperationException_ShouldBeReturn(int authorId)
        {
            //arrange
            DeleteAuthorCommand deleteCommand = new DeleteAuthorCommand(_context);
            deleteCommand.AuthorId = authorId;

            //act & assert
            FluentActions.Invoking(() => deleteCommand.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadı"); ;
        }
    }
}
