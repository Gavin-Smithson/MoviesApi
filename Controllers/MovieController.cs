using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static readonly List<Movie> movies = new List<Movie>(10)
    {
      new Movie {Name="Ice Age", Genre="Kids", Year=2002},
      new Movie {Name="The Godfather", Genre="Drama", Year=1972},
      new Movie {Name="The Dark Knight", Genre="Action", Year=2008}
    };

    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        // Exit if nothing is found
        if (movies == null ) {
            return BadRequest();
        }
        return Ok(movies);
    }
    [HttpGet("{name}", Name="GetMovie")]
    public IActionResult GetMovieByName(string name) {
        foreach(Movie m in movies) {
            if (m.Name.Equals(name)) {
                return Ok(m);
            }
        }
        return BadRequest();
    }
    [HttpGet("year/")]
    public IActionResult GetMovieByYear(string year) {
        foreach(Movie m in movies) {
            if (m.Year.Equals(year)) {
                return Ok(m);
            }
        }
        return BadRequest();
    }

    [HttpPost]
    public IActionResult CreateMovie(Movie m) {
        try {
            movies.Add(m);
            return CreatedAtRoute("GetMovie", new {name=m.Name}, m);
        } catch(Exception e) {
            return BadRequest();
        }
    }

    [HttpPut("{name}")]
    public IActionResult UpdateMovie(string name, Movie movieIn) {
        try {
            foreach(Movie m in movies) {
                if (m.Name.Equals(name)) {
                    m.Name=movieIn.Name;
                    m.Genre=movieIn.Genre;
                    m.Year=movieIn.Year;
                    return NoContent();
                }
            }
            return BadRequest();            
        } catch(Exception e) {
            return StatusCode(500);
        }
    }
    [HttpDelete("{name}")]
    public IActionResult DeleteMovie(string name) {
        try {
            foreach(Movie m in movies) {
                if (m.Name.Equals(name)) {
                    movies.Remove(m);
                    return NoContent();
                }
            }
            return BadRequest();            
        } catch(Exception e) {
            return StatusCode(500);
        }
    }
}
