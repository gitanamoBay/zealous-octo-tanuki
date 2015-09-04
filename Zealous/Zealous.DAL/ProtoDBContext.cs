using System;
using System.Collections.Generic;
using System.Linq;
using Zealous.Interfaces;

namespace Zealous.DAL
{
    public class ProtoDBContext : IDal
    {
        public IEnumerable<IPet> GetPets()
        {
            return new ProtoDBCollections().Pets;
        }

        public IEnumerable<IPet> GetPetsByUserId(Guid ownerId)
        {
            return new ProtoDBCollections().Pets.Where(x => x.OwnerID == ownerId);
        }

        public IEnumerable<IPet> GetPetsByUsername(string username)
        {
            var collections = new ProtoDBCollections();

            var user = collections.Users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            return collections.Pets.Where(x => x.OwnerID == user.ID);
        }

        public IEnumerable<IUser> GetUsers()
        {
            return new ProtoDBCollections().Users;
        }

        public IUser GetUserById(Guid id)
        {
            return GetUsers().SingleOrDefault(x => x.ID == id);
        }

        public IUser GetUserByName(string username)
        {
            return GetUsers().SingleOrDefault(x => x.Username == username);
        }

        public bool AddPet(IPet pet)
        {
            return new ProtoDBCollections().AddPet(pet);
        }

        public bool UpdatePet(IPet pet)
        {
            return new ProtoDBCollections().UpdatePet(pet);
        }

        public void Dispose()
        {
        }

        public bool AddUser(IUser user)
        {
            return new ProtoDBCollections().AddUser(user);
        }
    }
}