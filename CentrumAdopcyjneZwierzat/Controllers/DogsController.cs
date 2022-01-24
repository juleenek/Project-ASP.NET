using CentrumAdopcyjneZwierzat.DataAccess.Repositories;
using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Controllers
{
    public class DogsController : Controller
    {
        private IDogsRepository _repo;
        public DogsController(IDogsRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Dogs()
        {
            return View(_repo.FindAll());
        }

        public ActionResult Details(string id)
        {
            foreach (var item in _repo.FindAll())
            {
                if (item.DogId == id)
                {
                    return View(item);
                }

            }
            return NotFound();
        }
        public IActionResult Create(Dog item)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(item);
                return View("Dogs", item);
            }
            else
            {
                return View("AddDDog");
            }

        }
        public ActionResult Edit(string id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var user = _repo.FindById(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dog model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isSuccess = _repo.Update(model);

            if (!isSuccess)
            {
                ModelState.AddModelError("", "Coś poszło nie tak?");
                return View(model);
            }

            return View("UsersList", RedirectToAction(nameof(Edit)));


        }
        public ActionResult Delete(string id)
        {
            _repo.Delete(id);
            return View("UsersList", _repo.FindAll());

        }
    }
}
