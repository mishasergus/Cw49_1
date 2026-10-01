using Microsoft.AspNetCore.Mvc;
using Cw49_1.DTOs;
using Cw49_1.Services;

namespace Cw49_1.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserDto user)
    {
        var res = await _userService.LoginAsync(user);
        if (res == null || string.IsNullOrEmpty(res.Token))
        {
            ViewBag.Error = "Невірний логін або пароль";
            return View(user);
        }

        Response.Cookies.Append("jwt_token", res.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });

        return RedirectToAction("Index", "Profile");
    }

    [HttpGet]
    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signup(UserDto user)
    {
        var res = await _userService.SignupAsync(user);
        if (res == null || string.IsNullOrEmpty(res.Token))
        {
            ViewBag.Error = "Користувач вже існує або дані некоректні";
            return View(user);
        }

        Response.Cookies.Append("jwt_token", res.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });

        return RedirectToAction("Index", "Profile");
    }

    [HttpGet]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt_token");
        return RedirectToAction("Login");
    }
}