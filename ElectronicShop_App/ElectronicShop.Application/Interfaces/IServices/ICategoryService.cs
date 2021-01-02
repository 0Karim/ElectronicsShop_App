using ElectronicShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Application.Interfaces.IServices
{
    public interface ICategoryService
    {
        List<IdNameDto> GetAllCategories();
    }
}
