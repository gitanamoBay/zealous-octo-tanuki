using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zealous.Enums;

namespace Zealous.Models.Messages
{
    public class PetUpdateMessage
    {
        public Guid UserID;
        public Guid PetID;
        public PetActions UpdateActions;
    }
}
