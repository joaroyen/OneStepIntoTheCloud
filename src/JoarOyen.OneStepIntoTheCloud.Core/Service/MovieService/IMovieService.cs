using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using JoarOyen.OneStepIntoTheCloud.Core.Model;

namespace JoarOyen.OneStepIntoTheCloud.Core.Service.MovieService
{
    [ServiceContract(Namespace = "http://service.joaroyen.com/2012/01/OneStepIntoTheCloud")]
    public interface IMovieService
    {
        [OperationContract]
        [WebGet(UriTemplate = "movies", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Movie> List1001MoviesToWatchBeforeYouDie();
    }
}
