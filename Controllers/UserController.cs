using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Windows.Models;
using MVC_Windows.Data;
using Microsoft.EntityFrameworkCore;
// using System.Web.Security;

namespace MVC_Windows.Controllers;

public class UserController : Controller
{
    private readonly ApplicationDBContext _context;
    public MyViewModel model = new MyViewModel();
    public UserController(ApplicationDBContext context){
        _context = context;
        if(model.CustomerModelList == null){
            model.CustomerModelList = new List<CustomerModel>();
        }
    }
    public IActionResult Index()
    {
        if(model.onLogin != false){
            return RedirectToAction("Success", "User");
        }
        return View();
    }
    public IActionResult Success()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        model.CustomerModelList = _context.customerModel.ToList();
        foreach(var item in model.CustomerModelList){
            if(model.onLogin == true){
                if(username == item.Username){
                    model.onLogin = true;
                    return RedirectToAction("Index", "Home", model);
                }
            }
            else{
                return RedirectToAction("Success", "User", model);
            }
        }
        return View();
    }
}
