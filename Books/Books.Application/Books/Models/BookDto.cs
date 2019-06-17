using Books.Persistence.Models;
using System;
using System.Linq.Expressions;

namespace Books.Application.Books.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public static Expression<Func<Book, BookDto>> Projection
        {
            get
            {
                return p => new BookDto
                {
                    Id = p.Id,
                    Author = p.Author,
                    AuthorId = p.AuthorId,
                    Description = p.Description,
                    Title = p.Title
                };
            }
        }

        public static BookDto Convert(Book book)
        {
            return Projection.Compile().Invoke(book);
        }
    }
}
