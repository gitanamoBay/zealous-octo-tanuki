using System;
using System.Collections.Generic;
using System.Linq;
using Zealous.Enums;
using Zealous.Interfaces;
using Zealous.ProtoDAL;

namespace Zealous.DAL
{
    public class ProtoDBCollections:IDBSet
    {
        static List<ProtoPetModel> petList;
        static List<ProtoUserModel> userList;
        private static object petLock;
        private static object userLock;

        public IEnumerable<IPet> Pets
        {
            get
            {
                lock (petLock)
                {
                    return petList.ToList();
                }
            }
        }

        public IEnumerable<IUser> Users
        {
            get
            {
                lock (userLock)
                {
                    return userList.ToList();
                }
            }
        }

        static ProtoDBCollections()
        {
            petList = new List<ProtoPetModel>();
            petList.Add(new ProtoPetModel{ ID = Guid.Empty,Happiness = 10,HappinessDecay =  20, Hunger = 100,HungerDecay = 100,LastChangeDate = DateTime.Now,Name ="ya",OwnerID = Guid.Empty,Type = PetType.Aloof});
            userList = new List<ProtoUserModel>();
            petLock = new object();
            userLock = new object();
        }

    }
}
