using System;
using CommandPattern.ConcreteCommand;
using CommandPattern.Enums;
using CommandPattern.Invoker;
using CommandPattern.Receiver;

namespace CommandPattern
{
    public class Client
    {
        public static void Main(string[] args)
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Phone", 500);

            modifyPrice.SetCommand(new ProductCommand(product,PriceAction.Increase,100));
            modifyPrice.Invoke();

            Console.WriteLine(product);
        }
    }
}