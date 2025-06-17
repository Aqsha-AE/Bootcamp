using System.Linq.Expressions;
using MovieManagement.Data;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Models;

namespace MovieManagement.Repositories;

public interface IMovieRepository
{
    Task<Movie> GetByIdAsync(int id);
    Task<Movie> GetByIdWithGenresAsync(int id);
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<IEnumerable<Movie>> GetAllWithGenresAsync();
    Task AddAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(int id);
    Task UpdateMovieGenresAsync(int movieId, IEnumerable<int> genreIds);
    Task<bool> ExistsAsync(int id);
}