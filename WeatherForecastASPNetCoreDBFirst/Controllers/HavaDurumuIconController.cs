using Microsoft.AspNetCore.Mvc;
using WeatherForecastASPNetCoreDBFirst.Models;

namespace WeatherForecastASPNetCoreDBFirst.Controllers
{
    public class HavaDurumuIconController : Controller
    {
        public readonly WeatherForecastDBContext dbcontext;
        public HavaDurumuIconController(WeatherForecastDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var list = dbcontext.HavaDurumuIcons.ToList();
            return View(list);
        }
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(HavaDurumuIcon hvdrmicn)
        {
            dbcontext.HavaDurumuIcons.Add(hvdrmicn);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var findid = dbcontext.HavaDurumuIcons.Find(id);
            return View(findid);

        }
        [HttpPost]
        public IActionResult Edit(HavaDurumuIcon havadurumu)
        {
            dbcontext.Update(havadurumu);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete (int id)
        {

            var findid = dbcontext.HavaDurumuIcons.Find(id);
            dbcontext.HavaDurumuIcons.Remove(findid);
            dbcontext.SaveChanges(true);
            return RedirectToAction("Index");

        }
    }
}
