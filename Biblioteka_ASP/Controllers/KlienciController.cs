using Biblioteka_ASP.Models;
using Biblioteka_ASP.Services.Interfaces;
using Biblioteka_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            var paginatedKlienci = await _klienciService.GetPaginatedListAsync(pageNumber ?? 1, pageSize);

            // Mapowanie PaginatedList<Klienci> na PaginatedList<KlienciViewModel>
            var klienciViewModelList = paginatedKlienci.Items.Select(k => new KlienciViewModel
            {
                ID_Klienta = k.ID_Klienta,
                Imie = k.Imie,
                Email = k.Email,
                Telefon = k.Telefon,
                Adres = k.Adres,
                LiczbaWypozyczen = k.Wypozyczenia?.Count ?? 0
            }).ToList();

            var paginatedViewModel = new PaginatedList<KlienciViewModel>(
                klienciViewModelList,
                paginatedKlienci.Items.Count,
                paginatedKlienci.PageIndex,
                paginatedKlienci.PageSize
            );

            return View(paginatedViewModel);
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

            var klientViewModel = new KlienciViewModel
            {
                ID_Klienta = klient.ID_Klienta,
                Imie = klient.Imie,
                Email = klient.Email,
                Telefon = klient.Telefon,
                Adres = klient.Adres,
                LiczbaWypozyczen = klient.Wypozyczenia?.Count ?? 0
            };
            return View(klientViewModel);
        }

        // GET: Klienci/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new KlienciViewModel());
        }

        // POST: Klienci/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KlienciViewModel klientViewModel)
        {
            if (ModelState.IsValid)
            {
                var klient = new Klienci
                {
                    Imie = klientViewModel.Imie,
                    Email = klientViewModel.Email,
                    Telefon = klientViewModel.Telefon,
                    Adres = klientViewModel.Adres
                };
                await _klienciService.AddAsync(klient);
                return RedirectToAction(nameof(Index));
            }
            return View(klientViewModel);
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

            var klientViewModel = new KlienciViewModel
            {
                ID_Klienta = klient.ID_Klienta,
                Imie = klient.Imie,
                Email = klient.Email,
                Telefon = klient.Telefon,
                Adres = klient.Adres,
                LiczbaWypozyczen = klient.Wypozyczenia?.Count ?? 0
            };
            return View(klientViewModel);
        }

        // POST: Klienci/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KlienciViewModel klientViewModel)
        {
            if (id != klientViewModel.ID_Klienta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var klient = await _klienciService.GetByIdAsync(id);
                    if (klient == null)
                    {
                        return NotFound();
                    }

                    klient.Imie = klientViewModel.Imie;
                    klient.Email = klientViewModel.Email;
                    klient.Telefon = klientViewModel.Telefon;
                    klient.Adres = klientViewModel.Adres;

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
            return View(klientViewModel);
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

            var klientViewModel = new KlienciViewModel
            {
                ID_Klienta = klient.ID_Klienta,
                Imie = klient.Imie,
                Email = klient.Email,
                Telefon = klient.Telefon,
                Adres = klient.Adres,
                LiczbaWypozyczen = klient.Wypozyczenia?.Count ?? 0
            };
            return View(klientViewModel);
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