using Biblioteka_ASP.Models;
using Biblioteka_ASP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Controllers
{
    public class KsiazkiController : Controller
    {
        private readonly IKsiazkiService _ksiazkiService;
        public KsiazkiController(IKsiazkiService ksiazkiService)
        {
            _ksiazkiService = ksiazkiService;
        }

        public async Task<IActionResult> Index(string searchString, int pageNumber = 1)
        {
            int pageSize = 5;
            var paginatedList = await _ksiazkiService.GetPaginatedListAsync(pageNumber, pageSize, searchString);

            ViewData["CurrentFilter"] = searchString;
            return View(paginatedList);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ksiazki ksiazka)
        {
            if (ModelState.IsValid)
            {
                await _ksiazkiService.AddAsync(ksiazka);
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazka);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ksiazka = await _ksiazkiService.GetByIdAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            return View(ksiazka);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ksiazki ksiazka)
        {
            if (id != ksiazka.ID_Ksiazki)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ksiazkiService.UpdateAsync(ksiazka);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazka);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ksiazka = await _ksiazkiService.GetByIdAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            return View(ksiazka);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ksiazkiService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}