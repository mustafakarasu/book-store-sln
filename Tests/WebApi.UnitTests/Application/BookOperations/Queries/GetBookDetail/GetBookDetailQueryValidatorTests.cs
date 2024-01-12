using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TestSetup;
using Xunit;
using BookStoreWebApi.Application.BookOperations.Queries.GetBookDetail;
using AutoMapper;
using BookStoreWebApi.DBOperations;

namespace WebApi.UnitTests.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailQueryValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenBookIdIsGivenLowerThanZero_Validator_ShouldBeReturnError(int bookId)
        {
            //arrange
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);

            query.BookId = bookId;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            var errors = validator.Validate(query);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
