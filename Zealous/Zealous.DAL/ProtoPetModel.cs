using System;
using Zealous.Interfaces;
using Zealous.Enums;

namespace Zealous.ProtoDAL
{
    public class ProtoPetModel:IPet,IDBModel
    {
        public IDal Dal { get; set; }
        public Guid ID { get; set; }
        public Guid OwnerID { get; set; }
        public string Name { get; set; }
        public float Happiness { get; set; }
        public float Hunger { get; set; }
        public PetType Type { get; set; }
        public DateTime LastChangeDate { get; set; }
        public float HappinessDecay { get; set; }
        public float HungerDecay { get; set; }

        public void CopyMutableValues(ProtoPetModel newValues)
        {
            Name = newValues.Name;
            Happiness = newValues.Happiness;
            Hunger = newValues.Hunger;
            LastChangeDate = newValues.LastChangeDate;
            HappinessDecay = newValues.HappinessDecay;
            HungerDecay = newValues.HungerDecay;
        }
    }
}