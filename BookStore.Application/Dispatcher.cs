using System;
using System.Linq;
using System.Reflection;

namespace BookStore.Application {
    public class Dispatcher {
        
        public Dispatcher() {
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : class {
            Type handler = typeof(ICommandHandler<>);
            Type handlerType = handler.MakeGenericType(command.GetType());

            Type[] concreteType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Contains(handlerType))
                .ToArray();

            if (!concreteType.Any()) return;
            
            foreach (Type type in concreteType) {
                var concreteHandler = Activator.CreateInstance(type) as ICommandHandler<TCommand>;
                concreteHandler?.Handle(command);
            }
        }
    }

    public interface ICommandHandler<TCommand> where TCommand : class {
        public void Handle(TCommand command);
    }
    
    public class CreateAuthorCommand {
        public string AuthorName { get; set; }
    }
    
    public class CreateAuthorHandler : ICommandHandler<CreateAuthorCommand> {
        public void Handle(CreateAuthorCommand command) {
            Console.WriteLine($"{command.AuthorName} should be added to authors (Just a test command)");
        }
    }
}