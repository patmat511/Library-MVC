using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories;
using Biblioteka_ASP.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Controllers
{
    public class WypozyczeniaController : Controller
    {
        private readonly IWypozyczeniaRepository _wypozyczeniaRepository;
        private readonly IKsiazkiRepository _ksiazkiRepository;
        private readonly IKlienciRepository _klienciRepository;

        public WypozyczeniaController(IWypozyczeniaRepository wypozyczeniaRepository, IKsiazkiRepository ksiazkiRepository, IKlienciRepository klienciRepository)
        {
            _wypozyczeniaRepository = wypozyczeniaRepository;
            _ksiazkiRepository = ksiazkiRepository;
            _klienciRepository = klienciRepository;
        }

        // GET: Wypozyczenia
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var wypozyczenia = await _wypozyczeniaRepository.GetAllAsync();
            return View(wypozyczenia);
        }

        // GET: Wypozyczenia/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Ksiazki = new SelectList(await _ksiazkiRepository.GetAllAsync(), "ID_Ksiazki", "Tytul");
            ViewBag.Klienci = new SelectList(await _klienciRepository.GetAllAsync(), "ID_Klienta", "Imie");
            return View();
        }

        // POST: Wypozyczenia/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Ksiazki,ID_Klienta,Data_Wypozyczenia,Data_Zwrotu,Kara")] Wypozyczenia wypozyczenie)
        {
            // Usuń z ModelState właściwości, które nie są przesyłane z formularza
            ModelState.Remove("ID_Wypozyczenia");
            ModelState.Remove("Ksiazki");
            ModelState.Remove("Klienci");

            // Walidacja: Data_Zwrotu musi być późniejsza niż Data_Wypozyczenia
            if (wypozyczenie.Data_Zwrotu < wypozyczenie.Data_Wypozyczenia)
            {
                ModelState.AddModelError(nameof(wypozyczenie.Data_Zwrotu), "Data zwrotu musi być późniejsza niż data wypożyczenia.");
            }

            if (ModelState.IsValid)
            {
                await _wypozyczeniaRepository.AddAsync(wypozyczenie);
                return RedirectToAction(nameof(Index));
            }

            // Debugowanie błędów walidacji
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            Console.WriteLine("Błędy walidacji: " + string.Join(", ", errors));

            ViewBag.Ksiazki = new SelectList(await _ksiazkiRepository.GetAllAsync(), "ID_Ksiazki", "Tytul", wypozyczenie.ID_Ksiazki);
            ViewBag.Klienci = new SelectList(await _klienciRepository.GetAllAsync(), "ID_Klienta", "Imie", wypozyczenie.ID_Klienta);
            return View(wypozyczenie);
        }

        // GET: Wypozyczenia/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wypozyczenie = await _wypozyczeniaRepository.GetByIdAsync(id.Value);
            if (wypozyczenie == null)
            {
                return NotFound();
            }

            ViewBag.Ksiazki = new SelectList(await _ksiazkiRepository.GetAllAsync(), "ID_Ksiazki", "Tytul", wypozyczenie.ID_Ksiazki);
            ViewBag.Klienci = new SelectList(await _klienciRepository.GetAllAsync(), "ID_Klienta", "Imie", wypozyczenie.ID_Klienta);
            return View(wypozyczenie);
        }

        // POST: Wypozyczenia/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Wypozyczenia,ID_Ksiazki,ID_Klienta,Data_Wypozyczenia,Data_Zwrotu,Kara")] Wypozyczenia wypozyczenie)
        {
            if (id != wypozyczenie.ID_Wypozyczenia)
            {
                return NotFound();
            }

            // Usuń z ModelState właściwości, które nie są przesyłane z formularza
            ModelState.Remove("Ksiazki");
            ModelState.Remove("Klienci");

            // Walidacja: Data_Zwrotu musi być późniejsza niż Data_Wypozyczenia
            if (wypozyczenie.Data_Zwrotu < wypozyczenie.Data_Wypozyczenia)
            {
                ModelState.AddModelError(nameof(wypozyczenie.Data_Zwrotu), "Data zwrotu musi być późniejsza niż data wypożyczenia.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _wypozyczeniaRepository.UpdateAsync(wypozyczenie);
                }
                catch
                {
                    if (await _wypozyczeniaRepository.GetByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Debugowanie błędów walidacji
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            Console.WriteLine("Błędy walidacji: " + string.Join(", ", errors));

            ViewBag.Ksiazki = new SelectList(await _ksiazkiRepository.GetAllAsync(), "ID_Ksiazki", "Tytul", wypozyczenie.ID_Ksiazki);
            ViewBag.Klienci = new SelectList(await _klienciRepository.GetAllAsync(), "ID_Klienta", "Imie", wypozyczenie.ID_Klienta);
            return View(wypozyczenie);
        }

        // GET: Wypozyczenia/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wypozyczenie = await _wypozyczeniaRepository.GetByIdAsync(id.Value);
            if (wypozyczenie == null)
            {
                return NotFound();
            }

            return View(wypozyczenie);
        }

        // POST: Wypozyczenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _wypozyczeniaRepository.DeleteAsync(id);
            }
            catch
            {
                return View("Error", new { message = "Wystąpił błąd podczas usuwania wypożyczenia." });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
