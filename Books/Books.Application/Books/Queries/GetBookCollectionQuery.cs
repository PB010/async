using Books.Application.Books.Models;
using Books.Application.Interfaces;
using Books.Persistence.Contexts;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Application.Books.Queries
{
    public class GetBookCollectionQuery : IRequest<IEnumerable<BookDto>>
    {
        public IEnumerable<Guid> Ids { get; set; }
    }

    public class GetBookCollectionHandler : IRequestHandler<GetBookCollectionQuery, IEnumerable<BookDto>>
    {
        private readonly IBooksService _service;

        public GetBookCollectionHandler(IBooksService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetBookCollectionQuery request, CancellationToken cancellationToken)
        {
            if (request.Ids == null)
            {
                var allBooks = await _service.GetAllBooksAsync();
                var ifNullToReturn = allBooks.Select(BookDto.ConvertToBookDto);
                return ifNullToReturn;
            }

            var booksFromDb = await _service.GetBookCollectionAsync(request.Ids);

            var bookToReturn = booksFromDb.Select(BookDto.ConvertToBookDto);

            return bookToReturn;
        }
    }

    public class GetBookCollectionValidator : AbstractValidator<GetBookCollectionQuery>
    {
        public GetBookCollectionValidator(BookDbContext context)
        {
            When(x => x.Ids != null, () =>
            {
                RuleFor(x => x.Ids)
                    .Must(x => x.All(y => context.Books.Any(z => z.Id == y)))
                    .WithMessage("Some of the id's provided are not valid.");
            });
        }
    }
}
