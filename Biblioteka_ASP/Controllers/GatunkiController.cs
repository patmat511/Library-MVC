using Biblioteka_ASP.Models;
using Biblioteka_ASP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Controllers
{
    public class GatunkiController : Controller
    {
        private readonly IGatunkiService _gatunkiService;

        public GatunkiController(IGatunkiService gatunkiService)
        {
            _gatunkiService = gatunkiService;
        }

        // GET: Gatunki
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var gatunki = await _gatunkiService.GetAllAsync();
            return View(gatunki);
        }

        // GET: Gatunki/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gatunki/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gatunki gatunek)
        {
            if (ModelState.IsValid)
            {
                await _gatunkiService.AddAsync(gatunek);
                return RedirectToAction(nameof(Index));
            }
            return View(gatunek);
        }

        // GET: Gatunki/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var gatunek = await _gatunkiService.GetByIdAsync(id);
            if (gatunek == null)
            {
                return NotFound();
            }
            return View(gatunek);
        }

        // POST: Gatunki/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Gatunki gatunek)
        {
            if (id != gatunek.ID_Gatunku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gatunkiService.UpdateAsync(gatunek);
                }
                catch
                {
                    if (await _gatunkiService.GetByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gatunek);
        }

        // GET: Gatunki/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var gatunek = await _gatunkiService.GetByIdAsync(id);
            if (gatunek == null)
            {
                return NotFound();
            }
            return View(gatunek);
        }

        // POST: Gatunki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _gatunkiService.DeleteAsync(id);
            }
            catch
            {
                return View("Error", new { message = "Wystąpił błąd podczas usuwania gatunku." });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}