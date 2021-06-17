using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public interface IIdentifiable
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
}
