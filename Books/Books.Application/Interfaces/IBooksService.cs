using Books.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAllBooks();  
        Book GetBook(Guid id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(Guid id);   
    }
}
