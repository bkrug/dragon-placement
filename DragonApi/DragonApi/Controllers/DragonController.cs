using BusinessLogic;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Model;

namespace DragonApi.Controllers
{
    [ApiController]
    [Route("dragon")]
    public class DragonController : Controller
    {
        private readonly IDragonRepository _dragonGetter;
        private readonly IDragonLogic _dragonLogic;

        public DragonController(IDragonRepository dragonGetter, IDragonLogic dragonLogic)
        {
            _dragonGetter = dragonGetter;
            _dragonLogic = dragonLogic;
        }

        [HttpGet("all-dragons")]
        public IList<Dragon> Index(int skip = 0, int take = 10)
        {
            return _dragonGetter.GetDragons(skip, take);
        }

        [HttpGet()]
        public Dragon Get(int id)
        {
            //TODO: Can we return 404 when the result is null?
            return _dragonGetter.GetDragon(id);
        }

        [HttpPost()]
        public bool Create(DragonCreationContract dragon)
        {
            _dragonLogic.CreateDragon(dragon);
            return true;
        }

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
