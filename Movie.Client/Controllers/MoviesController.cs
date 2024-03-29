﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movie.Client.ApiServices;
using System.Diagnostics;

namespace Movie.Client.Controllers;

[Authorize]
public class MoviesController : Controller
{
    private readonly IMovieApiService _movieApi;
    public MoviesController(IMovieApiService movieApi)
    {
        _movieApi = movieApi;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await LogTokenAndClaims();
        return View(await _movieApi.GetMovies());
    }

    [HttpGet]
    [Authorize(Roles ="admin")]
    public async Task<IActionResult> OnlyAdmin()
    {
        var userInfo = await _movieApi.GetUserInfo();
        return View(userInfo);
    }

    public async Task LogTokenAndClaims()
    {
        var idnetityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

        Debug.WriteLine($"identity token: {idnetityToken}");
        foreach (var item in User.Claims)
        {
            Debug.WriteLine($"claim type:{item.Type} and claim value: {item.Value}");
        }
    }

    public async Task Logout()
    {
        //SignOut("Cookies", "oidc");
       await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
       await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
    }

}
