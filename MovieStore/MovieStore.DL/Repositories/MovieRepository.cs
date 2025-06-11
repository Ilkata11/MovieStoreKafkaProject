using MovieStore.DL.Interfaces;
using MovieStore.Models;

namespace MovieStore.DL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static readonly List<Movie> _movies = new();

        public Task<List<Movie>> GetAllAsync() => Task.FromResult(_movies);

        public Task<Movie?> GetByIdAsync(string id) =>
            Task.FromResult(_movies.FirstOrDefault(m => m.Id == id));

        public Task AddAsync(Movie movie)
        {
            _movies.Add(movie);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie != null) _movies.Remove(movie);
            return Task.CompletedTask;
        }
    }
}
