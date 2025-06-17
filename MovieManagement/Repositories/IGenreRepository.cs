using MovieManagement.Models;

namespace MovieManagement.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByMovieIdAsync(int movieId);
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
        Task<bool> GenreExistsAsync(int id);
    }
}