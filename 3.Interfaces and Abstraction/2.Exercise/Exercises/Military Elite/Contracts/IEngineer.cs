using Military_Elite.Contracts;
using System.Collections.Generic;

namespace Military.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get;}
    }
}
