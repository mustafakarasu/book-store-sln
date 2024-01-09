using System;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOprations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
          RuleFor(x => x.Model.FirstName).NotEmpty();
          RuleFor(x => x.Model.LastName).NotEmpty();
          RuleFor(x => x.Model.DateOfBirth)
              .Must(date => date <= DateTime.Now.AddYears(-10))
              .WithMessage("Yazar 10 yaþýndan büyük olmalýdýr.");
        }
    }
}