using Books.Application.Interfaces;
using Books.Persistence.Models;
using FluentValidation;
using MediatR;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Application.Books.Commands
{
    public class AddNewBookCommand : IRequest<Guid>
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public static Expression<Func<AddNewBookCommand, Book>> Projection
        {
            get
            {
                return p => new Book
                {
                    Id = new Guid(),
                    AuthorId = p.AuthorId,
                    Description = p.Description,
                    Title = p.Title
                };
            }
        }

        public static Book ConvertToBook(AddNewBookCommand command)
        {
            return Projection.Compile().Invoke(command);
        }
    }

    public class AddBookCommandHandler : IRequestHandler<AddNewBookCommand, Guid>
    {
        private readonly IBooksService _service;

        public AddBookCommandHandler(IBooksService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(AddNewBookCommand request, CancellationToken cancellationToken)
        {
            var bookForDb = AddNewBookCommand.ConvertToBook(request);

            _service.AddBook(bookForDb);
            await _service.SaveChangesAsync();
            
            
            return bookForDb.Id;
        }
    }
    

    public class AddNewBookValidator : AbstractValidator<AddNewBookCommand>
    {
        public AddNewBookValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Author Id is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        }
    }
}
