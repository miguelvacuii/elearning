
using System.Collections.Generic;
using elearning.src.Shared.Infrastructure.Bus.Command.Middleware;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Domain.Bus.Command.Middleware;
using elearning.src.Shared.Infrastructure.Helper;

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
            string commandhandlerFullName = ObjectProperties.GetObjectFullName(commandHandler);
            commandHandlers.Add(commandhandlerFullName, commandHandler);
        }

        public void AddMiddleware(IMiddlewareHandler middlewareHandler)
        {
            middlewareHandlers.Add(middlewareHandler);
        }

        public void Dispatch(ICommand command)
        {
            string requestNamespace = ObjectProperties.GetObjectNamespace(command);
            string requestName = ObjectProperties.GetObjectName(command);
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
    }
}

