using Books.Application.Books.Commands;
using Books.Application.Books.Models;
using Books.Application.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<BookDto> GetBook([FromRoute] Guid id)
        {
            return await _mediator.Send(new GetBookQuery {Id = id});
        }

        [HttpPost]
        public async Task<Guid> AddBook([FromBody] AddNewBookCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
