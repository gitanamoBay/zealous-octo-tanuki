using System;

namespace Zealous.Models.Messages
{
    public class AddPetMessage
    {
        public Guid UserId;
        public PetModel Model;
    }
}
