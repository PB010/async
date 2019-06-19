using Books.Application.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Application.Books.Commands
{
    public class AddBookCollectionCommand : IRequest<IEnumerable<Guid>>
    {
        public List<AddNewBookCommand> ListOfBooks { get; set; }
    }

    public class AddCollectionHandler : IRequestHandler<AddBookCollectionCommand, IEnumerable<Guid>>
    {
        private readonly IBooksService _service;

        public AddCollectionHandler(IBooksService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<Guid>> Handle(AddBookCollectionCommand request,
            CancellationToken cancellationToken)
        {
            var booksForDb = request.ListOfBooks.Select(AddNewBookCommand.ConvertToBook).ToList();

            foreach (var book in booksForDb)
            {
                _service.AddBook(book);
            }

            await _service.SaveChangesAsync();

            var id = booksForDb.Select(b => b.Id);

            return id;
        }
    }

    public class AddCollectionValidator : AbstractValidator<AddBookCollectionCommand>
    {
        public AddCollectionValidator()
        {
            RuleFor(x => x.ListOfBooks).NotEmpty()
                .WithMessage("Please provide the list of books you wish to add.");
        }
    }
}
