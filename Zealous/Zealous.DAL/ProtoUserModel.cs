using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Zealous.Interfaces;

namespace Zealous.ProtoDAL
{
    public class ProtoUserModel:IUser,IDBModel
    {
        public ProtoUserModel(IDal dB)
        {
            DataBase = dB;  
        }

        public IDal DataBase { get; set; }
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public List<IPet> Pets
        {
            get { return DataBase.GetPetsByUserId(ID).ToList(); }
            set {  }
        } 
    }
}
