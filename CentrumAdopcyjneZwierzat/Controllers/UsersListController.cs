using CentrumAdopcyjneZwierzat.DataAccess;
using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Controllers
{
    public class UsersListController : Controller
    {
        private IUsersListRepository _repo;
        public UsersListController(IUsersListRepository repo)
        {
            _repo = repo;
        }
        public ActionResult UsersList()
        {
            return View(_repo.FindAll());
        }

        public ActionResult Details(string id)
        {
            foreach (var item in _repo.FindAll())
            {
                if (item.Id == id)
                {
                    return View(item);
                }

            }
            return NotFound();
        }
        public ActionResult Delete(string id)
        {
            _repo.Delete(id);
            return View("UsersList", _repo.FindAll());
 
        }
    }
}
