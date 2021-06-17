using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    interface ICar
    {
        public string Color { get; set; }
        public string Model { get; set; }
        public string Stop();
        public string Start();
    }
}
