using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.DBOperations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebApi.Application.BookOperations.Queries.GetBookDetail;
using TestSetup;
using Xunit;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Entities;

namespace WebApi.UnitTests.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Book() { Title = "Test Verisi", PageCount = 1000, PublishDate = new DateTime(1990, 01, 20), GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            GetBookDetailQuery command = new GetBookDetailQuery(_context,_mapper);
            command.BookId = book.Id + 100;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");
        }
    }
}
