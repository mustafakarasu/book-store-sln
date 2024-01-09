using System;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOprations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).NotEmpty();
            RuleFor(x => x.Model.LastName).NotEmpty();
            RuleFor(x => x.Model.DateOfBirth)
                .Must(date => date <= DateTime.Now.AddYears(-10))
                .WithMessage("Yazar 10 yaþýndan büyük olmalýdýr.");
        }
    }
}