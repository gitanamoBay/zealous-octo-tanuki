using System;
using System.Linq;
using System.Web.Http;
using Zealous.Models.Messages;

namespace Zealous.Controllers
{
    public class PetsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok( new Domain.Pets().GetPets());
        }

        public IHttpActionResult Get(string id)
        {
            Guid guid = Guid.Empty;
            if (Guid.TryParse(id, out guid))
            {
                var pets = new Zealous.Domain.Pets().GetPets(guid);
                if(pets.Count() > 0)
                    return Ok(pets);

                return NotFound();
            }
            return BadRequest();
        }

        public IHttpActionResult UpdatePet(PetUpdateMessage message)
        {
            var pets = new Zealous.Domain.Pets();

            var model = pets.UpdatePet(message);

            if (model != null)
            {
                return Ok(model);
            }
          
            return NotFound();
        }
    }
}
