using Biblioteka_ASP.Models;
using Biblioteka_ASP.Services.Interfaces;
using Biblioteka_ASP.ViewModels;
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
            var gatunkiViewModel = gatunki.Select(g => new GatunkiViewModel
            {
                ID_Gatunku = g.ID_Gatunku,
                Gatunek = g.Gatunek,
                LiczbaKsiazek = g.Ksiazki?.Count ?? 0
            }).ToList();
            return View(gatunkiViewModel);
        }

        // GET: Gatunki/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new GatunkiViewModel());
        }

        // POST: Gatunki/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GatunkiViewModel gatunekViewModel)
        {
            if (ModelState.IsValid)
            {
                var gatunek = new Gatunki
                {
                    Gatunek = gatunekViewModel.Gatunek
                };
                await _gatunkiService.AddAsync(gatunek);
                return RedirectToAction(nameof(Index));
            }
            return View(gatunekViewModel);
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

            var gatunekViewModel = new GatunkiViewModel
            {
                ID_Gatunku = gatunek.ID_Gatunku,
                Gatunek = gatunek.Gatunek,
                LiczbaKsiazek = gatunek.Ksiazki?.Count ?? 0
            };
            return View(gatunekViewModel);
        }

        // POST: Gatunki/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GatunkiViewModel gatunekViewModel)
        {
            if (id != gatunekViewModel.ID_Gatunku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var gatunek = await _gatunkiService.GetByIdAsync(id);
                    if (gatunek == null)
                    {
                        return NotFound();
                    }

                    gatunek.Gatunek = gatunekViewModel.Gatunek;
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
            return View(gatunekViewModel);
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

            var gatunekViewModel = new GatunkiViewModel
            {
                ID_Gatunku = gatunek.ID_Gatunku,
                Gatunek = gatunek.Gatunek,
                LiczbaKsiazek = gatunek.Ksiazki?.Count ?? 0
            };
            return View(gatunekViewModel);
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