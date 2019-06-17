using System;
using Books.Application.Interfaces;
using Books.Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Application.Books.Models;
using Books.Application.Books.Queries;
using MediatR;

namespace Books.API.Controllers
{
    [Route("/api/booksSync")]
    [ApiController]
    public class BooksControllerSync : BaseController
    {
        [HttpGet]
        public Task<List<BookDto>> GetBooks()
        {
            return _mediator.Send(new GetAllBooksSyncQuery());
        }

        public BooksControllerSync(IMediator mediator) : base(mediator)
        {
        }
    }
}
