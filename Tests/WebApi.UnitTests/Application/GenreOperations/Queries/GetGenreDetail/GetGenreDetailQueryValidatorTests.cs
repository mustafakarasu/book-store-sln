using AutoMapper;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreWebApi.DBOperations;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQueryValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenGenreIdIsGivenLowerThanZero_Validator_ShouldBeReturnError(int genreId)
        {
            //arrange
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);

            query.GenreId = genreId;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var errors = validator.Validate(query);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
