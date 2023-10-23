using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherForecastASPNetCoreDBFirst.Models;
using System.Linq;

namespace WeatherForecastASPNetCoreDBFirst.Controllers
{
    public class HavaDurumuController : Controller
    {
        public readonly WeatherForecastDBContext dbContext;
        public HavaDurumuController(WeatherForecastDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var list = dbContext.HavaDurumus.Include("Sehir").ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["SehirId"] = new SelectList(dbContext.Sehirlers, "SehirId", "SehirAdi");
            return View();
        }
        [HttpPost]
        public IActionResult Create(HavaDurumu havadrm)
        {
            dbContext.HavaDurumus.Add(havadrm);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
          
            ViewData["SehirId"] = new SelectList(dbContext.Sehirlers, "SehirId", "SehirAdi");
            var findid = dbContext.HavaDurumus.Find(id);
            return View(findid);
        }
        [HttpPost]
        public IActionResult Edit(HavaDurumu havadrm)
        {
            dbContext.HavaDurumus.Update(havadrm);
            dbContext.SaveChanges(true);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
          
            dbContext.Remove(dbContext.HavaDurumus.Find(id));
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
