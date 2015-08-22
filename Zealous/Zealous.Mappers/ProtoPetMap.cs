using System;
using System.Collections.Generic;
using Zealous.Interfaces;
using Zealous.Models;
using Zealous.ProtoDAL;

namespace Zealous.Mappers
{
    public class ProtoPetMap : IMap<PetModel, ProtoPetModel>
    {
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

            if (proto == null)
                return null;

            return new PetModel
            {
                Name = proto.Name,
            };
        }

        public IDBModel Map(IModel model)
        {
            return new ProtoPetModel();
        }
    }
}
