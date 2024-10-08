using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Windows.Models;
using MVC_Windows.Data;

namespace MVC_Windows.Controllers;

public class UserController : Controller
{
    private readonly ApplicationDBContext _context;
    public UserController(ApplicationDBContext context){
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string username)
    {
        if(username == "Serhat"){
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
}
