using System;
using System.Collections.Generic;

namespace Zealous.Interfaces
{
    public interface IDal:IDisposable
    {
        IEnumerable<IPet> GetPets();
        IEnumerable<IPet> GetPetsByUserId(Guid ownerId);
        IEnumerable<IPet> GetPetsByUsername(string Username);
        IEnumerable<IUser> GetUsers();
        IUser GetUserById(Guid id);
        IUser GetUserByName(string username);
    }
}
