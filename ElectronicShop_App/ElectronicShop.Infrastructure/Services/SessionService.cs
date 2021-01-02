using ElectronicShop.Application.Interfaces.IServices;
using ElectronicShop.Domain;
using ElectronicShop.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicShop.Infrastructure.Services
{
    public class SessionService : ISessionService
    {
        public string Culture { get; }
        public bool IsArabic { get; }
        public SessionUser User { get; private set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            var httpContext = httpContextAccessor.HttpContext;

            if (string.IsNullOrEmpty(httpContext.Session.GetString("user")))
            {
                if (httpContext.User?.Identity?.IsAuthenticated == true && httpContext.User?.Claims?.Count() > 0)
                {
                    try
                    {
                        SessionUser sessionUser = new SessionUser
                        {
                            Id = Convert.ToInt32(httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value),
                            UserName = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                            FullNameAr = httpContext.User.Claims.FirstOrDefault(c => c.Type == Constants.FullNameClaimType)?.Value,
                            FullNameEn = httpContext.User.Claims.FirstOrDefault(c => c.Type == Constants.FullNameClaimType)?.Value,
                            Role = httpContext.User.Claims.FirstOrDefault(c => c.Type == Constants.RoleClaimType)?.Value,
                        };

                        httpContext.Session.SetString("user", JsonConvert.SerializeObject(sessionUser));
                    }
                    catch (Exception ex) { }
                }
            }


            Culture = Thread.CurrentThread.CurrentCulture.Name.ToString();
            IsArabic = Thread.CurrentThread.CurrentCulture.Name == Constants.ARCultureCode;

            if (!string.IsNullOrEmpty(httpContext.Session.GetString("user")))
            {
                User = JsonConvert.DeserializeObject<SessionUser>(httpContext.Session.GetString("user"));
            }
        }

        public T GetSessionVariable<T>(string key) where T : class
        {
            var sessionValue = _httpContextAccessor.HttpContext.Session.GetString(key);
            if (!string.IsNullOrEmpty(sessionValue))
            {
                return JsonConvert.DeserializeObject<T>(sessionValue);
            }

            return null;
        }

        public async Task LoginUser(HttpContext httpContext, SessionUser loggedInUser)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, loggedInUser.Id.ToString()),
                new Claim(ClaimTypes.Name, loggedInUser.UserName),
                new Claim(Constants.FullNameClaimType, IsArabic ? loggedInUser.FullNameAr : loggedInUser.FullNameEn),
                new Claim(Constants.RoleClaimType, loggedInUser.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
            };

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            // Fill Session
            httpContext.Session.SetString("user", JsonConvert.SerializeObject(loggedInUser));

            this.User = loggedInUser;

        }

        public void SetSessionVariable(string key, object value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
