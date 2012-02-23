using System.Collections.Generic;
using JoarOyen.OneStepIntoTheCloud.Core.Model;

namespace JoarOyen.OneStepIntoTheCloud.Core.Service.MovieService
{
    public class MovieServiceClient : System.ServiceModel.ClientBase<IMovieService>, IMovieService
    {
        public MovieServiceClient()
        {
        }
        
        public MovieServiceClient(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }
        
        public IEnumerable<Movie> List1001MoviesToWatchBeforeYouDie()
        {
            return Channel.List1001MoviesToWatchBeforeYouDie();
        }
    }
}
