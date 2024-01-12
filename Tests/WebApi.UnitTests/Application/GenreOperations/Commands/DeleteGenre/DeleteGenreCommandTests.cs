using System;
using AutoMapper;
using BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre;
using BookStoreWebApi.DBOperations;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(100)]
        [InlineData(150)]
        public void WhenThereIsNoGenre_InvalidOperationException_ShouldBeReturn(int genreId)
        {
            //arrange
            DeleteGenreCommand deleteCommand = new DeleteGenreCommand(_context);
            deleteCommand.GenreId = genreId;

            //act & assert
            FluentActions.Invoking(() => deleteCommand.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı"); ;
        }
    }
}
