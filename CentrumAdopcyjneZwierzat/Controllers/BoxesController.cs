using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Controllers
{
    public class BoxesController : Controller
    {
        private IBoxRepository _repo;
        public BoxesController(IBoxRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Boxes()
        {
            return View(_repo.FindAll());
        }

        public ActionResult Details(string id)
        {
            foreach (var item in _repo.FindAll())
            {
                if (item.BoxId == id)
                {
                    return View(item);
                }

            }
            return NotFound();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Box item)
        {
            if (ModelState.IsValid)
            {

                _repo.Add(item);
                return View("Boxes", _repo.FindAll());
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
            var box = _repo.FindById(id);

            return View("Edit", box);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Box model)
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

            return View("Boxes", _repo.FindAll());


        }
        public ActionResult Delete(string id)
        {
            _repo.Delete(id);
            return View("Boxes", _repo.FindAll());

        }
    }
}
