using Microsoft.AspNetCore.Mvc;

//using SistemaBar.WebApp.Models;
using System.Diagnostics;

namespace SistemaBar.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}