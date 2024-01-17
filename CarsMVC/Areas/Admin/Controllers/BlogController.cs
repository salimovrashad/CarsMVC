using CarsMVC.Areas.Admin.ViewModels;
using CarsMVC.Context;
using CarsMVC.Helpers;
using CarsMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admins")]
    public class BlogController : Controller
    {
        CarsDbContext _context { get; }

        public BlogController(CarsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Accesories.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateItemVM vm)
        {
            Accesories accesories = new Accesories{
                Description = vm.Description,
                Name = vm.Name,
                ImageURL = await vm.ImageFile.SaveAsync(PathConstants.Product),
            };
            await _context.AddAsync(accesories);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var item = await _context.Accesories.FindAsync(id);
            return View(new BlogUpdateItemVM
            {
                Description = item.Description,
                Name = item.Name,
            });
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, BlogUpdateItemVM vm)
        {
            var item = await _context.Accesories.FindAsync(id);
            item.Description = vm.Description;
            item.Name = vm.Name;
            item.ImageURL = await vm.ImageFile.SaveAsync(PathConstants.Product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Accesories.FindAsync(id);
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
