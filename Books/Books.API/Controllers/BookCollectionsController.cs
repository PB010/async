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
    [Route("/api/bookCollections")]
    [ApiController]
    public class BookCollectionsController : BaseController
    {
        public BookCollectionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBookCollection(
            //[ModelBinder(BinderType = typeof(ArrayModelBinder))]
            [FromQuery]GetBookCollectionQuery bookIds)
        {
            return await _mediator.Send(bookIds);
        }

        [HttpPost("/getCollection/")]
        public async Task<IEnumerable<BookDto>> GetBookCollectionViaPost(
            [FromBody] GetBookCollectionPostQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<IEnumerable<Guid>> AddMultipleBooks(
            [FromBody] AddBookCollectionCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
