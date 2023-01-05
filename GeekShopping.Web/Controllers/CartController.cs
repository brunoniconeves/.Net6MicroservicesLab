using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
  public class CartController : Controller
  {

    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public CartController(IProductService productService, 
        ICartService cartService)
    {
      _productService = productService ?? throw new ArgumentNullException(nameof(productService));
      _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }

    public async Task<IActionResult> CartIndex()
    {      
      return View(await FindUserCart());
    }

    private async Task<CartViewModel> FindUserCart()
    {
      var accessToken = await HttpContext.GetTokenAsync("access_token");
      var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

      var response = await _cartService.FindCartByUserId(userId, accessToken);

      if (response?.CartHeader != null)
      {
        foreach (var detail in response.CartDetails)
        {
          response.CartHeader.PurchaseAmount += (detail.Count * detail.Product.Price);
        }

        return response;
      }
      else
      {
        return NotFound();
      }
    }
  }
}
