using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class HomeController : Controller
{
    const int max_items = 10;
    private readonly IKontentAIClient _kontentAIClient;

    public HomeController(IKontentAIClient kontentAIClient)
    {
        _kontentAIClient = kontentAIClient;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        var model = await GetModel(page);
        return View(model);
    }

    private async Task<Home> GetModel(int page)
    {
        var skip = (page - 1) * max_items;
        var data = await _kontentAIClient.GetItemsAsync<Book>(skip, max_items);
        return new Home(data, max_items);
    }

}
