using System;
using System.Linq;
using BookStoreWebApi.DBOperations;

namespace BookStoreWebApi.Application.AuthorOprations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _context;
        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");

            var isBooksOfAuthors = _context.Books.Any(x => x.AuthorId == AuthorId);

            if (isBooksOfAuthors)
            {
                throw new InvalidOperationException("Yazarın kitapları olduğundan yazar silinemez.");
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}