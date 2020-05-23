using System;
using BookStore.Application.Events;
using BookStore.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookStore.Application.Extensions {
    public static class ServicesExtension {
        public static IServiceCollection AddEvents(this IServiceCollection services, Action<ApplicationEventTriggers> action = null) {
            services.AddScoped<GetAuthors>();
            services.AddScoped<CreateAuthor>();
            services.AddScoped<Dispatcher>();
            services.AddScoped<ValidateCreateAuthorInput>();
            
            services.AddScoped(provider => {
                var events = new ApplicationEventTriggers(
                    provider.GetRequiredService<ILogger<ApplicationEventTriggers>>());
                action?.Invoke(events);
                
                return events;
            });

            return services;
        }
    }
}