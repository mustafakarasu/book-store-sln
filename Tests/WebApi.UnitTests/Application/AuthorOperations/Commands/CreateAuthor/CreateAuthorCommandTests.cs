using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.Application.AuthorOprations.Commands.CreateAuthor;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            //arrenge
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            CreateAuthorModel model = new CreateAuthorModel() { FirstName = "Yazar Adý", LastName = "Yazar Soyadý", DateOfBirth = DateTime.Now.AddYears(-15)};
            command.Model = model;

            //act
            var result = FluentActions.Invoking(() => command.Handle()).Invoke();

            var author = _context.Authors.SingleOrDefault(author => author.Id == result.Id);

            //assert
            author.Should().NotBeNull();
            author.FirstName.Should().Be(model.FirstName);
            author.LastName.Should().Be(model.LastName);
        }
    }
}