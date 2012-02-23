using System.Data.Entity;
using JoarOyen.OneStepIntoTheCloud.Core.Model;

namespace JoarOyen.OneStepIntoTheCloud.Core.Repository
{
    public class OneStepIntoTheCloudRepository : DbContext, IOneStepIntoTheCloudRepository
    {
        public DbSet<Movie> Movies { get; set; }
    }
}