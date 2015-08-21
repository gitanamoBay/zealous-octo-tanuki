using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zealous.Interfaces;

namespace Zealous.Models
{
    public class UserModel
    {
        public UserModel(IDal dB)
        {
            DataBase = dB;  
        }

        public IDal DataBase { get; set; }
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; }

        [JsonIgnore]
        public List<IPet> Pets
        {
            get { return DataBase.GetPets(ID);  } }
        } 
    }
}
