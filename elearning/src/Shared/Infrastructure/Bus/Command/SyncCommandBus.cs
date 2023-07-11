
using System.Collections.Generic;
using elearning.src.Shared.Infrastructure.Bus.Command.Middleware;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Domain.Bus.Command.Middleware;

namespace elearning.src.Shared.Infrastructure.Bus.Command
{
    public class SyncCommandBus : ICommandBus
    {
        private Dictionary<string, ICommandHandler> commandHandlers;
        private List<IMiddlewareHandler> middlewareHandlers;

        public SyncCommandBus()
        {
            commandHandlers = new Dictionary<string, ICommandHandler>();
            middlewareHandlers = new List<IMiddlewareHandler>();

        }

        public void Subscribe(ICommandHandler commandHandler)
        {
            string commandhandlerFullName = GetObjectFullName(commandHandler);
            commandHandlers.Add(commandhandlerFullName, commandHandler);
        }

        public void AddMiddleware(IMiddlewareHandler middlewareHandler)
        {
            middlewareHandlers.Add(middlewareHandler);
        }

        public void Dispatch(ICommand command)
        {
            string requestNamespace = GetObjectNamespace(command);
            string requestName = GetObjectName(command);
            string commandHandlerName = requestName.Replace("Command", "CommandHandler");
            string commandHandlerFullName = requestNamespace + "." + commandHandlerName;

            ICommandHandler commandHandler = commandHandlers[commandHandlerFullName];

            IMiddlewareHandler middlewareHandler = new CommandHandlerMiddleware(commandHandler);
            middlewareHandler = LoadHandlers(middlewareHandler);
            middlewareHandler.Handle(command);
        }

        private IMiddlewareHandler LoadHandlers(IMiddlewareHandler middlewareHandler)
        {
            foreach (IMiddlewareHandler handler in middlewareHandlers)
            {
                handler.SetNext(middlewareHandler);
                middlewareHandler = handler;
            }

            return middlewareHandler;
        }

        // TO-DO refactorizar porque será código repetitivo al crer más commands
        public static string GetObjectFullName(object obj)
        {
            return obj.GetType().ToString();
        }

        public static string GetObjectNamespace(object obj)
        {
            return obj.GetType().Namespace;
        }

        public static string GetObjectName(object obj)
        {
            return obj.GetType().Name;
        }
    }
}

