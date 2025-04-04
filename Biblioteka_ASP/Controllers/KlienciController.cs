using Biblioteka_ASP.Models;
using Biblioteka_ASP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Controllers
{
    public class KlienciController : Controller
    {
        private readonly IKlienciService _klienciService;

        public KlienciController(IKlienciService klienciService)
        {
            _klienciService = klienciService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 5; 
            var klienci = await _klienciService.GetPaginatedListAsync(pageNumber ?? 1, pageSize);
            return View(klienci);
        }

        // GET: Klienci/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var klient = await _klienciService.GetByIdAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }

        // GET: Klienci/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klienci/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Klienci klient)
        {
            if (ModelState.IsValid)
            {
                await _klienciService.AddAsync(klient);
                return RedirectToAction(nameof(Index));
            }
            return View(klient);
        }

        // GET: Klienci/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var klient = await _klienciService.GetByIdAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }

        // POST: Klienci/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Klienci klient)
        {
            if (id != klient.ID_Klienta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _klienciService.UpdateAsync(klient);
                }
                catch
                {
                    if (await _klienciService.GetByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(klient);
        }

        // GET: Klienci/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var klient = await _klienciService.GetByIdAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }

        // POST: Klienci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _klienciService.DeleteAsync(id);
            }
            catch
            {
                return View("Error", new { message = "Wystąpił błąd podczas usuwania klienta." });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}