using System.Runtime.Serialization;

namespace JoarOyen.OneStepIntoTheCloud.Core.Model
{
    [DataContract(Namespace = "http://message.joaroyen.com/2012/01/OneStepIntoTheCloud")]
    public class Movie
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Year { get; set; }
    }
}