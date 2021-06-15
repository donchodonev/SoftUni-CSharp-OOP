using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //fk this exercise

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                persons = Console.ReadLine()
                    .Split(';')
                    .ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Person(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                products = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Product(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string cmdArgs = Console.ReadLine();

            while (cmdArgs != "END")
            {
                string[] tokens = cmdArgs.Split();
                var person = persons.First(p => p.Name == tokens[0]);
                var product = products.First(p => p.Name == tokens[1]);

                try
                {
                    person.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                cmdArgs = Console.ReadLine();
            }

            //print
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
