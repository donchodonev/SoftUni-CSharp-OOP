using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList rl = new RandomList
            {
                "string1",
                "string2",
                "string3",
                "string4",
                "string5"
            };

            Console.WriteLine(rl.RandomString());
        }
    }
}
