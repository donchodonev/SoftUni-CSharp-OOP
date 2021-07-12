using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    class HelloCommand : ICommand
    {
        string SayHello(string argument)
        {
            return $"Hello, {argument}";
        }

        public string Execute(string[] args)
        {
            string result = SayHello(args[0]);

            return result;
        }
    }
}
