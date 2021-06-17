using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IIdentifiable
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
}
