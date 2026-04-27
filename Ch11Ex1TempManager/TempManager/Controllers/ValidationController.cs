using Microsoft.AspNetCore.Mvc;
using TempManager.Models;

namespace TempManager.Controllers
{
    public class ValidationController : Controller
    {
        private TempManagerContext data { get; set; }

        public ValidationController(TempManagerContext ctx) => data = ctx;

        public JsonResult CheckDate(string date)
        {
            DateTime parsedDate = DateTime.Parse(date);
            Temp? temp = data.Temps.FirstOrDefault(t => t.Date == parsedDate);

            if (temp == null)
                return Json(true);
            else
                return Json("That date is already in the database.");
        }
    }
}
