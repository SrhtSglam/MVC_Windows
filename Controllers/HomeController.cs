using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Windows.Models;

namespace MVC_Windows.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var query = HttpContext.Session.GetString("isLogin");
        if(query != "True")
            HttpContext.Session.SetString("isLogin", "False");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
