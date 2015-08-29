using System;
using System.Collections.Generic;
using System.Linq;
using Zealous.DAL;
using Zealous.Interfaces;
using Newtonsoft.Json;
using Zealous.Mappers;
using Zealous.Models;
using Zealous.Models.Messages;
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

        public IModel UpdatePet(PetUpdateMessage message)
        {
            using (IDal dal = new ProtoDBContext())
            {
                //var mapper = new ProtoPetMap(dal);

                // var dbModel = mapper.Map(pet as IModel);
                var pet =
                    dal.GetPets().FirstOrDefault(x => x.ID == message.PetID && x.OwnerID == message.UserID) as
                        ProtoPetModel;

                if (pet == null)
                {
                    return null;
                }
                //calculate hours away;
                var now = DateTime.Now;
                now.AddYears(-2000);
                var seconds = now.Second + now.Minute*60 + now.Hour*360 + now.DayOfYear*1440 + now.Year*525949;

                var pseconds = pet.LastChangeDate.Second + pet.LastChangeDate.Minute*60 + pet.LastChangeDate.Hour*360
                               + pet.LastChangeDate.DayOfYear*1440 + pet.LastChangeDate.Year*525949;
                var delta = seconds - pseconds;

                //TimeSpan t = TimeSpan.FromSeconds(delta);

                float happinessReduction = pet.HappinessDecay*delta;
                float hungerReduction = pet.HungerDecay*delta;

                if (happinessReduction > pet.Happiness)
                {
                    pet.Happiness = 0;
                }

                if (hungerReduction > pet.Hunger)
                {
                    pet.Hunger = 0;
                }





            return new PetModel();
            }
        }
    }
}
