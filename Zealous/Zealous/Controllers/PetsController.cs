using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Zealous.Controllers
{
    public class PetsController : ApiController
    {
        public string Get()
        {
            return new Zealous.Domain.Pets().GetPets();
        }

        public string Get(string id)
        {
            Guid guid = Guid.Empty;
            if(Guid.TryParse(id, out guid))
                return new Zealous.Domain.Pets().GetPets(guid);

            return new HttpError("User not found.").ToString();
        }


    }
}
