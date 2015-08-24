using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Zealous.Controllers
{
    public class UsersController : ApiController
    {
        public string Get()
        {
            return new Zealous.Domain.Users().GetUsers();
        }

        public string Get(string id)
        {
            Guid guid = Guid.Empty;
            if(Guid.TryParse(id, out guid))
                return new Zealous.Domain.Users().GetUser(guid);

            return new HttpError("User not found.").ToString();
        }


    }
}
