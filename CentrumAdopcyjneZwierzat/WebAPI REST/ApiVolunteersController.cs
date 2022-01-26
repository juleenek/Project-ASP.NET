using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.WebAPI_REST
{
    [Route("api/volunteers")]
    public class ApiVolunteersController : Controller
    {
        private IVolunteerRepository volunteers;
        public ApiVolunteersController(IVolunteerRepository volunteers)
        {
            this.volunteers = volunteers;
        }

        [HttpGet]
        public IList<Volunteer> FindAll()
        {
            return (IList<Volunteer>)volunteers.FindAll();
        }


        [HttpGet()]
        [Route("{id}")]
        public ActionResult GetOne(string id)
        {
            Volunteer volunteer = volunteers.FindById(id);
            if (volunteer != null)
            {
                return new OkObjectResult(volunteer);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult Add([FromBody] Volunteer item)
        {
            if (ModelState.IsValid)
            {
                Volunteer volunteer = volunteers.SaveVolunteer(item);
                return new CreatedResult($"/api/items/{volunteer.VolunteerId}", volunteer);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(string id)
        {
            if (volunteers.FindById(id) != null)
            {
                volunteers.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(string id, [FromBody] Volunteer item)
        {
            item.VolunteerId = id;
            var user = volunteers.Update(item);
            if (user)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
