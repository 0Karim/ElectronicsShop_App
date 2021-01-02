using ElectronicShop.Domain.Common;
using ElectronicShop.Domain.Entities;
using ElectronicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Application.Interfaces.IServices
{
    public interface IProductService
    {
        List<Product> GetProducts(int categoryId ,int start , int skip , string orderCol , out int totalCount);
        DbOperationStatusEnum SaveProduct(Product product);
        Product GetProduct(int productId);
        DbOperationStatusEnum SetProductStatus(int productId);
        List<IdNameDto> GetAllProducts();
    }
}
