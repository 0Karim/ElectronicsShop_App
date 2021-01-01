using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicShop.Application.Interfaces.IServices;
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
    }
}
