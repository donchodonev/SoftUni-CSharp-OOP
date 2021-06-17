using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
   public class Robot: IIdentifiable,INameable
    {
        public Robot(string name, string iD)
        {
            Name = name;
            ID = iD;
        }
        public string Name { get; set; }
        public string ID { get; set; }
    }
}
