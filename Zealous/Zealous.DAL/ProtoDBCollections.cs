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

        public bool AddPet(IPet pet)
        {
            var dbModel = pet as ProtoPetModel;

            if (dbModel == null)
                return false;

            lock (petLock)
            {
                petList.Add(dbModel);
            }
            return true;
        }

        public bool AddUser(IUser user)
        {
            var dbModel = petList as ProtoUserModel;

            if (dbModel == null)
                return false;

            lock (userLock)
            {
                userList.Add(dbModel);
            }

            return true;
        }

        public bool UpdatePet(IPet pet)
        {
            var dbModel = pet as ProtoPetModel;

            if (dbModel == null)
                return false;

            lock (petLock)
            {
                var existingModel = petList.SingleOrDefault(x => x.ID == dbModel.ID);

                if (existingModel == null)
                {
                    return false;
                }


                existingModel.CopyMutableValues(dbModel);
               

                return true;
            }
        }

        public bool UpdateUser(IUser user)
        {
            var dbModel = user as ProtoUserModel;

            if (dbModel == null)
                return false;

            lock (userLock)
            {
                var existingModel = userList.SingleOrDefault(x => x.ID == dbModel);

                if (existingModel == null)
                {
                    return false;
                }

                existingModel.CopyMutableValues(dbModel);

                return true;
            }
        }

        static ProtoDBCollections()
        {
            petList = new List<ProtoPetModel>();
            petList.Add(new ProtoPetModel{ ID = Guid.Empty,Happiness = 10,HappinessDecay =  20, Hunger = 100,HungerDecay = 100,LastChangeDate = DateTime.Now,Name ="ya",OwnerID = Guid.Empty,Type = PetType.Aloof});
            userList = new List<ProtoUserModel>();
            userList.Add(new ProtoUserModel(null) { ID = Guid.Empty,Password = "this",Username = "grant"});

            petLock = new object();
            userLock = new object();
        }

    }
}
