using MovieStore.Models;
using MovieStore.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.BL.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task<IEnumerable<Movie>> FetchExternalMoviesAsync();
    }
}
