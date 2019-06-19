using AutoMapper;
using Books.Application;
using Books.Application.Books.Queries;
using Books.Application.Interfaces;
using Books.Infrastructure.Services;
using Books.Persistence.Contexts;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Books.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetBookValidator>());
            services.AddDbContext<BookDbContext>(o => o.UseSqlServer(
                Configuration["ConnectionStrings:BookDBConnectionString"],
                b => b.MigrationsAssembly(typeof(BookDbContext).GetTypeInfo().Assembly
                    .GetName().Name)));
            services.AddScoped<IBooksService, BooksService>();
            services.AddMediatR(typeof(GetAllBooksQuery));
            services.AddAutoMapper(typeof(BookProfile));
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BookDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
