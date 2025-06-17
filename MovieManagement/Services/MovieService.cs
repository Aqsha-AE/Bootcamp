namespace MovieManagement.Services;
using AutoMapper;
using MovieManagement.DTOs;
using MovieManagement.Models;
using MovieManagement.Repositories;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;
    public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MovieDTO>> GetAllMovieAsync()
    {
        try
        {
            var movies = await _movieRepository.GetAllWithGenresAsync();
            var movieDTOs = _mapper.Map<IEnumerable<MovieDTO>>(movies);
            return movieDTOs;
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<MovieDTO>();
        }
    }
    public async Task<MovieDTO> GetMovieByIdAsync(int id)
    {
        try
        {
            var movie = await _movieRepository.GetByIdWithGenresAsync(id);
            if (movie == null)
            {
                return new MovieDTO { Title = "Movie not found" };
            }
            return _mapper.Map<MovieDTO>(movie);
        }
        catch (Exception ex)
        {
            return new MovieDTO { Title = "Error Movie" };
        }
    }
    public async Task<MovieDTO> CreateMovieAsync(MovieCreateDTO movieCreateDTO)
    {
        var movie = _mapper.Map<Movie>(movieCreateDTO);
        await _movieRepository.AddAsync(movie);
        return _mapper.Map<MovieDTO>(movie);
    }
    public async Task<bool> UpdateMovieAsync(int id, MovieUpdateDTO movieUpdateDTO)
    {
        var existingMovie = await _movieRepository.GetByIdAsync(id);
        if (existingMovie == null)
        {
            return false;
        }

        _mapper.Map(movieUpdateDTO, existingMovie);
        await _movieRepository.UpdateAsync(existingMovie);
        return true;
    }
    public async Task<bool> ExistsAsync(int id)
    {
        return await _movieRepository.ExistsAsync(id);
    }
    public async Task<bool> DeleteMovieAsync(int id)
    {
        if (await _movieRepository.ExistsAsync(id))
        {
            await _movieRepository.DeleteAsync(id);
            return true;
        }

        return false;
    }
    public async Task<IEnumerable<GenreDTO>> GetAllGenresAsync()
    {
        var genres = await _genreRepository.GetAllGenresAsync();
        return _mapper.Map<IEnumerable<GenreDTO>>(genres);
    }

    public async Task<IEnumerable<GenreDTO>> GetGenresByMovieIdAsync(int movieId)
    {
        var genres = await _genreRepository.GetGenreByMovieIdAsync(movieId);
        return _mapper.Map<IEnumerable<GenreDTO>>(genres);
    }
    public async Task<GenreDTO> CreateGenreAsync(int movieId, GenreDTO genreDto)
    {
        var genre = _mapper.Map<Genre>(genreDto);
        genre.MovieGenres = new List<MovieGenre> { new MovieGenre { MovieId = movieId, Genre = genre } };
        await _genreRepository.AddGenreAsync(genre);
        return _mapper.Map<GenreDTO>(genre);
    }

    public async Task<GenreDTO> AddGenreAsync(GenreDTO genreDto)
    {
        var genre = _mapper.Map<Genre>(genreDto);
        await _genreRepository.AddGenreAsync(genre);
        return _mapper.Map<GenreDTO>(genre);
    }
    public async Task<IEnumerable<MovieDTO>> GetAllMoviesByGenresAsync()
    {
        try
        {
            var movies = await _movieRepository.GetAllWithGenresAsync();
            var movieDTOs = _mapper.Map<IEnumerable<MovieDTO>>(movies);
            return movieDTOs;
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<MovieDTO>();
        }
    }
}

public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllMovieAsync();
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task<MovieDTO> CreateMovieAsync(MovieCreateDTO movieCreateDTO);
        Task<bool> UpdateMovieAsync(int id, MovieUpdateDTO movieUpdateDTO);
        Task<bool> DeleteMovieAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO> AddGenreAsync(GenreDTO genreDto);
        Task<GenreDTO> CreateGenreAsync(int movieId, GenreDTO genreDto);
        Task<IEnumerable<MovieDTO>> GetAllMoviesByGenresAsync();
    }