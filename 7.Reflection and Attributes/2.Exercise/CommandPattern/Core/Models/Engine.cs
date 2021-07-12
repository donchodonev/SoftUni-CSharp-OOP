using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private string inputData;
        public Engine(ICommandInterpreter interpreter)
        {
            this.commandInterpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                inputData = Console.ReadLine();

                Console.WriteLine(commandInterpreter.Read(inputData));
            }
        }
    }
}
