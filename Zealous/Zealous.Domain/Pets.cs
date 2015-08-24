using System;
using System.Collections.Generic;
using System.Linq;
using Zealous.DAL;
using Zealous.Interfaces;
using Newtonsoft.Json;
using Zealous.Mappers;

namespace Zealous.Domain
{
    public class Pets
    {
        public string GetPets(Guid id)
        {
            string petJson;

            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetPetsByUserId(id).ToList();

                List<IModel> pets = new List<IModel>();

                var mapper = new ProtoPetMap(dal);

                foreach (var pet in data)
                {
                    var petModel = mapper.Map(pet as IDBModel);

                    pets.Add(petModel);
                }

                petJson = JsonConvert.SerializeObject(pets);
            }

            return petJson;
        }

        public string GetPets()
        {
            string petJson;

            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetPets().ToList();

                List<IModel> pets = new List<IModel>();

                var mapper = new ProtoPetMap(dal);

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
