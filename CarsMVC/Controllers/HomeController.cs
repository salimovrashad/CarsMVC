using CarsMVC.Context;
using CarsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarsMVC.Controllers
{
    public class HomeController : Controller
    {
        CarsDbContext _db { get; }

        public HomeController(CarsDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Accesories.ToList());
        }
    }
}