using System;
using System.Collections.Generic;
using Zealous.Interfaces;

namespace Zealous.DAL
{
    public class ProtoDBContext : IDal
    {
        public IList<IPet> GetPets()
        {
            return new List<IPet>();
        }

        public IList<IPet> GetPets(Guid ownerId)
        {
            return new List<IPet>();
        }

        public void SetPets(Guid ownwerId, IList<IPet> newPets)
        {
        }

        public void Dispose()
        {
        }
    }
}
