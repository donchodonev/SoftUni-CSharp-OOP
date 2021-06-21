using Military.Models;
using Military_Elite.Contracts;
using System.Collections.Generic;

namespace Military.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get;}
    }
}
