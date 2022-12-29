using DemoApplication.Areas.Admin.ViewComponents;
using DemoApplication.Areas.Client.ViewModels.Authentication;
using DemoApplication.Areas.Client.ViewModels.Book.Update;
using DemoApplication.Database;
using DemoApplication.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;

        public AccountController(DataContext dataContext, IUserService userService)
        {
            _dataContext = dataContext;
            _userService = userService;
        }

        [HttpGet("dashboard", Name = "client-account-dashboard")]
        public IActionResult Dashboard()
        {
            var user = _userService.CurrentUser;
            var user2 = _userService.CurrentUser;

            return View();
        }

        [HttpGet("orders", Name = "client-account-orders")]
        public IActionResult Orders()
        {
            var user = _userService.CurrentUser;
            var user2 = _userService.CurrentUser;

            return View();
        }

       

        [HttpGet("info", Name = "client-account-info")]
        public async Task <IActionResult> Info()
        {
            var currentUser = _userService.CurrentUser;

            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == currentUser.Id);

            var model = new RegisterUpdateViewModel
            {
                FirstName = user!.FirstName!,
                LastName = user.LastName!,
            };

            return View(model);
        }

        [HttpPost("info", Name = "client-account-info")]
        public async Task<IActionResult> Info(RegisterUpdateViewModel model)
        {
            var currentuser = _userService.CurrentUser;
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == currentuser.Id);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            user!.FirstName = model.FirstName;
            user.LastName = model.LastName;

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("client-account-dashboard");

        }


        [HttpPost("password", Name = "client-account-password")]
        public async Task<IActionResult> Password(PasswordUpdateVIewModel model)
        {
            var currentuser = _userService.CurrentUser;
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == currentuser.Id);

            if(user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool verified = BCrypt.Net.BCrypt.Verify(model.OlderPassword, user.Password);
            if (verified)
            {
                var newPassword = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                user.Password = newPassword;
                await _dataContext.SaveChangesAsync();
            }
            else
            {
                return View(model);
            }

            return RedirectToRoute("client-account-dashboard");
        }


        [HttpGet("password", Name = "client-account-password")]
        public IActionResult Password()
        {
            return View();
        }



        [HttpGet("address", Name = "client-account-addresses")]
        public async Task<IActionResult> Address()
        {
            var currentUser = _userService.CurrentUser;

            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == currentUser.Id);

            var model = new AddressUpdateViewModel
            {
                FirstName = user!.FirstName!,
                LastName = user.LastName!,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }


        [HttpPost("address", Name = "client-account-adresses")]
        public async Task<IActionResult> Address(AddressUpdateViewModel model)
        {
            var currentuser = _userService.CurrentUser;
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == currentuser.Id);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            user!.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user!.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("client-account-dashboard");

        }
    }
}
