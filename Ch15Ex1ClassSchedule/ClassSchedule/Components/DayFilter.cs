using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;

namespace ClassSchedule.Components
{
    public class DayFilter : ViewComponent
    {
        private IRepository<Day> data { get; set; }

        public DayFilter(IRepository<Day> rep)
        {
            data = rep;
        }

        public IViewComponentResult Invoke()
        {
            var options = new QueryOptions<Day> {
                OrderBy = d => d.DayId
            };
            return View(data.List(options));
        }
    }
}
