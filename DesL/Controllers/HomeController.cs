using DesL.Models;
using DesL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDesignerRepository _repo;

        public HomeController(IDesignerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _repo.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Designer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _repo.Create(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _repo.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Designer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _repo.Update(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _repo.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Designer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _repo.Delete(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
