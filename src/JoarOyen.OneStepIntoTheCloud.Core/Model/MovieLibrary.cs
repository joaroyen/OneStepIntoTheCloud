using System.Collections.Generic;
using System.Linq;
using JoarOyen.OneStepIntoTheCloud.Core.Repository;

namespace JoarOyen.OneStepIntoTheCloud.Core.Model
{
    public class MovieLibrary
    {
        private readonly IOneStepIntoTheCloudRepository _repository;

        public MovieLibrary()
        {
            _repository = new OneStepIntoTheCloudRepository();
        }

        public IEnumerable<Movie> List1001MoviesToWatchBeforeYouDie()
        {
            return _repository.Movies.Take(1001);
        }
    }
}