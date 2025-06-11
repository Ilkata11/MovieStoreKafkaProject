using MovieStore.External.Interfaces;
using MovieStore.Models;
using MovieStore.Models.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieStore.External.Services
{
    public class ExternalPostService : IExternalPostService
    {
        private readonly HttpClient _httpClient;

        public ExternalPostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Movie>> GetExternalMoviesAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Демонстрация — създаване на фалшиви филми от "posts"
            var posts = JsonConvert.DeserializeObject<List<dynamic>>(content);

            var movies = new List<Movie>();
            foreach (var post in posts)
            {
                movies.Add(new Movie
                {
                    Id = post.id,
                    Title = post.title,
                    Genre = "External"
                });
            }

            return movies;
        }
    }
}
