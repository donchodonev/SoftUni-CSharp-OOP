using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    class CommandInterpreter : ICommandInterpreter
    {
        private ICommand commandToExecute;
        private string result = string.Empty;
        private string commandName;
        public string Read(string args)
        {
            commandName = args.Split()[0];

            if (commandName == "Hello")
            {
                commandToExecute = new HelloCommand();
            }
            else if (commandName == "Exit")
            {
                commandToExecute = new ExitCommand();
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
