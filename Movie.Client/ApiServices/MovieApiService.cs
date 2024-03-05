using IdentityModel.Client;
using Movie.Client.Models;
using Newtonsoft.Json;

namespace Movie.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public MovieApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Models.Movie>> GetMovies()
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");
            var request = new HttpRequestMessage(HttpMethod.Get,"/api/movies/");
            var response = await httpClient.SendAsync(request,HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<List<Models.Movie>>(content);
            return movies;
        }
    }
}
