/*using Blog.Models;*/
using Blog.Context;
using Blog.ViewModels.HomeVm;
using Blog.ViewModels.ImageVm;
using Blog.ViewModels.SliderVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        DataDbContext _db {  get;}
        public HomeController(DataDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            HomeVm vm = new HomeVm
            {
                Sliders = await _db.Sliders.Select(s => new SliderListVM
                {
                    Id = s.Id,
                    Description = s.Description,
                }).ToListAsync(),
                Images = await _db.Image.Select(p => new ImageListVM
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl
                }).ToListAsync()

            };
              return View(vm);
        }
    }
        

    
}
