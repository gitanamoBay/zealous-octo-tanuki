using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zealous.DAL;
using Zealous.Interfaces;
using Zealous.Mappers;

namespace Zealous.Domain
{
    public class Users
    {
        public string GetUsers(Guid id)
        {
            string petJson;

            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetPetsByUserId(id).ToList();

                List<IModel> pets = new List<IModel>();

                var mapper = new ProtoPetMap();

                foreach (var pet in data)
                {
                    var petModel = mapper.Map(pet as IDBModel);

                    pets.Add(petModel);
                }

                petJson = JsonConvert.SerializeObject(pets);
            }

            return petJson;
        }

        public string GetUsers()
        {
            string petJson;

            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetPets().ToList();

                List<IModel> pets = new List<IModel>();

                var mapper = new ProtoPetMap();

                foreach (var pet in data)
                {
                    var petModel = mapper.Map(pet as IDBModel);

                    pets.Add(petModel);
                }

                petJson = JsonConvert.SerializeObject(pets);
            }

            return petJson;
        }
    }
}
