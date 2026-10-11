using Microsoft.AspNetCore.Mvc;

namespace wt_lab4_4mvc_baranova.Controllers;

public class HomeController : Controller
{
    // GET /  или  GET /Home/Index
    public IActionResult Index()
    {
        return View();
    }

    // GET /Home/Status/404 — страница ошибки (вызывается автоматически при 404 и т.п.)
    public IActionResult Status(int id)
    {
        return View(id);
    }

    // Страница для необработанных исключений (не в режиме разработки)
    public IActionResult Error()
    {
        return View();
    }
}
