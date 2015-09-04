using System;
using Newtonsoft.Json;
using Zealous.Enums;
using Zealous.Interfaces;

namespace Zealous.ProtoDAL
{
    public class ProtoPetModel : IPet, IDBModel
    {
        [JsonIgnore]
        public float HappinessDecay
        {
            get
            {
                switch (Type)
                {
                    case PetType.Needy:
                        return 10;
                    case PetType.Aloof:
                        return 1;
                    default:
                        return 50;
                }
            }
            set { throw new Exception("cannot set value"); }
        }

        [JsonIgnore]
        public float HungerDecay
        {
            get
            {
                switch (Type)
                {
                    case PetType.Big:
                        return 10;
                    case PetType.Small:
                        return 1;
                    default:
                        return 5;
                }
            }
            set { throw new Exception("cannot set value"); }
        }

        public IDal Dal { get; set; }
        public Guid ID { get; set; }
        public Guid OwnerID { get; set; }
        public string Name { get; set; }
        public float Happiness { get; set; }
        public float Hunger { get; set; }
        public PetType Type { get; set; }
        public DateTime LastChangeDate { get; set; }

        public void CopyMutableValues(ProtoPetModel newValues)
        {
            Name = newValues.Name;
            Happiness = newValues.Happiness;
            Hunger = newValues.Hunger;
            LastChangeDate = newValues.LastChangeDate;
        }
    }
}