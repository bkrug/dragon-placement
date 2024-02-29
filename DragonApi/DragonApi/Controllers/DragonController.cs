using BusinessLogic;
using Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Model;

namespace DragonApi.Controllers
{
    [ApiController]
    [Route("dragon")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DragonController : Controller
    {
        private readonly IDragonLogic _dragonLogic;

        public DragonController(IDragonLogic dragonLogic)
        {
            _dragonLogic = dragonLogic;
        }

        [HttpGet("all-dragons")]
        public RowsWithRowCount<Dragon> Index(int skip = 0, int take = 10)
        {
            return _dragonLogic.Read(skip, take);
        }

        [HttpGet()]
        public Dragon Get(int id)
        {
            //TODO: Can we return 404 when the result is null?
            return _dragonLogic.Read(id);
        }

        [HttpPost()]
        public bool Create(DragonCreationContract dragon)
        {
            _dragonLogic.Insert(dragon);
            return true;
        }

        [HttpPut("{id}")]
        public bool Update([FromRoute]int id, DragonCreationContract dragon)
        {
            _dragonLogic.Update(id, dragon);
            return true;
        }

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
