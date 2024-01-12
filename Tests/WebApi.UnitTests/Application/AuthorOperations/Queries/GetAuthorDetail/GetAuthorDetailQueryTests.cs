using System;
using AutoMapper;
using BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthorDetail;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Author() { FirstName = "Yazar Adı", LastName = "Yazar Soyadı", DateOfBirth = DateTime.Now.AddYears(-15) };
            _context.Authors.Add(book);
            _context.SaveChanges();

            GetAuthorDetailQuery command = new GetAuthorDetailQuery(_context,_mapper);
            command.AuthorId = book.Id + 100;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı.");
        }
    }
}
