using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
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
        private const string path = @"C:\Users\grant\Desktop\Zealous";

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
                storePets();
            }
            return true;
        }

        public bool AddUser(IUser user)
        {
            var dbModel = user as ProtoUserModel;

            if (dbModel == null)
                return false;

            lock (userLock)
            {
                userList.Add(dbModel);
                storeUsers();
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
               storePets();

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
                var existingModel = userList.SingleOrDefault(x => x.ID == dbModel.ID);

                if (existingModel == null)
                {
                    return false;
                }

                existingModel.CopyMutableValues(dbModel);
                storeUsers();

                return true;
            }
        }

        static void storePets()
        {
            File.WriteAllText(path+@"\pets.json",JsonConvert.SerializeObject(petList));
        }

        static void storeUsers()
        {
            File.WriteAllText(path + @"\users.json", JsonConvert.SerializeObject(userList));
        }



        static ProtoDBCollections()
        {
            if (Directory.Exists(path))
            {
                petList = JsonConvert.DeserializeObject< List<ProtoPetModel>>(File.ReadAllText(path + @"\pets.json"));
                userList = JsonConvert.DeserializeObject<List<ProtoUserModel>>(File.ReadAllText(path + @"\users.json"));
            }
            else
            {
                petList = new List<ProtoPetModel>();
                petList.Add(new ProtoPetModel { ID = Guid.Empty, LastChangeDate = DateTime.Now, Name = "ya", OwnerID = Guid.Empty, Type = PetType.Aloof });
                userList = new List<ProtoUserModel>();
                userList.Add(new ProtoUserModel(null) { ID = Guid.Empty, Password = "this", Username = "grant" });

                Directory.CreateDirectory(path);
                storePets();
                storeUsers();
            }

            petLock = new object();
            userLock = new object();
        }

    }
}
