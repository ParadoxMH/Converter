using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CurencyConverter.Models;
using NbyClient;

namespace CurencyConverter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var rep = new CurrencyRepository();
            return View(rep.ListAll());
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
