using Microsoft.AspNetCore.Mvc;
using WeatherForecastASPNetCoreDBFirst.Models;

namespace WeatherForecastASPNetCoreDBFirst.Controllers
{
    public class SehirController : Controller
    {
        public readonly WeatherForecastDBContext db;
        public SehirController(WeatherForecastDBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Sehirlers.ToList());
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return  View(new Sehirler());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Sehirler sehirler)
        {
            await db.Sehirlers.AddAsync(sehirler);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var findid = db.Sehirlers.Find(id);
            return View(findid);
        }
        [HttpPost]
        public IActionResult Edit(int id, Sehirler sehirler)
        {
           
            db.Sehirlers.Update(sehirler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete (int id)
        {
            var findid = db.Sehirlers.Find(id);
            db.Sehirlers.Remove(findid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
