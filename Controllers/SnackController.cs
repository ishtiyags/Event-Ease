using Microsoft.AspNetCore.Mvc;
using SnackTrackMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SnackTrackMvc.Controllers
{
    public class SnacksController : Controller
    {
        // In-memory list (database simulation)
        private static List<Snack> snacks = new List<Snack>
        {
            new Snack { Id = 1, Name="Chocolate Bar", Category="Sweet", Price=15, Description="Milk chocolate" },
            new Snack { Id = 2, Name="Bubble Tea", Category="Drink", Price=35, Description="Tapioca pearls drink" }
        };

        // READ ALL
        public IActionResult Index()
        {
            return View(snacks);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var snack = snacks.FirstOrDefault(s => s.Id == id);
            if (snack == null) return NotFound();

            return View(snack);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Snack snack)
        {
            if (ModelState.IsValid)
            {
                snack.Id = snacks.Max(s => s.Id) + 1;
                snacks.Add(snack);
                return RedirectToAction("Index");
            }
            return View(snack);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var snack = snacks.FirstOrDefault(s => s.Id == id);
            if (snack == null) return NotFound();

            return View(snack);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Snack snack)
        {
            if (ModelState.IsValid)
            {
                var existing = snacks.First(s => s.Id == snack.Id);

                existing.Name = snack.Name;
                existing.Category = snack.Category;
                existing.Price = snack.Price;
                existing.Description = snack.Description;

                return RedirectToAction("Index");
            }
            return View(snack);
        }

        // DELETE GET
        public IActionResult Delete(int id)
        {
            var snack = snacks.FirstOrDefault(s => s.Id == id);
            if (snack == null) return NotFound();

            return View(snack);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var snack = snacks.First(s => s.Id == id);
            snacks.Remove(snack);

            return RedirectToAction("Index");
        }
    }
}