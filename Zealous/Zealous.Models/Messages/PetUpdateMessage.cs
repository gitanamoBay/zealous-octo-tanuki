using System;
using Zealous.Enums;

namespace Zealous.Models.Messages
{
    public class PetUpdateMessage
    {
        public Guid PetID;
        public PetActions UpdateActions;
        public Guid UserID;
    }
}