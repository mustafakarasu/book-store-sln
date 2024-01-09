using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).SingleOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}