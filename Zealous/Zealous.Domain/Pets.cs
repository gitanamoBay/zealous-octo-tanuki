using System;
using System.Collections.Generic;
using System.Linq;
using Zealous.DAL;
using Zealous.Interfaces;
using Newtonsoft.Json;
using Zealous.Mappers;
using Zealous.Models;
using Zealous.ProtoDAL;

namespace Zealous.Domain
{
    public class Pets
    {
        public IEnumerable<IModel> GetPets(Guid id)
        {

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

                return pets;
            }

            return null;
        }

        public IEnumerable<IModel> GetPets()
        {
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
                return pets;
            }

            return null;
        }

        public bool AddPet(IPet pet)
        {
            using (IDal dal = new ProtoDBContext())
            {
                var mapper = new ProtoPetMap(dal);

                var dbmodel = mapper.Map(pet as IModel);

                return dal.AddPet(dbmodel as ProtoPetModel);
            }
        }

        public IModel UpdatePet(IPet pet)
        {
            using (IDal dal = new ProtoDBContext())
            {
                var mapper = new ProtoPetMap(dal);

                var dbModel = mapper.Map(pet as IModel);

                return new PetModel();
            }
        }
    }
}
