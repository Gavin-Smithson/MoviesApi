using MoviesApi.Models;

public interface IMovieRepositority {
    public IEnumerable<Movie> GetAll();
    public Movie GetMovieByName(string name);
    public void InsertMovie(Movie m);
    public void UpdateMovie(string name, Movie movieIn);
    public void DeleteMovie(string name);
}