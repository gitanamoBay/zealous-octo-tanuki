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
        public IHttpActionResult Get()
        {
            return Ok(new Zealous.Domain.Users().GetUsers());
        }

        public IHttpActionResult Get(string id)
        {
            Guid guid = Guid.Empty;
            if (Guid.TryParse(id, out guid))
            {
                var user = new Zealous.Domain.Users().GetUser(guid);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            return BadRequest();
        }
        public IHttpActionResult GetUserPets(Guid userId)
        {
            return Ok();
        }
        public IHttpActionResult GetUserPets(Guid userId,Guid petId)
        {
            return Ok();
        }

    }
}
