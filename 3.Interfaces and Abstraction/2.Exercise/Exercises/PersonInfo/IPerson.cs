using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IPerson : IIdentifiable
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
