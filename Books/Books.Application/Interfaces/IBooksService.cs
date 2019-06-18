using Books.Application.Books.Models;
using Books.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(Guid id);
        void AddBook(Book bookToAdd);
        Task<bool> SaveChangesAsync();
    }
}
