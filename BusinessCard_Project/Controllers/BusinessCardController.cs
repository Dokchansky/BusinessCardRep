using BusinessCard_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessCard_Project.Controllers
{
    public class BusinessCardController : Controller
    {
        private readonly Context _context;

        public BusinessCardController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BusinessCardViewModel card)
        {
            if (ModelState.IsValid)
            {
                _context.BusinessCards.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var card = await _context.BusinessCards.FindAsync(id);
            if (card == null) return NotFound();
            return View(card);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BusinessCardViewModel card)
        {
            if (id != card.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var card = await _context.BusinessCards.FindAsync(id);
            if (card == null) return NotFound();
            return View(card);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.BusinessCards.FindAsync(id);
            if (card != null)
            {
                _context.BusinessCards.Remove(card);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}