using System;
using System.Collections.Generic;

namespace Zealous.Interfaces
{
    public interface IDal:IDisposable
    {
        IList<IPet> GetPets();
        IList<IPet> GetPets(Guid ownerId);
        void SetPets(Guid ownerId, IList<IPet> newPets);
    }
}
