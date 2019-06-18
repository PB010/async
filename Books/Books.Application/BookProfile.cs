using AutoMapper;
using Books.Application.Books.Models;
using Books.Persistence.Models;

namespace Books.Application
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(
                    src => $"{src.Author.FirstName} {src.Author.LastName}"));
        }
    }
}
