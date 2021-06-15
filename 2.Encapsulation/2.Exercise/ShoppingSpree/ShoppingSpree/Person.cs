using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private const decimal MinMoney = decimal.Zero;
        private decimal money;
        private string name;
        private readonly List<Product> bag = new List<Product>();
        public Person(string name, decimal money)
        {
            Money = money;
            Name = name;
        }
        private decimal Money
        {
            get { return money; }
            set
            {
                if (value < MinMoney)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public IReadOnlyList<Product> Products
        {
            get => bag.AsReadOnly();
        }

        public void Add(Product product)
        {
            if (product.Cost > Money)
            {
                throw new ArgumentException($"{Name} can't afford {product.Name}");
            }
            Console.WriteLine($"{Name} bought {product.Name}");
            bag.Add(product);
            Money -= product.Cost;
        }
        public override string ToString()
        {
            if (bag.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }

            return $"{Name} - {string.Join(", ", bag.Select(p => p.Name))}";
        }
    }
}
