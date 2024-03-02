namespace Movie.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<List<Models.Movie>> GetAll();
    }
}
