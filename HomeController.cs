using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;

public class HomeController : Controller {

    private readonly MyDbContext _db;

    public HomeController(MyDbContext db) {
        _db = db;
    }

    public IActionResult Index() {
        var list = _db.Todos.ToList();

        return View(list);
    }

    public string Indexex() {
        return "hello world by mvc";
    }
}