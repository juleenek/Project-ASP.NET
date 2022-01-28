using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using CentrumAdopcyjneZwierzat.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.WebAPI_REST
{
    [Route("api/dogs")]
    public class ApiDogsController : Controller
    {
        private IDogsRepository dogs;
        public ApiDogsController(IDogsRepository dogs)
        {
            this.dogs = dogs;
        }

        [HttpGet]
        public IList<Dog> FindAll()
        {
            return (IList<Dog>)dogs.FindAll();
        }


        [HttpGet()]
        [Route("{id}")]
        public ActionResult GetOne(string id)
        {
           Dog dog = dogs.FindById(id);
            if (dog != null)
            {
                return new OkObjectResult(dog);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult Add([FromBody] Dog item)
        {
            if (ModelState.IsValid)
            {
                Dog dog = dogs.SaveDog(item);
                return Ok(dog);
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
            if (dogs.FindById(id) != null)
            {
                dogs.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(string id, [FromBody] Dog item)
        {
            item.DogId = id;
            var user = dogs.Update(item);
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
