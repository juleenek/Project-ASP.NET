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
    public class AdminController : Controller
    {
        private IUsersListRepository _repo;
        public AdminController(IUsersListRepository repo)
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

        //// GET: AdminController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AdminController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //public ActionResult Edit(string id)
        //{
        //    if (!_repo.IsExists(id))
        //    {
        //        return NotFound();
        //    }
        //    var user = _repo.FindById(id);

        //    return View(user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(ApplicationUser model)
        //{

        //        if (!ModelState.IsValid)
        //        {
        //            return View(model);
        //        }

        //        var isSuccess = _repo.Update(model);

        //        if (!isSuccess)
        //        {
        //            ModelState.AddModelError("", "Coś poszło nie tak?");
        //            return View(model);
        //        }

        //        return View("UsersList", RedirectToAction(nameof(Edit)));


        //}
        public ActionResult Delete(string id)
        {
            _repo.Delete(id);
            return View("UsersList", _repo.FindAll());
 
        }
    }
}
