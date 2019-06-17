using Books.Application.Interfaces;
using Books.Persistence.Contexts;
using Books.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Infrastructure.Services
{
    public class BooksService : IBooksService, IDisposable
    {
        private BookDbContext _context;

        public BooksService(BookDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.Include(b => b.Author).ToList();
        }

        public Book GetBook(Guid id)
        {
            return _context.Books.Include(b => b.Author)
                .SingleOrDefault(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var bookFromDb =  await _context.Books.Include(b => b.Author)
                .SingleOrDefaultAsync(b => b.Id == id);

            return bookFromDb;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
