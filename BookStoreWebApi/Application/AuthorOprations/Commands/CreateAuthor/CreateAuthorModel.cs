using System;

namespace BookStoreWebApi.Application.AuthorOprations.Commands.CreateAuthor
{
    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}