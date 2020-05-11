using System;
using BookStore.Application.Interfaces;
using BookStore.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.DataLayer.Extensions {
    public static class ServicesExtension {
        public static IServiceCollection AddBookStoreDatabase(this IServiceCollection services, string connectionString) {
            services.AddDbContext<BookStoreContext>(options => {
                options.UseSqlServer(connectionString);
            });

            var context = services.BuildServiceProvider().GetRequiredService<BookStoreContext>();
            try {
                bool result = context.Database.CanConnect();
                if (!result) throw new InvalidOperationException("Cannot connect to database");
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            return services;
        }
    }
}