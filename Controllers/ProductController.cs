using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_baranova.Models;

namespace wt_lab4_4mvc_baranova.Controllers;

public class ProductController : Controller
{
    // База данных не используется — данные хранятся в памяти приложения
    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Ноутбук",    Category = "Компьютеры", Price = 2500, IsAvailable = true },
        new Product { Id = 2, Name = "Мышь",       Category = "Аксессуары", Price = 80,   IsAvailable = true },
        new Product { Id = 3, Name = "Клавиатура", Category = "Аксессуары", Price = 150,  IsAvailable = false },
        new Product { Id = 4, Name = "Монитор",    Category = "Компьютеры", Price = 900,  IsAvailable = true },
        new Product { Id = 5, Name = "Наушники",   Category = "Аудио",      Price = 320,  IsAvailable = true },
        new Product { Id = 6, Name = "Смартфон",   Category = "Телефоны",   Price = 1800, IsAvailable = true },
    };

    private static int nextId = 7;

    // GET /Product  или  /Product/Index — каталог товаров
    public IActionResult Index()
    {
        return View(Products);
    }

    // GET /Product/Details/1  или  /Product/Details?id=1
    public IActionResult Details(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound(); // 404 Not Found
        }

        return View(product);
    }

    // GET /Product/Create — показать форму
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Product { IsAvailable = true });
    }

    // POST /Product/Create — принять данные формы
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product); // показываем форму снова с сообщениями об ошибках
        }

        product.Id = nextId++;
        Products.Add(product);

        TempData["Message"] = $"Товар «{product.Name}» успешно добавлен.";
        return RedirectToAction("Index");
    }

    // GET /Product/Edit/1
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST /Product/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Product product)
    {
        var existing = Products.FirstOrDefault(p => p.Id == id);

        if (existing == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            product.Id = id;
            return View(product);
        }

        existing.Name = product.Name;
        existing.Category = product.Category;
        existing.Price = product.Price;
        existing.IsAvailable = product.IsAvailable;

        TempData["Message"] = $"Товар «{existing.Name}» успешно изменён.";
        return RedirectToAction("Index");
    }

    // POST /Product/Delete/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        Products.Remove(product);

        TempData["Message"] = $"Товар «{product.Name}» удалён.";
        return RedirectToAction("Index");
    }
}
