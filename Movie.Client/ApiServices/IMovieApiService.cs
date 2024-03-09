using Movie.Client.Models;

namespace Movie.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<List<Models.Movie>> GetMovies();
        Task<UserInfoViewModel> GetUserInfo();
    }
}
