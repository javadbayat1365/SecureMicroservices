using Microsoft.AspNetCore.Mvc;
using Movie.Client.ApiServices;

namespace Movie.Client.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieApiService _movieApi;
    public MoviesController(IMovieApiService movieApi)
    {
        _movieApi = movieApi;
    }

    // GET: Movies
    public async Task<IActionResult> Index()
    {
        return View(await _movieApi.GetAll());
    }

}
