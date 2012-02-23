using System.Data.Entity;
using JoarOyen.OneStepIntoTheCloud.Core.Model;

namespace JoarOyen.OneStepIntoTheCloud.Core.Repository
{
    public interface IOneStepIntoTheCloudRepository
    {
        DbSet<Movie> Movies { get; set; }
    }
}