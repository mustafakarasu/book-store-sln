using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOprations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}