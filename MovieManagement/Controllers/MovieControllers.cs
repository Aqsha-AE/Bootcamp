using Microsoft.AspNetCore.Mvc;
using MovieManagement.DTOs;
using MovieManagement.Services;
using System.Threading.Tasks;
using MovieManagement.Models;
using FluentValidation;
using MovieManagement.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;

// Hapus decorator API dan ganti dengan Controller
public class MovieController : Controller
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    // GET: Movie
    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAllMovieAsync();
        return View(movies); // Kembalikan View dengan model
    }

    // GET: Movie/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    // GET: Movie/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movie/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MovieCreateDTO dto)
    {
        if (ModelState.IsValid) return View(dto);
        await _movieService.CreateMovieAsync(dto);
        var genres = await _movieService.GetAllGenresAsync();
        ViewBag.Genres = new MultiSelectList(genres, "Id", "Name");
        return View();
    }

    // GET: Movie/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (id <= 0) return NotFound();
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    // POST: Movie/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MovieUpdateDTO movieUpdatedto)
    {
        if (id != movieUpdatedto.Id) return NotFound();

        //modelstatenya harusnya di service
        if (ModelState.IsValid) return View(movieUpdatedto);

        var result = await _movieService.UpdateMovieAsync(id, movieUpdatedto);
        if (!result) return NotFound();

        var genres = await _movieService.GetAllGenresAsync();
        ViewBag.Genres = new MultiSelectList(genres, "Id", "Name");

        return RedirectToAction(nameof(Index));
    }

    // GET: Movie/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    // POST: Movie/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _movieService.DeleteMovieAsync(id);
        if (!result) return NotFound();
        return RedirectToAction(nameof(Index));
    }

    // GET: Movie/Genre
    public IActionResult CreateGenre()
    {
        return View();
    }

    // POST: Movie/Genre
    [HttpPost]
    public async Task<IActionResult> CreateGenre(GenreCreateDTO genre)
    {
        if (!ModelState.IsValid) return View(genre);
        //var createdGenre = await _movieService.AddGenreAsync(genre);
        return RedirectToAction(nameof(CreateGenre));
    }
}