using System;

namespace Zealous.Models.Messages
{
    public class AddPetMessage
    {
        public PetModel Model;
        public Guid UserId;
    }
}