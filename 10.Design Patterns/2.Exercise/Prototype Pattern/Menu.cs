using System.Collections.Generic;
using Prototype_Pattern.AbstractSandwichPrototype;

namespace SandwichMenu
{
    public class Menu
    {
        private Dictionary<string, PrototypeSandwich> sandwichMenu = new Dictionary<string, PrototypeSandwich>();

        public PrototypeSandwich this[string name]
        {
            get => sandwichMenu[name];
            set => sandwichMenu.TryAdd(name, value);
        }
    }
}
