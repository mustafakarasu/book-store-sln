using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.Application.BookOperations.Queries.GetBookDetail;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// This action get all books.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery command = new GetBooksQuery(_context, _mapper);
            var obj = command.Handle();
            return Ok(obj);
        }

        /// <summary>
        /// This action method get one book by book id.
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            BookDetailViewModel obj;

            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;

            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);

            obj = query.Handle();
            return Ok(obj);
        }


        /// <summary>
        /// This action method updates book entity by id.
        /// </summary>
        /// <param name="id">Updated book id value.</param>
        /// <param name="updateBook">Updated book model value.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {

            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updateBook;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        /// <summary>
        /// This action method creates book entity.
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}