using System.Collections.Generic;
using JoarOyen.OneStepIntoTheCloud.Core.Model;

namespace JoarOyen.OneStepIntoTheCloud.ServiceHost
{
    public class MovieService : Core.Service.MovieService.IMovieService
    {
        public IEnumerable<Movie> List1001MoviesToWatchBeforeYouDie()
        {
            var movieLibrary = new MovieLibrary();
            return movieLibrary.List1001MoviesToWatchBeforeYouDie();
        }
    }
}
