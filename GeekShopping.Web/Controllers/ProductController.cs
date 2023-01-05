using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAll("");
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductViewModel product)
        {
            if(ModelState.IsValid){
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.Create(product, token);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(product);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var product = await _productService.FindById(id, token);
            if (product != null) return View(product);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductViewModel product)
        {
            if(ModelState.IsValid){
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.Update(product, token);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(product);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var product = await _productService.FindById(id, token);
            if (product != null) return View(product);
            return NotFound();
        }

        
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductViewModel product)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteById(product.Id, token);
            if (response) return RedirectToAction(nameof(ProductIndex));
       

            return View(product);
        }
    }
}
