using BookStore.Application.Events;
using BookStore.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application.Extensions {
    public static class ServicesExtension {
        public static IServiceCollection AddEvents(this IServiceCollection services) {
            services.AddScoped<GetAuthors>();
            services.AddScoped<CreateAuthor>();
            
            services.AddScoped<ValidateCreateAuthorInput>();

            return services;
        }
    }
}