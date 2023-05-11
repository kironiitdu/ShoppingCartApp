using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCartApp.ExtensionMethod;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Controllers
{
    public class ShoppingCartController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(CartItem item)
        {
            AddToCart(item);

            return View("Index");
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
        public IActionResult RemoveAllItems()
        {

            //Calling Item Remove Method and passing cart item
            RemoveAllItemFromCart();

            return View("Index");
        }
        public IActionResult CheckOut()
        {
            //Do Check out stuff here


            //Clear your shopping cart once checkout stuff done
            RemoveAllItemFromCart();

            return View("Index");
        }
        public void AddToCart(CartItem item)
        {

            var cart = HttpContext.Session.GetComplexObjectSession<ShoppingCartObject>("ShoppingCart");
            if (cart != null)
            {
                cart!.CartItems!.Add(item);
                HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);
            }
            else
            {
                cart = new ShoppingCartObject();
                cart!.CartItems!.Add(item);
                HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);
            }

        }
        public void RemoveAllItemFromCart()
        {
            var cart = HttpContext.Session.GetComplexObjectSession<ShoppingCartObject>("ShoppingCart");
            if (cart != null)
            {
                foreach (var item in new List<CartItem>(cart.CartItems))
                {
                    cart!.CartItems!.Remove(item);
                    HttpContext.Session.SetComplexObjectSession("ShoppingCart", item);
                }
            }
           
            
            
        }
        public void RemoveItemFromCart(CartItem item)
        {
            var cart = HttpContext.Session.GetComplexObjectSession<ShoppingCartObject>("ShoppingCart");
            cart!.CartItems!.Remove(cart.CartItems.Find(cartItem => cartItem.ItemName == item.ItemName));
            HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);
        }
    }

    
}
