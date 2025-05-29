using Biblioteka_ASP.Models;
using Biblioteka_ASP.Services.Interfaces;
using Biblioteka_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

            var paginatedViewModel = new PaginatedList<KsiazkiViewModel>(
                paginatedList.Items.Select(k => new KsiazkiViewModel
                {
                    ID_Ksiazki = k.ID_Ksiazki,
                    Tytul = k.Tytul,
                    Autor = k.Autor,
                    Rok_Wydania = k.Rok_Wydania,
                    ID_Gatunku = k.ID_Gatunku,
                    NazwaGatunku = k.Gatunki?.Gatunek ?? "Brak gatunku",
                    Ilosc_Dostepna = k.Ilosc_Dostepna,
                    LiczbaWypozyczen = k.Wypozyczenia?.Count ?? 0
                }).ToList(),
                paginatedList.TotalCount,
                paginatedList.PageIndex,
                paginatedList.PageSize
            );

            ViewData["CurrentFilter"] = searchString;
            return View(paginatedViewModel);
        }

        //public IActionResult Create()
        //{
        //    return View(KsiazkiViewModel);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KsiazkiViewModel ksiazkaViewModel)
        {
            if (ModelState.IsValid)
            {
                var ksiazka = new Ksiazki
                {
                    Tytul = ksiazkaViewModel.Tytul,
                    Autor = ksiazkaViewModel.Autor,
                    Rok_Wydania = ksiazkaViewModel.Rok_Wydania,
                    ID_Gatunku = ksiazkaViewModel.ID_Gatunku,
                    Ilosc_Dostepna = ksiazkaViewModel.Ilosc_Dostepna
                };
                await _ksiazkiService.AddAsync(ksiazka);
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazkaViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ksiazka = await _ksiazkiService.GetByIdAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            var ksiazkaViewModel = new KsiazkiViewModel
            {
                ID_Ksiazki = ksiazka.ID_Ksiazki,
                Tytul = ksiazka.Tytul,
                Autor = ksiazka.Autor,
                Rok_Wydania = ksiazka.Rok_Wydania,
                ID_Gatunku = ksiazka.ID_Gatunku,
                NazwaGatunku = ksiazka.Gatunki?.Gatunek ?? "Brak gatunku",
                Ilosc_Dostepna = ksiazka.Ilosc_Dostepna,
                LiczbaWypozyczen = ksiazka.Wypozyczenia?.Count ?? 0
            };
            return View(ksiazkaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KsiazkiViewModel ksiazkaViewModel)
        {
            if (id != ksiazkaViewModel.ID_Ksiazki)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ksiazka = await _ksiazkiService.GetByIdAsync(id);
                    if (ksiazka == null)
                    {
                        return NotFound();
                    }

                    ksiazka.Tytul = ksiazkaViewModel.Tytul;
                    ksiazka.Autor = ksiazkaViewModel.Autor;
                    ksiazka.Rok_Wydania = ksiazkaViewModel.Rok_Wydania;
                    ksiazka.ID_Gatunku = ksiazkaViewModel.ID_Gatunku;
                    ksiazka.Ilosc_Dostepna = ksiazkaViewModel.Ilosc_Dostepna;

                    await _ksiazkiService.UpdateAsync(ksiazka);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazkaViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ksiazka = await _ksiazkiService.GetByIdAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            var ksiazkaViewModel = new KsiazkiViewModel
            {
                ID_Ksiazki = ksiazka.ID_Ksiazki,
                Tytul = ksiazka.Tytul,
                Autor = ksiazka.Autor,
                Rok_Wydania = ksiazka.Rok_Wydania,
                ID_Gatunku = ksiazka.ID_Gatunku,
                NazwaGatunku = ksiazka.Gatunki?.Gatunek ?? "Brak gatunku",
                Ilosc_Dostepna = ksiazka.Ilosc_Dostepna,
                LiczbaWypozyczen = ksiazka.Wypozyczenia?.Count ?? 0
            };
            return View(ksiazkaViewModel);
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