using System;
using BookStore.Domain;
using Microsoft.Extensions.Logging;

namespace BookStore.Application.Events {
    public class ApplicationEventTriggers {
        private readonly ILogger<ApplicationEventTriggers> logger;

        /// <summary>
        /// This event is called whenever a new <see cref="Author"/> was
        /// successfully added.
        /// </summary>
        public event EventHandler AuthorAdded;
        
        public ApplicationEventTriggers(ILogger<ApplicationEventTriggers> logger) {
            this.logger = logger;
        }

        internal void OnAuthorAdded(object caller) {
            Console.WriteLine($"{GetExecutingMethod(nameof(OnAuthorAdded))} executed");
            logger.LogInformation($"Executed by caller {caller.GetType()}");
            
            EventHandler handler = AuthorAdded;
            handler?.Invoke(caller, EventArgs.Empty);
        }

        private static string GetExecutingMethod(string methodName) => $"{typeof(ApplicationEventTriggers)}.{methodName}";
    }
}