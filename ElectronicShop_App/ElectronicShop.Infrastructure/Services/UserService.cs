using ElectronicShop.Application.Interfaces.IRepositories;
using ElectronicShop.Application.Interfaces.IServices;
using ElectronicShop.Domain.Entities;
using ElectronicShop.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Infrastructure.Services
{
    public class UserService : IUserService
    {

        private readonly IRepository repository;
        private readonly IHasherService hasherService;

        public UserService(IRepository repository , IHasherService hasherService)
        {
            this.repository = repository;
            this.hasherService = hasherService;
        }

        public bool CheckLogin(string userName, string password, out string errorMessage, out User account)
        {
            errorMessage = null;

            //Check whether this account is exist or not
            var hashedPassword = hasherService.ComputeSha256Hash(password);

            account = repository.FirstOrDefault<User>(i => i.UserName.Trim() == userName.Trim() && i.Password == hashedPassword, new string[] { "Role" });

            if (account == null)
            {
                errorMessage = Messages.LoginFailed;
                return false;
            }

            if (account.IsActive == false)
            {
                errorMessage = Messages.InactiveAccount;
                return false;
            }

            return true;
        }
    }
}
