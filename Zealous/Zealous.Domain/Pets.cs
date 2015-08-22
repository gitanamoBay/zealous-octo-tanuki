using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string GetPets(int id)
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
