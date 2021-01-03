using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicShop.Application.Interfaces.IServices;
using ElectronicShop.Domain.Entities;
using ElectronicShop.Domain.Enums;
using ElectronicShop.Infrastructure.Helpers;
using ElectronicShop.Resources;
using ElectronicShop.WebUI.Common.DataTables;
using ElectronicShop.WebUI.Common.UiUtilities;
using ElectronicShop.WebUI.Models;
using ElectronicShop.WebUI.Models.Product;
using ElectronicShop.WebUI.Models.Shared;
using ElectronicShop.WebUI.Resources.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicShop.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper mapper;

        #region Ctor

        public ProductController(IProductService productService , ICategoryService categoryService , IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            this.mapper = mapper;
        }

        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            var categoriesList = _categoryService.GetAllCategories();
            ViewBag.ListofCategories = DdlHelper.GetSelectListItems(categoriesList , true , false);
            return View();
        }

        public async Task<IActionResult> GetProducts([FromBody] DtParameters dtParameters, int categoryId)
        {
            var orderString = DataTablesHelper.GetOrderStringFromDtParams(nameof(ProductViewModel.Id), dtParameters, new Dictionary<string, string>()
            {
                { nameof(ProductViewModel.Id),nameof(ProductViewModel.Id) }
            });
            int totalCount = 0;
            var products = _productService.GetProducts(categoryId, Constants.PageSize, dtParameters.Start , orderString , out totalCount);
            var productsViewModelList = new List<ProductViewModel>();
            products.ForEach(p =>
            {
                var viewModel = mapper.Map<Product, ProductViewModel>(p);
                viewModel.CategoryNameEn = p.Category.NameEn;
                viewModel.CategoryNameAr = p.Category.NameAr;

                productsViewModelList.Add(viewModel);
            });

            var data = new DataTablesResponseViewModel(dtParameters.Draw, productsViewModelList, totalCount, totalCount);

            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.ListofCategories = DdlHelper.GetSelectListItems(_categoryService.GetAllCategories(), false, true);
            return View(new ProductViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var model = new ProductViewModel();
            try
            {
                var product = _productService.GetProduct(Id);

                if (product == null)
                    return RedirectToAction("Index");

                ViewBag.ListofCategories = DdlHelper.GetSelectListItems(_categoryService.GetAllCategories(), false, true);
                model = mapper.Map<ProductViewModel>(product);
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new ProductViewModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveProduct(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var product = mapper.Map<Product>(model);
                    product.IsActive = true;
                    var status = _productService.SaveProduct(product);
                    TempData[Constants.SuccessMessage] = Messages.AddSuccess;

                    return Json(GetJsonResponse(status));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                TempData[Constants.ErrorMessage] = Messages.CreateFailure;
                return View(model);
            }
        }

        public async Task<IActionResult> SetProductStatus(int productId)
        {
            var status = _productService.SetProductStatus(productId);

            return Json(new JsonSaveResponseResult
            {
                OperationStatus = status == DbOperationStatusEnum.Success ? Constants.SuccessStatus : Constants.FailStatus,
                Message = status == DbOperationStatusEnum.Success ? ErrorMessages.Success : ErrorMessages.Error
            });
        }

        #region Private Methods

        private JsonSaveResponseResult GetJsonResponse(DbOperationStatusEnum status)
        {
            string message = Constants.ErrorMessage;

            switch (status)
            {
                case DbOperationStatusEnum.Success:
                    message = Messages.AddSuccess;
                    break;
                case DbOperationStatusEnum.Failed:
                    message = Messages.CreateFailure;
                    break;
            }

            return new JsonSaveResponseResult
            {
                OperationStatus = status == DbOperationStatusEnum.Success ? Constants.SuccessStatus : Constants.FailStatus,
                MessageType = status == DbOperationStatusEnum.Success
                    ? AlertType.Success.ToString()
                    : AlertType.Warning.ToString(),
                Message = message
            };
        }

        #endregion
    }
}
