using System;
using System.Collections.Generic;

namespace Zealous.Interfaces
{
    public interface IUser
    {
        Guid ID { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        List<IPet> Pets { get; set; }
    }
}