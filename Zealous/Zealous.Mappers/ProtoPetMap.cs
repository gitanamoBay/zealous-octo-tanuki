﻿using Zealous.Interfaces;
using Zealous.Models;
using Zealous.ProtoDAL;

namespace Zealous.Mappers
{
    public class ProtoPetMap : IMap
    {
        public ProtoPetMap(IDal dal)
        {
            Dal = dal;
        }

        public IDal Dal { get; set; }

        public bool Applicable(IDBModel model)
        {
            return model is ProtoPetModel;
        }

        public bool Applicable(IModel model)
        {
            return model is PetModel;
        }

        public IModel Map(IDBModel model)
        {
            var proto = model as ProtoPetModel;

            proto.Dal = Dal;

            if (proto == null)
                return null;

            return new PetModel
            {
                Name = proto.Name,
                ID = proto.ID,
                OwnerID = proto.OwnerID,
                Happiness =  proto.Happiness,
                Hunger = proto.Hunger,
                Type = proto.Type,
                LastChangeDate = proto.LastChangeDate,
                HappinessDecay = proto.HappinessDecay,
                HungerDecay = proto.HungerDecay
            };
        }

        public IDBModel Map(IModel model)
        {
            var petModel = model as PetModel;

            if (petModel == null)
                return null;

            return new ProtoPetModel
            {
                Name = petModel.Name,
                ID = petModel.ID,
                OwnerID = petModel.OwnerID,
                Happiness = petModel.Happiness,
                Hunger = petModel.Hunger,
                Type = petModel.Type,
                LastChangeDate = petModel.LastChangeDate,
                HappinessDecay = petModel.HappinessDecay,
                HungerDecay = petModel.HungerDecay
            };
        }
    }
}
