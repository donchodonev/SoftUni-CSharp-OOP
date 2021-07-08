using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            StringBuilder sb = new StringBuilder();

            var methodsByAuthors = typeof(StartUp);

            var methodsCollection = methodsByAuthors
                .GetMethods(
                    BindingFlags.Instance |
                            BindingFlags.NonPublic |
                            BindingFlags.Public |
                            BindingFlags.Static);
            foreach (var method in methodsCollection)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}