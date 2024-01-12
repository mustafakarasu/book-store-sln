using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebApi.Application.AuthorOprations.Commands.UpdateAuthor;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistAuthorTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var author = new Author() { FirstName = "Yazar Adı", LastName = "Yazar Soyadı", DateOfBirth = DateTime.Now.AddYears(-15) };
            _context.Authors.Add(author);
            _context.SaveChanges();

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
            command.AuthorId = author.Id + 10;
            command.Model = new UpdateAuthorModel() { FirstName = author.FirstName, LastName = author.LastName, DateOfBirth = author.DateOfBirth};

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
        }
    }
}
