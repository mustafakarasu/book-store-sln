using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Queries.GetBookDetail;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _context.Authors
                .Include(x => x.Books)
                        .OrderBy(x => x.Id).ToList();

            List<AuthorsViewModel> obj = _mapper.Map<List<AuthorsViewModel>>(authorList);

            return obj;
        }
    }

    public class AuthorsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BookDetailViewModel Book { get; set; }
    }
}