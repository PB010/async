using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Application.Books.Commands;
using Books.Persistence.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("/api/bookCollections")]
    [ApiController]
    public class BookCollectionsController : BaseController
    {
        public BookCollectionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IEnumerable<Book>> AddMultipleBooks(
            [FromBody] IEnumerable<AddNewBookCommand> command)
        {

        }
    }
}
