using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Zealous.Interfaces;

namespace Zealous.Models
{
    public class UserModel : IUser, IModel
    {
        public Guid ID { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public string Password { get; set; }

        public List<IPet> Pets { get; set; }
    }
}