using AutoMapper;
using BookStoreWebApi.Application.AuthorOprations.Commands.CreateAuthor;
using BookStoreWebApi.Application.AuthorOprations.Commands.DeleteAuthor;
using BookStoreWebApi.Application.AuthorOprations.Commands.UpdateAuthor;
using BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthorDetail;
using BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthors;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Queries.GetBookDetail;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebApi.Application.UserOperations.Commands.Create;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateUserModel, User>();

            CreateMap<CreateAuthorModel, Author>().ReverseMap();
            CreateMap<AuthorDetailViewModel, Author>().ReverseMap();
            CreateMap<AuthorsViewModel, Author>().ReverseMap();
            CreateMap<UpdateAuthorModel, Author>().ReverseMap();
        }
    }

}