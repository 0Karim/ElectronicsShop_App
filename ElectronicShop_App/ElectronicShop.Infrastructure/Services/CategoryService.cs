using ElectronicShop.Application.Interfaces.IRepositories;
using ElectronicShop.Application.Interfaces.IServices;
using ElectronicShop.Domain.Common;
using ElectronicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicShop.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;


        public CategoryService(IRepository repository)
        {
            this.repository = repository;
        }

        public List<IdNameDto> GetAllCategories()
        {
            try
            {
                var categoriesList = repository.GetAllWhereQ<Category>(c => c.IsActive == true)
                    .Select(c => new IdNameDto 
                    {
                        Id = c.Id,
                        NameAr = c.NameAr,
                        NameEn = c.NameEn
                    }).ToList();

                return categoriesList;

            }
            catch(Exception ex)
            {
                return new List<IdNameDto>();
            }
        }
    }
}
