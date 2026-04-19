using FutureValue.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutureValue.Controllers
{
    public class HomeController : Controller
    {
        // Show the page the first time.
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.Title = "Future Value";
            return View(new FutureValueModel());
        }

        // Handle the form submit.
        [HttpPost]
        public ViewResult Index(FutureValueModel model)
        {
            ViewBag.Title = "Future Value";

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
