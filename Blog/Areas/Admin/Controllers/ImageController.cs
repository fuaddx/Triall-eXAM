using Blog.Context;
using Blog.Models;
using Blog.ViewModels.ImageVm;
using Blog.ViewModels.SliderVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageController : Controller
    {
        DataDbContext _db;

        public ImageController(DataDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Image.Select(c=> new ImageListVM
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
            }).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult>Create(ImageCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Image image = new Image
            {
                ImageUrl = vm.ImageUrl
            };
            await _db.Image.AddAsync(image);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Image.FindAsync(id);
            if (data == null) return NotFound();
            return View(new ImageUpdateVm
            {
                ImageUrl = data.ImageUrl,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,  ImageUpdateVm vm)
        {
            if (id == null) return BadRequest();
            /*if (!ModelState.IsValid)
            {
                return View(vm);
            }*/
            var data = await _db.Image.FindAsync(id);
            if (data == null) return NotFound();
            data.ImageUrl = vm.ImageUrl;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Image.FindAsync(id);
            if (data == null) return NotFound();
            _db.Image.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
