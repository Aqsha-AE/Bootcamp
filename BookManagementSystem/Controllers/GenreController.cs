using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookManagementSystem.Data;
using BookManagementSystem.Models;
namespace BookManagementSystem.Controllers;
public class GenresController : Controller
{
    private readonly BookManagementContext _context;

    public GenresController(BookManagementContext context)
    {
        _context = context;
    }

    // GET: Genres/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}