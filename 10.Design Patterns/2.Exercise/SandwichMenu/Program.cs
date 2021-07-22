using Prototype_Pattern.ConcretePrototype;

namespace SandwichMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu sandwichMenu = new Menu();

            sandwichMenu["Mazniya sandvich"] = new Sandwich("White", "Chedder", "Pork", "Sivriya pepper");
            sandwichMenu["Ani sandvich"] = new Sandwich("Wholegrain", "Blue cheese", "", "Cucumber");

            Sandwich mySandwich = sandwichMenu["Mazniya sandvich"].Clone() as Sandwich;
            Sandwich naAnitoSandvicha = sandwichMenu["Ani sandvich"].Clone() as Sandwich;
        }
    }
}
