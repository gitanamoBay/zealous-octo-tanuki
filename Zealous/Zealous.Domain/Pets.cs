﻿using System;
using System.Collections.Generic;
using System.Linq;
using Zealous.DAL;
using Zealous.Enums;
using Zealous.Interfaces;
using Zealous.Mappers;
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

                var pets = new List<IModel>();

                var mapper = new ProtoPetMap(dal);

                foreach (var pet in data)
                {
                    var petModel = mapper.Map(pet as IDBModel);

                    pets.Add(petModel);
                }

                return pets;
            }
        }

        public IEnumerable<IModel> GetPets()
        {
            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetPets().ToList();

                var pets = new List<IModel>();

                var mapper = new ProtoPetMap(dal);

                foreach (var pet in data)
                {
                    var petModel = mapper.Map(pet as IDBModel);

                    pets.Add(petModel);
                }
                return pets;
            }
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

                var happinessReduction = pet.HappinessDecay*delta;
                var hungerIncrease = pet.HungerDecay*delta;

                //floats clamp
                pet.Happiness = pet.Happiness - happinessReduction;
                pet.Hunger = pet.Hunger + hungerIncrease;
                pet.LastChangeDate = now;

                //hacky implementation, going to seperate this in to seperate updaters so they can be a bit more interesting. 
                switch (pet.Type)
                {
                    case PetType.Aloof:
                        if (message.UpdateActions.HasFlag(PetActions.Feed))
                        {
                            pet.Hunger -= 1000;
                        }
                        if (message.UpdateActions.HasFlag(PetActions.Pet))
                        {
                            pet.Happiness += 200;
                        }
                        break;
                    case PetType.Needy:
                        if (message.UpdateActions.HasFlag(PetActions.Feed))
                        {
                            pet.Hunger -= 800;
                        }
                        if (message.UpdateActions.HasFlag(PetActions.Pet))
                        {
                            pet.Happiness += 2000;
                        }
                        break;
                    case PetType.Big:
                        if (message.UpdateActions.HasFlag(PetActions.Feed))
                        {
                            pet.Hunger -= 200;
                            pet.Happiness += 500;
                        }
                        if (message.UpdateActions.HasFlag(PetActions.Pet))
                        {
                            pet.Happiness += 500;
                        }
                        break;
                    case PetType.Small:
                        if (message.UpdateActions.HasFlag(PetActions.Feed))
                        {
                            pet.Hunger -= 5000;
                        }
                        if (message.UpdateActions.HasFlag(PetActions.Pet))
                        {
                            pet.Happiness += 500;
                        }
                        break;
                }

                dal.UpdatePet(pet);

                return new ProtoPetMap(dal).Map(pet);
            }
        }
    }
}