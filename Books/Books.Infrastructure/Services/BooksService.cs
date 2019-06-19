using Books.Application.External_Models;
using Books.Application.Interfaces;
using Books.Persistence.Contexts;
using Books.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Books.Infrastructure.Services
{
    public class BooksService : IBooksService, IDisposable
    {
        private BookDbContext _context;
        private readonly IHttpClientFactory _factory;

        public BooksService(BookDbContext context, IHttpClientFactory factory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
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

        public async Task<IEnumerable<Book>> GetBookCollectionAsync(IEnumerable<Guid> id)
        {
            return await _context.Books.Include(b => b.Author).
                Where(b => id.Contains(b.Id)).ToListAsync();
        }

        public void AddBook(Book bookToAdd)
        {
            if (bookToAdd == null)
                throw new ArgumentNullException(nameof(bookToAdd));

            _context.Add(bookToAdd);
            //var bookToReturn = BookDto.ConvertToBookDto(bookToAdd);
            
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<BookCover> GetBookCoverAsync(string coverId)
        {
            var httpClient = _factory.CreateClient();

            // pass through a dummy name
            var response = await httpClient
                .GetAsync($"http://localhost:44368/api/bookCovers/{coverId}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<BookCover>(
                    await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<IEnumerable<BookCover>> GetBookCoversAsync(Guid bookId)
        {
            var httpClient = _factory.CreateClient();
            var bookCovers = new List<BookCover>();

            // create a list of fake bookCovers
            var bookCoverUrls = new[]
            {
                $"http://localhost:44368/api/bookCovers/{bookId}-dummyCover1",
                $"http://localhost:44368/api/bookCovers/{bookId}-dummyCover2",
                $"http://localhost:44368/api/bookCovers/{bookId}-dummyCover3",
                $"http://localhost:44368/api/bookCovers/{bookId}-dummyCover4",
                $"http://localhost:44368/api/bookCovers/{bookId}-dummyCover5",
            };

            foreach (var bookCoverUrl in bookCoverUrls)
            {
                var response = await httpClient
                    .GetAsync(bookCoverUrl);

                if (response.IsSuccessStatusCode)
                {
                    bookCovers.Add(JsonConvert.DeserializeObject<BookCover>(
                        await response.Content.ReadAsStringAsync()));
                }
            }

            return bookCovers;
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
