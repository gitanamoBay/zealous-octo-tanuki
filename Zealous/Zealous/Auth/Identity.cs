using System;
using System.Security.Principal;

namespace Zealous.Auth
{
    public class Identity : GenericIdentity
    {
        public string Password;
        public string Username;

        public Identity(string username, string password) : base(username, "Basic")
        {
            Username = username;
            Password = password;
        }
    }
}