using MoviesApi.Models;
public interface IMovieService {

    public IEnumerable<Movie> GetMovies();
    public Movie GetMoviesByName(string name);    
    public Movie GetMovieByYear(int year);
    public void Create(Movie m);
    public void UpdateMovie(string name, Movie m);
    public void DeleteMovie(string name);
}