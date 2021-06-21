using Collection_Hierarchy.Models;
using System;
using System.Collections.Generic;

namespace Collection
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<ICollectable> collections = new List<ICollectable>(3);

            collections.Add(new AddCollection());
            collections.Add(new AddRemoveCollection());
            collections.Add(new MyList());

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int row = collections.Count;
            int col = input.Length;

            string[,] outputMatrix = new string[row, col];

            int colCounter = 0;

            foreach (string item in input)
            {
                outputMatrix[0, colCounter] = $"{(collections[0] as AddCollection).Add(item)}";
                outputMatrix[1, colCounter] = $"{(collections[1] as AddRemoveCollection).Add(item)}";
                outputMatrix[2, colCounter] = $"{(collections[2] as MyList).Add(item)}";

                colCounter++;
            }

            int numOfRemoveOps = int.Parse(Console.ReadLine());


            for (int i = 0; i < row; i++)
            {
                for (int v = 0; v < col - 1; v++)
                {
                    Console.Write($"{outputMatrix[i, v]} ");
                }

                Console.Write($"{outputMatrix[i, col - 1]}");

                Console.WriteLine();
            }

            foreach (var collection in collections)
            {
                List<string> output = new List<string>();

                if (collection is AddRemoveCollection)
                {
                    for (int i = 0; i < numOfRemoveOps; i++)
                    {
                        output.Add((collection as AddRemoveCollection).Remove());
                    }

                    Console.WriteLine(string.Join(' ', output));
                }
                else if (collection is MyList)
                {
                    for (int i = 0; i < numOfRemoveOps; i++)
                    {
                        output.Add((collection as MyList).Remove());
                    }

                    Console.WriteLine(string.Join(' ', output));
                }
            }
        }
    }
}
