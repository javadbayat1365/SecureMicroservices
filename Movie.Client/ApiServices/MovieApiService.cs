namespace Movie.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        public Task<List<Models.Movie>> GetAll()
        {
            return Task.FromResult(new List<Models.Movie>() {
             new Models.Movie()
             {
                  CreatedAt = DateTime.Now,
                  Genre = "Sienc Fiction",
                  Id = 1,
                  Name = "Test",
                  Owner ="Javad Bayat"
             }
            });
        }
    }
}
