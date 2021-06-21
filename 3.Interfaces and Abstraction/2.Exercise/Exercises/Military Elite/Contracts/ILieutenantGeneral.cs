using System.Collections.Generic;

namespace Military_Elite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get;}
    }
}
