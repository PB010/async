using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Books.Application.Books.Models;
using Books.Application.Interfaces;
using MediatR;

namespace Books.Application.Books.Queries
{
    public class GetAllBooksSyncQuery : IRequest<List<BookDto>>
    {
    }

    public class GetBooksSyncQueryHandler : IRequestHandler<GetAllBooksSyncQuery, List<BookDto>>
    {
        private readonly IBooksService _service;

        public GetBooksSyncQueryHandler(IBooksService service)
        {
            _service = service;
        }
        public Task<List<BookDto>> Handle(GetAllBooksSyncQuery request,
            CancellationToken cancellationToken)
        {
            var booksFromDb =  _service.GetAllBooks();
            var booksToReturn = booksFromDb.Select(BookDto.Convert).ToList();

            return Task.FromResult(booksToReturn);
        }
    }
}
