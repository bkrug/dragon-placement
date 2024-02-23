using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Repository;

namespace DragonApi.Controllers
{
    [ApiController]
    [Route("dragon")]
    public class DragonController : Controller
    {
        private readonly IDragonGetter _dragonGetter;

        public DragonController(IDragonGetter dragonGetter)
        {
            _dragonGetter = dragonGetter;
        }

        //// GET: DragonController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet(Name = "GetDragon")]
        public int Get(int id)
        {
            return _dragonGetter.GetDragon(id)?.Id ?? 0;
        }

        //// GET: DragonController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DragonController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DragonController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DragonController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DragonController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DragonController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
