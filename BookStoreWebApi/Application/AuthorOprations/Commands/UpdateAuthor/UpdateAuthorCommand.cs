using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.AuthorOprations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public UpdateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.AsNoTracking().SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı");

            var mappedEntity = _mapper.Map<Author>(Model);
            mappedEntity.Id = AuthorId;
            _context.Authors.Update(mappedEntity);
            _context.SaveChanges();
        }
    }
}