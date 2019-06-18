using Books.Application.Books.Models;
using Books.Application.Interfaces;
using Books.Persistence.Contexts;
using FluentValidation;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Application.Books.Queries
{
    public class GetBookQuery : IRequest<BookDto>
    {
        public Guid Id { get; set; }
    }

    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IBooksService _service;

        public GetBookQueryHandler(IBooksService service)
        {
            _service = service;
        }
        
        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var bookFromDb = await _service.GetBookAsync(request.Id);
            var bookToReturn = BookDto.ConvertToBookDto(bookFromDb);

            return bookToReturn;
        }
    }

    public class GetBookValidator : AbstractValidator<GetBookQuery>
    {
        public GetBookValidator(BookDbContext context)
        {
            RuleFor(x => x.Id).Must(x => context.Books.Any(c => c.Id == x))
                .WithMessage("There is no such book.");
        }
    }
}
