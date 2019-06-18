using System;
using Books.Application.Books.Commands;
using Books.Application.Books.Models;
using Books.Application.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Persistence.Models;

namespace Books.API.Controllers
{
    [Route("/api/books/")]
    [ApiController]
    public class BooksController : BaseController
    {
        public BooksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            return await _mediator.Send(new GetAllBooksQuery());
        }

        [HttpGet("{id}")]
        public async Task<BookDto> GetBook([FromRoute] GetBookQuery id)
        {
            return await _mediator.Send(id);
        }

        [HttpPost]
        public async Task<Guid> AddBook([FromBody] AddNewBookCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
