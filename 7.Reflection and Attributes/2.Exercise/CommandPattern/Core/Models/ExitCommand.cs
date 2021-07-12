using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    class ExitCommand : ICommand
    {
        string Exit()
        {
            Environment.Exit(0);
            return null;
        }
        public string Execute(string[] args)
        {
            return Exit();
        }
    }
}
