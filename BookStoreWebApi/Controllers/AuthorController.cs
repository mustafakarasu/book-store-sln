using System.Linq;
using AutoMapper;
using BookStoreWebApi.Application.AuthorOprations.Commands.CreateAuthor;
using BookStoreWebApi.Application.AuthorOprations.Commands.DeleteAuthor;
using BookStoreWebApi.Application.AuthorOprations.Commands.UpdateAuthor;
using BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthorDetail;
using BookStoreWebApi.Application.AuthorOprations.Queries.GetAuthors;
using BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre;
using BookStoreWebApi.Application.GenreOperations.Commands.UpdateGenre;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public ActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;

            var result = command.Handle();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
            command.AuthorId = id;
            command.Model = updateAuthor;

            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;

            command.Handle();
            return Ok();
        }

}
}
