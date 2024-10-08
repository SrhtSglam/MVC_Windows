using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Windows.Models;
using MVC_Windows.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
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
        string isLogin = HttpContext.Session.GetString("isLogin")!;
        if(isLogin == "True"){
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
        string isLogin = HttpContext.Session.GetString("isLogin")!;
        if(isLogin == "True"){
            return RedirectToAction("Success", "User", model);
        }
        else{
            foreach(var item in model.CustomerModelList){
                if(username == item.Username){
                    HttpContext.Session.SetString("isLogin", "True");
                    return RedirectToAction("Index", "User", model);
                }
            }
        }
        return View();
    }
}
