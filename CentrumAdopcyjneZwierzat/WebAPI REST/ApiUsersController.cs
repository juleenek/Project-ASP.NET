using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.WebAPI_REST
{
    [Route("api/users")]
    public class ApiUsersController : Controller
    {
        private IUsersListRepository users;
        public ApiUsersController(IUsersListRepository users)
        {
            this.users = users;
        }

        [HttpGet]
        public IList<ApplicationUser> FindAll()
        {
            return (IList<ApplicationUser>)users.FindAll();
        }


        [HttpGet()]
        [Route("{id}")]
        public ActionResult GetOne(string id)
        {
            ApplicationUser user = users.FindById(id);
            if (user != null)
            {
                return new OkObjectResult(user);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult Add([FromBody] ApplicationUser item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = users.SaveUser(item);
                return new CreatedResult($"/api/items/{user.Id}", user);
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
            if (users.FindById(id) != null)
            {
                users.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(string id, [FromBody] ApplicationUser item)
        {
            item.Id = id;
            var user = users.Update(item);
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
