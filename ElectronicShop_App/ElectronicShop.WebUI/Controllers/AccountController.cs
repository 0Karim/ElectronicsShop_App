using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicShop.Application.Interfaces.IServices;
using ElectronicShop.Domain;
using ElectronicShop.Domain.Entities;
using ElectronicShop.Infrastructure.Helpers;
using ElectronicShop.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicShop.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly ISessionService sessionService;
        private readonly IHasherService hasherService;
        private readonly IMapper mapper;


        public AccountController(IUserService userService, ISessionService sessionService, IHasherService hasherService, IMapper mapper)
        {
            this.userService = userService;
            this.sessionService = sessionService;
            this.hasherService = hasherService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated == true && User.Claims?.Count() > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string errorMessage;
            User user;

            if (userService.CheckLogin(model.UserName, model.Password, out errorMessage, out user))
            {
                var sessionUser = mapper.Map<SessionUser>(user);

                await sessionService.LoginUser(HttpContext, sessionUser);

                if (sessionUser.Role.ToLower().Equals("admin"))
                    return RedirectToAction("Index", "Product");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData[Constants.ErrorMessage] = errorMessage;
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

        [HttpGet]
        [Authorize]
        public IActionResult AccessDeined()
        {
            return View();
        }
    }
}
