using FluentValidation;

namespace BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}