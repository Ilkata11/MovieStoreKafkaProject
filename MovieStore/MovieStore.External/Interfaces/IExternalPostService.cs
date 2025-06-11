using MovieStore.Models;
using MovieStore.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.External.Interfaces
{
    public interface IExternalPostService
    {
        Task<IEnumerable<Models.Models.Movie>> GetExternalMoviesAsync();
    }
}
