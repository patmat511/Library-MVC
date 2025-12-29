//using Biblioteka_ASP.Models;
//using Biblioteka_ASP.Repositories.Interfaces;
//using Biblioteka_ASP.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Threading.Tasks;
//using System.Linq;

//namespace Biblioteka_ASP.Controllers
//{
//    public class WypozyczeniaController : Controller
//    {
//        private readonly IWypozyczeniaRepository _wypozyczeniaRepository;
//        private readonly IKsiazkiRepository _ksiazkiRepository;
//        private readonly IKlienciRepository _klienciRepository;

//        public WypozyczeniaController(IWypozyczeniaRepository wypozyczeniaRepository, IKsiazkiRepository ksiazkiRepository, IKlienciRepository klienciRepository)
//        {
//            _wypozyczeniaRepository = wypozyczeniaRepository;
//            _ksiazkiRepository = ksiazkiRepository;
//            _klienciRepository = klienciRepository;
//        }

//        // GET: Wypozyczenia
//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            var wypozyczenia = await _wypozyczeniaRepository.GetAllAsync();
//            var wypozyczeniaViewModel = wypozyczenia.Select(w => new WypozyczeniaViewModel
//            {
//                ID_Wypozyczenia = w.ID_Wypozyczenia,
//                ID_Ksiazki = w.ID_Ksiazki,
//                TytulKsiazki = w.Ksiazki?.Tytul ?? "Brak książki",
//                ID_Klienta = w.ID_Klienta,
//                ImieKlienta = w.Klienci?.Imie ?? "Brak klienta",
//                Data_Wypozyczenia = w.Data_Wypozyczenia,
//                Data_Zwrotu = w.Data_Zwrotu,
//                Kara = w.Kara
//            }).ToList();
//            return View(wypozyczeniaViewModel);
//        }

//        // GET: Wypozyczenia/Create
//        [HttpGet]
//        public async Task<IActionResult> Create()
//        {
//            ViewBag.Ksiazki = new SelectList(await _ksiazkiRepository.GetAllAsync(), "ID_Ksiazki", "Tytul");
//            ViewBag.Klienci = new SelectList(await _klienciRepository.GetAllAsync(), "ID_Klienta", "Imie");
//            return View(new WypozyczeniaViewModel());
//        }

//        // POST: Wypozyczenia/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(WypozyczeniaViewModel wypozyczenieViewModel)
//        {
//            // Walidacja: Data_Zwrotu musi być późniejsza niż Data_Wypozyczenia
//            if (wypozyczenieViewModel.Data_Zwrotu < wypozyczenieViewModel.Data_Wypozyczenia)
//            {
//                ModelState.AddModelError(nameof(wypozyczenieViewModel.Data_Zwrotu), "Data zwrotu musi być późniejsza niż data wypożyczenia.");
//            }

//            if (ModelState.IsValid)
//            {
//                var wypozyczenie = new Wypozyczenia
//                {
//                    ID_Ksiazki = wypozyczenieViewModel.ID_Ksiazki,
//                    ID_Klienta = wypozyczenieViewModel.ID_Klienta,
//                    Data_Wypozyczenia = wypozyczenieViewModel.Data_Wypozyczenia,
//                    Data_Zwrotu = wypozyczenieViewModel.Data_Zwrotu,
//                    Kara = wypozyczenieViewModel.Kara
//                };
//                await _wypozyczeniaRepository.AddAsync(wypozyczenie);
//                return RedirectToAction(nameof(Index));
//            }

//            // Debugowanie błędów walidacji
//            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
//            Console.WriteLine("Błędy walidacji: " + string.Join(", ", errors));

//            ViewBag.Ksiazki = new SelectList(await _ksiazkiRepository.GetAllAsync(), "ID_Ksiazki", "Tytul", wypozyczenieViewModel.ID_Ksiazki);
//            ViewBag.Klienci = new SelectList(await _klienciRepository.GetAllAsync(), "ID_Klienta", "Imie", wypozyczenieViewModel.ID_Klienta);
//            return View(wypozyczenieViewModel);
//        }

//        // GET: Wypozyczenia/Edit/5
//        [HttpGet]
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var wypozyczenie = await _wypozyczeniaRepository.GetByIdAsync(id.Value);
//            if (wypozyczenie == null)
//            {
//                return NotFound();
//            }

//            var wypozyczenieViewModel = new WypozyczeniaViewModel
//            {
//                ID_Wypozyczenia = wypozyczenie.ID_Wypozyczenia,
//                ID_Ksiazki = wypozyczenie.ID_Ksiazki,
//                TytulKsiazki = wypozyczenie.Ksiazki?.Tytul ?? "Brak książki",
//                ID_Klienta = wypozyczenie.ID_Klienta,
//                ImieKlienta = wypozyczenie.Klienci?.Imie ?? "Brak klienta",
//                Data_Wypozyczenia = wypozyczenie.Data_Wypozyczenia,
//                Data_Zwrotu = wypozyczenie.Data_Zwrotu,
//                Kara = wypozyczenie.Kara
//            };

//            ViewBag.Ksiazki = new SelectList(await _ksiazkiRepository.GetAllAsync(), "ID_Ksiazki", "Tytul", wypozyczenieViewModel.ID_Ksiazki);
//            ViewBag.Klienci = new SelectList(await _klienciRepository.GetAllAsync(), "ID_Klienta", "Imie", wypozyczenieViewModel.ID_Klienta);
//            return View(wypozyczenieViewModel);
//        }

//        // POST: Wypozyczenia/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, WypozyczeniaViewModel wypozyczenieViewModel)
//        {
//            if (id != wypozyczenieViewModel.ID_Wypozyczenia)
//            {
//                return NotFound();
//            }

//            // Walidacja: Data_Zwrotu musi być późniejsza niż Data_Wypozyczenia
//            if (wypozyczenieViewModel.Data_Zwrotu < wypozyczenieViewModel.Data_Wypozyczenia)
//            {
//                ModelState.AddModelError(nameof(wypozyczenieViewModel.Data_Zwrotu), "Data zwrotu musi być późniejsza niż data wypożyczenia.");
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var wypozyczenie = await _wypozyczeniaRepository.GetByIdAsync(id);
//                    if (wypozyczenie == null)
//                    {
//                        return NotFound();
//                    }

//                    wypozyczenie.ID_Ksiazki = wypozyczenieViewModel.ID_Ksiazki;
//                    wypozyczenie.ID_Klienta = wypozyczenieViewModel.ID_Klienta;
//                    wypozyczenie.Data_Wypozyczenia = wypozyczenieViewModel.Data_Wypozyczenia;
//                    wypozyczenie.Data_Zwrotu = wypozyczenieViewModel.Data_Zwrotu;
//                    wypozyczenie.Kara = wypozyczenieViewModel.Kara;

//                    await _wypozyczeniaRepository.UpdateAsync(wypozyczenie);
//                }
//                catch
//                {
//                    if (await _wypozyczeniaRepository.GetByIdAsync(id) == null)
//                    {
//                        return NotFound();
//                    }
//                    throw;
//                }
//                return RedirectToAction(nameof(Index));
//            }

//            // Debugowanie błędów walidacji
//            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
//            Console.WriteLine("Błędy walidacji: " + string.Join(", ", errors));

//            ViewBag.Ksiazki = new SelectList(await _ksiazkiRepository.GetAllAsync(), "ID_Ksiazki", "Tytul", wypozyczenieViewModel.ID_Ksiazki);
//            ViewBag.Klienci = new SelectList(await _klienciRepository.GetAllAsync(), "ID_Klienta", "Imie", wypozyczenieViewModel.ID_Klienta);
//            return View(wypozyczenieViewModel);
//        }

//        // GET: Wypozyczenia/Delete/5
//        [HttpGet]
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var wypozyczenie = await _wypozyczeniaRepository.GetByIdAsync(id.Value);
//            if (wypozyczenie == null)
//            {
//                return NotFound();
//            }

//            var wypozyczenieViewModel = new WypozyczeniaViewModel
//            {
//                ID_Wypozyczenia = wypozyczenie.ID_Wypozyczenia,
//                ID_Ksiazki = wypozyczenie.ID_Ksiazki,
//                TytulKsiazki = wypozyczenie.Ksiazki?.Tytul ?? "Brak książki",
//                ID_Klienta = wypozyczenie.ID_Klienta,
//                ImieKlienta = wypozyczenie.Klienci?.Imie ?? "Brak klienta",
//                Data_Wypozyczenia = wypozyczenie.Data_Wypozyczenia,
//                Data_Zwrotu = wypozyczenie.Data_Zwrotu,
//                Kara = wypozyczenie.Kara
//            };

//            return View(wypozyczenieViewModel);
//        }

//        // POST: Wypozyczenia/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            try
//            {
//                await _wypozyczeniaRepository.DeleteAsync(id);
//            }
//            catch
//            {
//                return View("Error", new { message = "Wystąpił błąd podczas usuwania wypożyczenia." });
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}