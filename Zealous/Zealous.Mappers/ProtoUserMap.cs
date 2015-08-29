using Zealous.Interfaces;
using Zealous.Models;
using Zealous.ProtoDAL;

namespace Zealous.Mappers
{
    public class ProtoUserMap : IMap
    {
        public ProtoUserMap(IDal dal)
        {
            Dal = dal;
        }

        public IDal Dal { get; set; }

        public bool Applicable(IDBModel model)
        {
            return model is ProtoUserModel;
        }

        public bool Applicable(IModel model)
        {
            return model is UserModel;
        }

        public IModel Map(IDBModel model)
        {
            var proto = model as ProtoUserModel;

            proto.Dal = Dal;

            if (proto == null)
                return null;

            return new UserModel
            {
                ID = proto.ID,
                Username =  proto.Username,
                Password = proto.Password,
                Pets = proto.Pets
            };
        }

        public IDBModel Map(IModel model)
        {
            return null;
        }
    }
}
