using System;

namespace BookStoreWebApi.Application.AuthorOprations.Commands.UpdateAuthor
{
    public class UpdateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}