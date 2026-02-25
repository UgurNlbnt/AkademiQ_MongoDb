using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productServices.GetAllProductAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productServices.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var value = await _productServices.GetProductByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productServices.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
    }
}