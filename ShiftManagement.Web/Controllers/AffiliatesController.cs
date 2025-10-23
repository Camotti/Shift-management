using Microsoft.AspNetCore.Mvc;
using ShiftManagement.Web.Models;
using ShiftManagement.Web.Services;

namespace ShiftManagement.Web.Controllers
{
    public class AffiliateController : Controller
    {
        private readonly AffiliateService _affiliateService;

        public AffiliateController(AffiliateService affiliateService)
        {
            _affiliateService = affiliateService;
        }

        // LISTAR afiliados
        public IActionResult Index()
        {
            var affiliates = _affiliateService.GetAll();
            return View(affiliates);
        }

        // CREAR (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREAR (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Affiliate affiliate)
        {
            if (ModelState.IsValid)
            {
                _affiliateService.Add(affiliate);
                TempData["Message"] = "Affiliate created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(affiliate);
        }

        // EDITAR (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var affiliate = _affiliateService.GetById(id);
            if (affiliate == null)
                return NotFound();

            return View(affiliate);
        }

        // EDITAR (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Affiliate affiliate)
        {
            if (ModelState.IsValid)
            {
                _affiliateService.Update(affiliate);
                TempData["Message"] = "Affiliate updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(affiliate);
        }

        // ELIMINAR (GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var affiliate = _affiliateService.GetById(id);
            if (affiliate == null)
                return NotFound();

            return View(affiliate);
        }

        // ELIMINAR (POST)
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _affiliateService.Delete(id);
            TempData["Message"] = "Affiliate deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
