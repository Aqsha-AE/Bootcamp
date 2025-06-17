using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieManagement.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> GetByIdWithGenresAsync(int id)
        {
            return await _context.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllWithGenresAsync()
        {
            return await _context.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .ToListAsync();
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateMovieGenresAsync(int movieId, IEnumerable<int> genreIds)
        {
            // Remove existing genres
            var existingGenres = _context.MovieGenres.Where(mg => mg.MovieId == movieId);
            _context.MovieGenres.RemoveRange(existingGenres);

            // Add new genres
            foreach (var genreId in genreIds)
            {
                _context.MovieGenres.Add(new MovieGenre
                {
                    MovieId = movieId,
                    GenreId = genreId
                });
            }

            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Movies.AnyAsync(m => m.Id == id);
        }
    }
