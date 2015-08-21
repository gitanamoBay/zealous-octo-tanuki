using System;
using System.Collections.Generic;

namespace Zealous.Interfaces
{
    public interface IDal
    {
        List<IPet> GetPets();
        List<IPet> GetPets(Guid ownerId);
    }
}
