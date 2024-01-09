using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using FluentValidation;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(100)]
        [InlineData(150)]
        public void WhenThereIsNoBook_InvalidOperationException_ShouldBeReturn(int bookId)
        {
            //arrange
            DeleteBookCommand deleteCommand = new DeleteBookCommand(_context);
            deleteCommand.BookId = bookId;

            //act & assert
            FluentActions.Invoking(() => deleteCommand.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı"); ;
        }
    }
}
