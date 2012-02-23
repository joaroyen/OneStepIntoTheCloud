using System.Web.Mvc;
using JoarOyen.OneStepIntoTheCloud.Core.Model;

namespace JoarOyen.OneStepIntoTheCloud.Web.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult Suggestion()
        {
            return View(new Movie());
        }

        [HttpPost]
        public ActionResult Suggestion(Movie movie)
        {
            var movieSuggestions = new Core.ServiceBus.Topic.MovieSuggestions();
            movieSuggestions.Send(movie);

            return RedirectToAction("Index", "Home");
        }
    }
}
