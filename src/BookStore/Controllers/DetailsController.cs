using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class DetailsController : Controller
{
    private readonly IKontentAIClient _kontentAIClient;

    public DetailsController(IKontentAIClient kontentAIClient)
    {
        _kontentAIClient = kontentAIClient;
    }

    public async Task<IActionResult> Index(string codename)
    {
        var referer = Request.Headers["Referer"];
        referer = referer.Any() ? referer : "/";
        var data = await _kontentAIClient.GetItemAsync<Book>(codename);
        var model = new Details(data.Item, referer);
        return View(model);
    }

}
