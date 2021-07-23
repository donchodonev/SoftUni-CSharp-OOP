
using System;
using Composite_Pattern.Composite;
using Composite_Pattern.Leaf;

namespace Composite_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //1st level instance
            GiftComposite compositeGift = new GiftComposite("first level", 150);
            
            //2nd level instance
            GiftComposite secondLevel = new GiftComposite("second level",100);

            //third level instance added to 2nd level
            secondLevel.Add(new Gift("last level",50));

            //second level added to first level
            compositeGift.Add(secondLevel);


            Console.WriteLine(compositeGift.CalculateTotalPrice());
        }
    }
}
