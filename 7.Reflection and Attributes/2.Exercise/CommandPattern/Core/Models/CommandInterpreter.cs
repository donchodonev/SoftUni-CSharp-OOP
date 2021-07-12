using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    class CommandInterpreter : ICommandInterpreter
    {
        private const string commandNameEnding = "Command";
        private ICommand commandToExecute;
        private string result = string.Empty;
        private string commandName;
        public string Read(string args)
        {
            commandName = args.Split()[0] + commandNameEnding;

            var commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where
                (t => t.Name == commandName && t.GetInterfaces()
                    .Any(i => i.Name.EndsWith(commandNameEnding))
                );

            if (commandType.FirstOrDefault() == null)
            {
                throw new InvalidOperationException("Type not found");
            }

            try
            {
                commandToExecute = Activator.CreateInstance(commandType.First()) as ICommand;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            string[] cleanData = args
                .Split()
                .Skip(1)
                .ToArray();

            result = commandToExecute.Execute(cleanData);

            return result;
        }
    }
}
