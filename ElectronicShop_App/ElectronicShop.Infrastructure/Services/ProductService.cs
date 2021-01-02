using ElectronicShop.Application.Interfaces.IRepositories;
using ElectronicShop.Application.Interfaces.IServices;
using ElectronicShop.Domain.Common;
using ElectronicShop.Domain.Entities;
using ElectronicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace ElectronicShop.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;
        public ProductService(IRepository repository)
        {
            this.repository = repository;
        }

        public List<IdNameDto> GetAllProducts()
        {
            try
            {
                var productList = repository.GetAllWhereQ<Product>(p => p.IsActive == true)
                    .Select(c => new IdNameDto
                    {
                        Id = c.Id,
                        NameAr = c.NameAr,
                        NameEn = c.NameEn
                    }).ToList();

                return productList;

            }
            catch (Exception ex)
            {
                return new List<IdNameDto>();
            }
        }

        public Product GetProduct(int productId)
        {
            try
            {
                if (productId == 0)
                    return null;

                var product = repository.GetAllWhereQ<Product>(p => p.Id == productId).FirstOrDefault();

                return product;
            }
            catch(Exception e)
            {
                return new Product();
            }
        }

        public List<Product> GetProducts(int categoryId, int start, int skip, string orderCol, out int totalCount)
        {
            try
            {
                var productList = repository.GetAllWhereQ<Product>(p => p.IsActive == true &&
                (categoryId == 0 || p.CategoryId == categoryId) , p => p.Category);

                productList = productList.OrderBy(orderCol);

                totalCount = productList.Count();

                return productList.Skip(skip).Take(start).ToList();
            }
            catch (Exception ex)
            {
                totalCount = 0;
                return new List<Product>();
            }
        }

        public DbOperationStatusEnum SaveProduct(Product product)
        {
            try
            {
                if (product.Id == 0)
                    repository.Add<Product>(product);
                else
                    repository.Update<Product>(product);

               var isSuccess = repository.SaveChangesAsync();

                return isSuccess ? DbOperationStatusEnum.Success : DbOperationStatusEnum.Failed;
            }catch(Exception ex)
            {
                return DbOperationStatusEnum.Failed;
            }
        }

        public DbOperationStatusEnum SetProductStatus(int productId)
        {
            try
            {
                if (productId == 0)
                    return DbOperationStatusEnum.ItemNotExist;

                var product = repository.GetAllWhereQ<Product>(p => p.Id == productId).FirstOrDefault();
                repository.Update<Product>(product);
                product.IsActive = false;

                var isSuccess = repository.SaveChangesAsync();

                return isSuccess ? DbOperationStatusEnum.Success : DbOperationStatusEnum.Failed;

            }
            catch(Exception ex)
            {
                return DbOperationStatusEnum.Failed;
            }
        }
    }
}
