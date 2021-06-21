using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Contracts
{
    public interface ISpy : ISoldier
    {
        public int CodeNumber { get;}
    }
}
