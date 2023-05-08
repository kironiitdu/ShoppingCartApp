using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.ExtensionMethod;
using ShoppingCartApp.Models;
using System.Diagnostics;

namespace ShoppingCartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Remove(CartItem item)
        {
            if (item == null)
            {
                return View("Index");
            }
            //Calling Item Remove Method and passing cart item
            RemoveItemFromCart(item);

            return View("Index");
        }
        public void RemoveItemFromCart(CartItem item)
        {
            Console.WriteLine($"Your function has executed item: {item.ItemName}");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}