using System.Numerics;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private readonly ILogger<MovieController> _logger;
    private IMovieService _service;

    public MovieController(ILogger<MovieController> logger, IMovieService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        // Exit if nothing is found
        IEnumerable<Movie> movies = _service.GetMovies();
        if (movies == null ) {
            return BadRequest();
        }
        return Ok(movies);
    }
    [HttpGet("{name}", Name="GetMovie")]
    public IActionResult GetMovieByName(string name) {
        Movie obj = _service.GetMoviesByName(name);
        if (obj != null) {
            return Ok(obj);
        }
        return BadRequest();
    }
    [HttpGet("year/")]
    public IActionResult GetMovieByYear(int year) {
        Movie obj = _service.GetMovieByYear(year);
        if (obj != null) {
            return Ok(obj);
        }
        return NoContent();
    }

    [HttpPost]
    public IActionResult CreateMovie(Movie m) {
        try {
            _service.Create(m);
            return CreatedAtRoute("GetMovie", new {name=m.Name}, m);
        } catch(Exception e) {
            return BadRequest();
        }
    }

    [HttpPut("{name}")]
    public IActionResult UpdateMovie(string name, Movie movieIn) {
        try {
            _service.UpdateMovie(name, movieIn);     
            return NoContent();    
        } catch(Exception e) {
            return StatusCode(500);
        }
    }
    [HttpDelete("{name}")]
    public IActionResult DeleteMovie(string name) {
        try {
            _service.DeleteMovie(name);
            return NoContent();     
        } catch(Exception e) {
            return StatusCode(500);
        }
    }
}
