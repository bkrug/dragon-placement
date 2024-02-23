using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace DragonApi.Controllers
{
    [ApiController]
    [Route("dragon")]
    public class DragonController : Controller
    {
        //// GET: DragonController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet(Name = "GetDragon")]
        public int Get(int id)
        {
            const string DATA_SOURCE = @"C:\Users\Benjamin Krug\source\repos\sqlLiteExp\dragon.db";
            using (var connection = new SqliteConnection($"Data Source={DATA_SOURCE}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
        SELECT *
        FROM Dragon
        WHERE id = $id
    ";
                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);

                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }
            return 5;
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
