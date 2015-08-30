using System;
using System.Collections.Generic;
using System.Linq;
using Zealous.DAL;
using Zealous.Interfaces;
using Newtonsoft.Json;
using Zealous.Enums;
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
                var pet =
                    dal.GetPets().FirstOrDefault(x => x.ID == message.PetID && x.OwnerID == message.UserID) as
                        ProtoPetModel;

                if (pet == null)
                {
                    return null;
                }

                var now = DateTime.Now;

                var delta = (float) ((now - pet.LastChangeDate).TotalSeconds);

                float happinessReduction = pet.HappinessDecay*delta;
                float hungerReduction = pet.HungerDecay*delta;

                if (happinessReduction > pet.Happiness)
                {
                    pet.Happiness = 0;
                }
                else
                {
                    pet.Happiness = pet.Happiness - happinessReduction;
                }

                if (hungerReduction > pet.Hunger)
                {
                    pet.Hunger = 0;
                }
                else
                {
                    pet.Hunger = pet.Hunger - hungerReduction;
                }


                pet.LastChangeDate = now;
                switch (pet.Type)
                {
                    case PetType.Aloof:
                        if (message.UpdateActions.HasFlag(PetActions.Feed))
                        {

                        }
                        if (message.UpdateActions.HasFlag(PetActions.Pet))
                        {

                        }
                        break;
                    case PetType.Needy:
                        if (message.UpdateActions.HasFlag(PetActions.Feed))
                        {

                        }
                        if (message.UpdateActions.HasFlag(PetActions.Pet))
                        {

                        }
                        break;
                    case PetType.Big:
                        if (message.UpdateActions.HasFlag(PetActions.Feed))
                        {

                        }
                        if (message.UpdateActions.HasFlag(PetActions.Pet))
                        {

                        }
                        break;
                    case PetType.Small:
                        if (message.UpdateActions.HasFlag(PetActions.Feed))
                        {

                        }
                        if (message.UpdateActions.HasFlag(PetActions.Pet))
                        {

                        }
                        break;
                }

                dal.UpdatePet(pet);

                return new ProtoPetMap(dal).Map(pet);
            }
        }
    }
}
