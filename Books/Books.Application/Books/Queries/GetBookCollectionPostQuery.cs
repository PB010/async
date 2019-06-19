using Books.Application.Books.Models;
using Books.Application.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Application.Books.Queries
{
    public class GetBookCollectionPostQuery : IRequest<IEnumerable<BookDto>>
    {
        public IEnumerable<Guid> Ids { get; set; }
    }

    public class GetCollectionPostQuery : IRequestHandler<GetBookCollectionPostQuery, IEnumerable<BookDto>>
    {
        private readonly IBooksService _service;

        public GetCollectionPostQuery(IBooksService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBookCollectionPostQuery request,
            CancellationToken cancellationToken)
        {
            var booksFromDb = await _service.GetBookCollectionAsync(request.Ids);
            return booksFromDb.Select(BookDto.ConvertToBookDto); ;
        }
    }

    public class GetBooksCollectionPostValidator : AbstractValidator<GetBookCollectionPostQuery>
    {
        public GetBooksCollectionPostValidator()
        {
            RuleFor(x => x.Ids).NotEmpty()
                .WithMessage("Please provide the book Id's for the books you want to get," +
                             " if you want to return all books use /api/books/");
        }
    }
}
