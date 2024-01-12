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
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Book() { Title = "Test Verisi", PageCount = 1000, PublishDate = new DateTime(1990, 01, 20), GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = book.Id;
            command.Model = new UpdateBookModel() { Title = book.Title };

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isimle bir kitap mevcuttur.");
        }
    }
}
