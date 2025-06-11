using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.External.Interfaces;
using MovieStore.Models;
using MovieStore.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IExternalPostService _externalPostService;

        public MovieService(IMovieRepository movieRepository, IExternalPostService externalPostService)
        {
            _movieRepository = movieRepository;
            _externalPostService = externalPostService;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
        }

        public async Task<IEnumerable<Movie>> FetchExternalMoviesAsync()
        {
            // Пример за извикване на външен ендпойнт
            return await _externalPostService.GetExternalMoviesAsync();
        }
    }
}
