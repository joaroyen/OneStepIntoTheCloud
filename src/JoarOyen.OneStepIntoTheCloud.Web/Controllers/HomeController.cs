using System;
using System.Web.Mvc;
using JoarOyen.OneStepIntoTheCloud.Core.Service.MovieService;

namespace JoarOyen.OneStepIntoTheCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(CacheProfile = "LongLived")]
        public ActionResult Index()
        {
            var movieServiceClient = new MovieServiceClient();
            try
            {
                var movies = movieServiceClient.List1001MoviesToWatchBeforeYouDie();
                movieServiceClient.Close();

                return View(movies);
            }
            catch (Exception)
            {
                movieServiceClient.Abort();
                throw;
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
