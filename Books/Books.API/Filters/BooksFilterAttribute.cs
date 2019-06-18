using AutoMapper;
using Books.Application.Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class BooksFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction.Value == null
                || resultFromAction.StatusCode < 200
                || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }

            //if (resultFromAction.Value is IEnumerable)
            //{
            //    //mapping code
            //}


            resultFromAction.Value = Mapper.Map<BookDto>(resultFromAction.Value);
            await next();
        }

        
    }
}
