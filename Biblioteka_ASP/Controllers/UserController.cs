using Biblioteka_ASP.Models;
using Biblioteka_ASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Imie = user.Imie,
                    Nazwisko = user.Nazwisko,
                    Roles = roles.ToList()
                });
            }

            return View(userViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> EditRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            var viewModel = new EditUserRolesViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                CurrentRoles = currentRoles.ToList(),
                AvailableRoles = allRoles,
                SelectedRoles = currentRoles.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRoles(EditUserRolesViewModel viewModel)
        {
            var user = await _userManager.FindByIdAsync(viewModel.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Nie udało się usunąć ról użytkownika.");
                viewModel.AvailableRoles = _roleManager.Roles.Select(r => r.Name).ToList();
                return View(viewModel);
            }

            if (viewModel.SelectedRoles != null && viewModel.SelectedRoles.Any())
            {
                var addResult = await _userManager.AddToRolesAsync(user, viewModel.SelectedRoles);
                if (!addResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Nie udało się dodać ról użytkownika.");
                    viewModel.AvailableRoles = _roleManager.Roles.Select(r => r.Name).ToList();
                    return View(viewModel);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
