using System.Linq;
using AutoMapper;
using BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthorDetail;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.AuthorOprations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
             var author = _mapper.Map<Author>(Model);

            _context.Authors.Add(author);

            _context.SaveChanges();

            return _mapper.Map<AuthorDetailViewModel>(author);
        }
    }
}