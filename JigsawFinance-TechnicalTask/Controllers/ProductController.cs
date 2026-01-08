using JigsawFinance_TechnicalTask.Models;
using JigsawFinance_TechnicalTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace JigsawFinance_TechnicalTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // Action for paginated list.
        public async Task<IActionResult> Index(int page = 1)
        {
            int limit = 10; // Number of products per page.
            int skip = (page - 1) * limit;

            try
            {
                var response = await _productService.GetPagedProductsAsync(skip, limit);
                ViewBag.TotalPages = Math.Ceiling(response.Total / (double)limit);
                ViewBag.CurrentPage = page;
                return View(response.Products);
            }
            catch (Exception)
            {
                // Handle API failure
                return View("Error");
            }
        }
        // Action for product details.
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = await _productService.GetProductDetailsAsync(id);
                return View(product);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
