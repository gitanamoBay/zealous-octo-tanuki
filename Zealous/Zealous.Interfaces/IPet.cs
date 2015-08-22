using System;
using Zealous.Enums;

namespace Zealous.Interfaces
{
    public interface IPet
    {
        Guid ID { get; set; }
        Guid OwnerID { get; set; }
        string Name { get; set; }
        float Happiness { get; set; }
        float Hunger { get; set; }
        PetType Type { get; set; }
        DateTime DateLastChecked { get; set; }
    }
}
