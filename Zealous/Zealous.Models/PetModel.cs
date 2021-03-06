﻿using System;
using Zealous.Enums;
using Zealous.Interfaces;

namespace Zealous.Models
{
    public class PetModel : IPet, IModel
    {
        public float HappinessDecay { get; set; }
        public float HungerDecay { get; set; }
        public Guid ID { get; set; }
        public Guid OwnerID { get; set; }
        public string Name { get; set; }
        public float Happiness { get; set; }
        public float Hunger { get; set; }
        public PetType Type { get; set; }
        public DateTime LastChangeDate { get; set; }
    }
}