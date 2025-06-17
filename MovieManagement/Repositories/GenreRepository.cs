using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.Models;

namespace MovieManagement.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieContext _context;

        public GenreRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreByMovieIdAsync(int movieId)
        {
            var genre = await _context.Genres.FindAsync(movieId);
            if (genre == null)
                throw new InvalidOperationException($"Genre with MovieId {movieId} not found.");
            return genre;
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> GenreExistsAsync(int id)
        {
            return await _context.Genres.AnyAsync(e => e.Id == id);
        }
    }
}