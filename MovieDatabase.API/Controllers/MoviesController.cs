using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.Models.ResourceModels;
using MovieDatabase.API.Services.Interfaces;

namespace MovieDatabase.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository ?? throw new ArgumentException($"{nameof(_movieRepository)} cannot be null");
    }

    [HttpGet]
    public ActionResult<IQueryable<MovieResourceModel>> GetMovies()
    {
        var movies = _movieRepository.GetAll();
        var movieViewModels = (from movie in movies
            select new MovieResourceModel
            {
                Id = movie.MovieId,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear.ToShortDateString(),
                IMDBRating = movie.Rating,
                Directors = movie.MovieDirectors.Where(x => x.Movie.MovieId == movie.MovieId)
                    .Select(x => $"{x.Director.FirstName} {x.Director.LastName}").ToList()
            }).ToList();

        return Ok(movieViewModels);
    }
}