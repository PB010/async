using Books.Persistence.Models;
using System;
using System.Linq.Expressions;
using MediatR;

namespace Books.Application.Books.Models
{
    public class BookDto : IRequest
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static Expression<Func<Book, BookDto>> Projection
        {
            get
            {
                return p => new BookDto()
                {
                    Id = p.Id,
                    Author = $"{p.Author.FirstName} {p.Author.LastName}",
                    Description = p.Description,
                    Title = p.Title,
                };
            }
        }

        public static BookDto ConvertToBookDto(Book book)
        {
            return Projection.Compile().Invoke(book);
        }

    }
}
