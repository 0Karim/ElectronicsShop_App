using ElectronicShop.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

namespace ElectronicShop.Application.Interfaces.IServices
{
    public interface ISessionService
    {
        string Culture { get; }

        bool IsArabic { get; }

        SessionUser User { get; }


        void SetSessionVariable(string key, object value);

        T GetSessionVariable<T>(string key) where T : class;

        Task LoginUser(HttpContext httpContext, SessionUser loggedInUser);
    }
}
