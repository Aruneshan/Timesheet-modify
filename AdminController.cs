#nullable disable
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Original.Data;
using Original.Models;

namespace Original.Controllers;
public class AdminController : Controller
{
    private readonly OriginalContext _db;
    private readonly ILogger<HomeController> _logger;
    //DATABASE
    public AdminController(OriginalContext db,ILogger<HomeController> logger)
    {
        _db = db;
        _logger = logger;
    }
    //GET
    public IActionResult Create()
    {
         
          return View();
    }
    
    //GET
    public IActionResult Index()
    {
        var objLoginList = _db.Login.ToList();
        return View(objLoginList);
        /*
        ViewBag.userEmailId=HttpContext.Session.GetString("emailId");
        ViewBag.status = HttpContext.Session.GetString("status");
        ViewBag.username = HttpContext.Session.GetString("username");
        ViewBag.usermode = HttpContext.Session.GetString("usermode");
        if(@ViewBag.status == "logged"){
            return View();
        }else{
            return RedirectToRoute(new{controller ="Home",action="login"});
        }*/
    }
    //GET
    public IActionResult Forgot()
    {
        return View();
    }
    //GET
    public IActionResult master()
    {
        ViewBag.Session=HttpContext.Session.GetString("Session");
        return View();
    }
    //GET
    public IActionResult Details()
    {
        return View();
    }
    //GET
    public IActionResult Edit()
    {
        return View();
    }
    //GET
    public IActionResult Calendar()
    {
            return View();
    }
    //GET
    public IActionResult Timesheet(){
        return View();
    }
    //GET
    public IActionResult Error(Login SessionObject)
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Login obj)
    {
        string EmailId=obj.EmailId;
        string Password = obj.Password;
        Console.WriteLine(EmailId);
        Console.WriteLine(Password);
        
       var data=_db.Login.Find(EmailId);
       var password = _db.Login.Find(Password);
       if(data==null)
       {
        ViewBag.Message="MailId doesn't found";
        return View();
       }
       else if (password == null)
       {
        ViewBag.Message = "Password does not match";
        return View();
       }
       else
       {
       
       HttpContext.Session.SetString("Session",@obj.EmailId);
        ViewBag.Message="Login Successful";
        Console.WriteLine(ViewBag.Message);
        return RedirectToAction("master");
       
    }
 }
}