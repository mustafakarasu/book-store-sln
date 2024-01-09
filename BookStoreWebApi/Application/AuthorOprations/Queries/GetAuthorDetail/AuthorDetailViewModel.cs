using System;
using BookStoreWebApi.Application.BookOperations.Queries.GetBookDetail;

namespace BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthorDetail
{
    public class AuthorDetailViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BookDetailViewModel Book { get; set; }
    }
}