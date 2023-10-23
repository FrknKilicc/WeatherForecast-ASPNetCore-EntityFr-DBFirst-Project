using Microsoft.AspNetCore.Mvc;
using WeatherForecastASPNetCoreDBFirst.Models;

namespace WeatherForecastASPNetCoreDBFirst.Controllers
{
    public class KullanicilarController : Controller
    {
        public readonly WeatherForecastDBContext Context;
        public KullanicilarController(WeatherForecastDBContext Context)
        {
            this.Context = Context;
        }
        public IActionResult Index()
        {

            return View(Context.Kullanicilars.ToList());
        }          
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Kullanicilar());
        }
        [HttpPost]
        public IActionResult Create(Kullanicilar kullancilar)
        {
            Context.Kullanicilars.Add(kullancilar);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
          
            
            var findid = Context.Kullanicilars.Find(id);
            return View(findid);
        }

        [HttpPost]

        public IActionResult Edit(Kullanicilar kullanici)
        {
            Context.Kullanicilars.Update(kullanici);
            
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var findid = Context.Kullanicilars.Find(id);
            Context.Kullanicilars.Remove(findid);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
