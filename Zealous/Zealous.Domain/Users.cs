using System;
using System.Collections.Generic;
using System.Linq;
using Zealous.DAL;
using Zealous.Interfaces;
using Zealous.Mappers;
using Zealous.Models;

namespace Zealous.Domain
{
    public class Users
    {
        public IModel GetUser(Guid id)
        {
            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetUserById(id);

                var userModel = new ProtoUserMap(dal).Map(data as IDBModel) as UserModel;

                var pets = new List<IPet>();

                var petmapper = new ProtoPetMap(dal);

                foreach (var pet in userModel.Pets)
                {
                    pets.Add(petmapper.Map(pet as IDBModel) as IPet);
                }

                userModel.Pets = pets;

                return userModel;
            }
        }

        public List<IModel> GetUsers()
        {
            string petJson;

            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetUsers().ToList();

                var users = new List<IModel>();

                var mapper = new ProtoUserMap(dal);
                var petmapper = new ProtoPetMap(dal);
                foreach (var user in data)
                {
                    var userModel = mapper.Map(user as IDBModel) as UserModel;

                    var pets = new List<IPet>();

                    foreach (var pet in userModel.Pets)
                    {
                        pets.Add(petmapper.Map(pet as IDBModel) as IPet);
                    }
                    userModel.Pets = pets;
                    users.Add(userModel);
                }

                return users;
            }
        }

        public bool Authenticate(string username, string password)
        {
            using (IDal dal = new ProtoDBContext())
            {
                var user = dal.GetUserByName(username);

                if (user == null)
                    return false;

                if (user.Password != password)
                    return false;
            }
            return true;
        }

    }
}
