using Microsoft.AspNetCore.Mvc;
using ShiftManagement.Web.Data;
using ShiftManagement.Web.Models;
using System.Linq;

namespace ShiftManagement.Web.Controllers
{
    public class TurnController : Controller
    {
        private readonly AppDbContext _context;

        public TurnController(AppDbContext context)
        {
            _context = context;
        }

        // -----------------------------
        // LISTAR TODOS LOS TURNOS
        // -----------------------------
        public IActionResult Index()
        {
            var turns = _context.Turns.ToList();
            return View(turns);
        }

        // -----------------------------
        // CREAR NUEVO TURNO (GET)
        // -----------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // -----------------------------
        // CREAR NUEVO TURNO (POST)
        // -----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken] // Protección contra ataques CSRF
        public IActionResult Create(Turn turn)
        {
            if (ModelState.IsValid)
            {
                _context.Turns.Add(turn);
                _context.SaveChanges();

                TempData["Message"] = "Turn created successfully.";
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores, vuelve al formulario
            return View(turn);
        }

        // -----------------------------
        // EDITAR TURNO (GET)
        // -----------------------------
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var turn = _context.Turns.Find(id);
            if (turn == null)
                return NotFound();

            return View(turn);
        }

        // -----------------------------
        // EDITAR TURNO (POST)
        // -----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Turn turn)
        {
            if (ModelState.IsValid)
            {
                _context.Turns.Update(turn);
                _context.SaveChanges();

                TempData["Message"] = "Turn updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(turn);
        }

        // -----------------------------
        // ELIMINAR TURNO (GET)
        // -----------------------------
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var turn = _context.Turns.Find(id);
            if (turn == null)
                return NotFound();

            return View(turn);
        }

        // -----------------------------
        // ELIMINAR TURNO (POST)
        // -----------------------------
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var turn = _context.Turns.Find(id);
            if (turn != null)
            {
                _context.Turns.Remove(turn);
                _context.SaveChanges();

                TempData["Message"] = "Turn deleted successfully.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}