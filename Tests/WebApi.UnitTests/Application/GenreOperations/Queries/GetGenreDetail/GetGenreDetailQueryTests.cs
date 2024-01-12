using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using TestSetup;
using Xunit;


namespace WebApi.UnitTests.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var genre = new Genre() { Name = "Genre Adı", IsActive = true};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            GetGenreDetailQuery command = new GetGenreDetailQuery(_context,_mapper);
            command.GenreId = genre.Id + 100;
            command.IsActive = true;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı.");
        }
    }
}
