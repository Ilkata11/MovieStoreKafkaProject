using MovieStore.Models;

namespace MovieStore.DL.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(string id);
        Task AddAsync(Movie movie);
        Task DeleteAsync(string id);
    }
}
