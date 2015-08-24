using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zealous.DAL;
using Zealous.Interfaces;
using Zealous.Mappers;
using Zealous.Models;
using Zealous.ProtoDAL;

namespace Zealous.Domain
{
    public class Users
    {
        public string GetUser(Guid id)
        {
            string petJson;

            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetUserById(id);

                var userModel = new ProtoUserMap(dal).Map(data as IDBModel) as UserModel;

                var pets = new List<IModel>();

                var petmapper = new ProtoPetMap(dal);

                foreach (var pet in userModel.Pets)
                {
                    pets.Add(petmapper.Map(pet as IDBModel));
                }

                petJson = JsonConvert.SerializeObject(new {
                    userModel.Username,
                    Pets = pets,
                    userModel.ID
                });
            }

            return petJson;
        }

        public string GetUsers()
        {
            string petJson;

            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetUsers().ToList();

                List<object> users = new List<object>();

                var mapper = new ProtoUserMap(dal);
                var petmapper = new ProtoPetMap(dal);
                foreach (var user in data)
                {
                    var userModel = mapper.Map(user as IDBModel) as UserModel;

                    var pets = new List<IModel>();

                    foreach (var pet in userModel.Pets)
                    {
                        pets.Add(petmapper.Map(pet as IDBModel));
                    }

                    users.Add( new {userModel.Username,
                        Pets = pets,
                        userModel.ID});
                }

                petJson = JsonConvert.SerializeObject(users);
            }

            return petJson;
        }
    }
}
