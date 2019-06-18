using Books.Application.Books.Models;
using Books.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Application.Books.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }

    public class GetBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBooksService _service;

        public GetBooksQueryHandler(IBooksService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request,
            CancellationToken cancellationToken)
        {
            var booksFromDb = await _service.GetAllBooksAsync();
            var booksToReturn = booksFromDb.Select(BookDto.ConvertToBookDto).ToList();

            return booksToReturn;
        }
    }
}
