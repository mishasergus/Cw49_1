using Cw49_1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cw49_1.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly IMovieService _movieService;

    public ProfileController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetMoviesAsync();
        return View(movies);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return RedirectToAction(nameof(Index));
        }

        var movie = await _movieService.GetMovieAsync(name);
        return View("Details", movie);
    }
}