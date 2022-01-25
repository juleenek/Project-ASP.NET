using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Controllers
{
    public class VolunteersController : Controller
    {
        private IVolunteerRepository _repo;

        public VolunteersController(IVolunteerRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Volunteers()
        {
            return View(_repo.FindAll());
        }

        public ActionResult Details(string id)
        {
            foreach (var item in _repo.FindAll())
            {
                if (item.VolunteerId == id)
                {
                    return View(item);
                }

            }
            return NotFound();
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Volunteer item)
        {
            if (ModelState.IsValid)
            {

                _repo.Add(item);
                return View("Volunteers", _repo.FindAll());
            }
            else
            {
                return View("Create");
            }

        }
        public ActionResult Edit(string id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var volunteer = _repo.FindById(id);

            return View("Edit", volunteer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Volunteer model)
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

            return View("Volunteers", _repo.FindAll());


        }
        public ActionResult Delete(string id)
        {
            _repo.Delete(id);
            return View("Volunteers", _repo.FindAll());

        }
    }
}
