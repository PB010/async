using Books.Application.External_Models;
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
        Task<IEnumerable<Book>> GetBookCollectionAsync(IEnumerable<Guid> id);
        void AddBook(Book bookToAdd);
        Task<bool> SaveChangesAsync();
        Task<BookCover> GetBookCoverAsync(string coverId);
        Task<IEnumerable<BookCover>> GetBookCoversAsync(Guid bookId);
    }
}
