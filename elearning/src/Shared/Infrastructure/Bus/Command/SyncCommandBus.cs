using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.Shared.Infrastructure.Bus.Command
{
    public class SyncCommandBus : ICommandBus
    {
        private Dictionary<string, ICommandHandler> commandHandlers;

        public SyncCommandBus()
        {
            commandHandlers = new Dictionary<string, ICommandHandler>();

        }

        public void Subscribe(ICommandHandler commandHandler)
        {
            string commandhandlerFullName = GetObjectFullName(commandHandler);
            commandHandlers.Add(commandhandlerFullName, commandHandler);
        }

        public void Dispatch(ICommand command)
        {
            string requestNamespace = GetObjectNamespace(command);
            string requestName = GetObjectName(command);
            string commandHandlerName = requestName.Replace("Command", "CommandHandler");
            string commandHandlerFullName = requestNamespace + "." + commandHandlerName;

            ICommandHandler commandHandler = commandHandlers[commandHandlerFullName];
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