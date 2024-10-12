using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace RoutingPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Home");
        }

        public IActionResult Privacy()
        {
            return Content("Privacy");
        }

        public IActionResult Display(string id)
        {
            if (id == null) {
                return Content("No ID supplied.");
            }
            else {
                return Content("ID: " + id);
            }
        }

        [Route("[action]/{start}/{end?}/{message?}")]
        public IActionResult Countdown(int start, int end = 0, string message = "")
        {
            StringBuilder countdown = new StringBuilder("Counting down: ");

            for (int i = start; i >= end; i--)
            {
                countdown.Append(i + " ");
            }

            if (!string.IsNullOrEmpty(message))
            {
                countdown.Append(message);
            }
            else
            {
                countdown.Append("Liftoff!");
            }

            return Content(countdown.ToString());
        }
    }
}