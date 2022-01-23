using CentrumAdopcyjneZwierzat.DataAccess;
using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
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
        private IUsersListRepository repo;
        public AdminController(IUsersListRepository repo)
        {
            this.repo = repo;
        }
        public ActionResult UsersList()
        {
            return View(repo.FindAll());
        }

        //// GET: AdminController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

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

        //// GET: AdminController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AdminController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(string? id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context;
        //    }
        //}

        //// GET: AdminController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AdminController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
