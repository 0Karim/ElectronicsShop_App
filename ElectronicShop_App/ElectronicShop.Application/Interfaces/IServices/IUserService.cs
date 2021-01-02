using ElectronicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Application.Interfaces.IServices
{
    public interface IUserService
    {
        bool CheckLogin(string userName, string password, out string errorMessage, out User account);
    }
}
