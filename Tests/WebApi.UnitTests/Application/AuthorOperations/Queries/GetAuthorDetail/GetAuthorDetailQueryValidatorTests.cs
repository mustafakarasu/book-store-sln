using AutoMapper;
using BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthorDetail;
using BookStoreWebApi.DBOperations;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailQueryValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenAuthorIdIsGivenLowerThanZero_Validator_ShouldBeReturnError(int authorId)
        {
            //arrange
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);

            query.AuthorId = authorId;
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            var errors = validator.Validate(query);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
