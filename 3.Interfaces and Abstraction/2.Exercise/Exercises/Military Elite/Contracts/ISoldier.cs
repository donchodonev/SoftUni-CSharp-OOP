using System;
using System.Collections.Generic;
using System.Text;
using Military.Models;


namespace Military.Contracts
{
    public interface ISoldier
    { 
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
