using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces.Interfaces
{
    public interface ICitizen
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void GetName();
    }
}
