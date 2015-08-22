using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zealous.DAL;
using Zealous.Interfaces;
using Newtonsoft.Json;

namespace Zealous.Domain
{
    public class Pets
    {
        public string GetPets(int id)
        {
            string petJson;

            using (IDal dal = new ProtoDBContext())
            {
                var data = dal.GetPets();

                petJson = JsonConvert.SerializeObject(data);
            }


            return petJson;
        }
    }
}
