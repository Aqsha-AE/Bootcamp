using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookManagementSystem.Data;
using BookManagementSystem.Models;
namespace BookManagementSystem.Controllers;

public class BookController : Controller
{
    private readonly BookManagementContext _context;
    public BookController(BookManagementContext context)
    {
        _context = context;
    }

    // GET: Books/
    public async Task<IActionResult> Index()
    {
        return View(await _context.Books
        .Include(b => b.BookGenres)
        .ThenInclude(bg => bg.Genre)
        .ToListAsync());
    }

    // GET: Book/Details/6
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books
            .Include(b => b.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .Include(b => b.Stocks)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // GET : Book/Create
    public IActionResult Create()
    {
        ViewBag.Genres = _context.Genres.ToList();
        return View();
    }

    //POST : Book/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Description,Author,PublishedDate,SelectedGenreIds")]
    Book book, int[] selectedGenreIds)
    {
        if (ModelState.IsValid)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();

            if (selectedGenreIds != null)
            {
                foreach (var genreId in selectedGenreIds)
                {
                    _context.BookGenres.Add(new BookGenre
                    {
                        BookID = book.Id,
                        GenreID = genreId
                    });
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Genres = _context.Genres.ToList();
        return View(book);
    }

    // GET: Book/Edit/6
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books
        .Include(b => b.BookGenres)
        .FirstOrDefaultAsync(m => m.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        ViewBag.Genres = _context.Genres.ToList();
        return View(book);
    }

    //POST: Book/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,PublishedDate")]
    Book book, int[] selectedGenreIds)
    {
        if (id != book.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                //Update Book 
                _context.Update(book);

                //Update BookGenres 
                var existingGenres = await _context.BookGenres
                .Where(bg => bg.BookID == book.Id).ToListAsync();

                //Remove existing genres
                _context.BookGenres.RemoveRange(existingGenres);

                //Add Selected Genres 
                if (selectedGenreIds != null)
                {
                    foreach (var genreId in selectedGenreIds)
                    {
                        _context.BookGenres.Add(new BookGenre
                        { BookID = book.Id, GenreID = genreId });
                    }
                    await _context.SaveChangesAsync();
                }
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(e => e.Id == book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Genres = _context.Genres.ToList();
        return View(book);
    }

    //GET: Book/Delete/6
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books
        .Include(b => b.BookGenres)
        .ThenInclude(bg => bg.Genre)
        .FirstOrDefaultAsync(m => m.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    //POST : Book/Delete/6
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
}