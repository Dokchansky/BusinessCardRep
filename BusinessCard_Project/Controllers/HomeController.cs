using BusinessCard_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BusinessCard_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;



        public HomeController(Context context)
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
        
        public IActionResult Privacy()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
