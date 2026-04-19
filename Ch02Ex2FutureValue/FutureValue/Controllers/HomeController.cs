using FutureValue.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutureValue.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.Title = "Future Value";
            return View(new FutureValueModel());
        }

        [HttpPost]
        public ViewResult Index(FutureValueModel model)
        {
            ViewBag.Title = "Future Value";

            // Only calculate when the form data passes validation.
            if (ModelState.IsValid)
            {
                model.FutureValue = model.CalculateFutureValue();
            }
            else
            {
                model.FutureValue = null;
            }

            return View(model);
        }
    }
}
