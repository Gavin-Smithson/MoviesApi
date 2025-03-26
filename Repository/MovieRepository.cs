
using System.Collections.Generic;
using MoviesApi.Models;

namespace MoviesApi.Repository {

    public class MovieRepository : IMovieRepositority {
        private static readonly List<Movie> movies = new List<Movie>(10)
        {
        new Movie {Name="Ice Age", Genre="Kids", Year=2002},
        new Movie {Name="The Godfather", Genre="Drama", Year=1972},
        new Movie {Name="The Dark Knight", Genre="Action", Year=2008}
        };

        public MovieRepository() {

        }

        public IEnumerable<Movie> GetAll(){
            return movies;
        }

        public Movie GetMovieByName(string name) {
            foreach(Movie m in movies) {
                if (m.Name.Equals(name)) {
                    return m;
                }
            }
            return null;
        }

        public void InsertMovie(Movie m){
            movies.Add(m);
        }

        public void UpdateMovie(string name, Movie movieIn){
            foreach(Movie m in movies) {
                if (m.Name.Equals(name)) {
                    m.Name=movieIn.Name;
                    m.Genre=movieIn.Genre;
                    m.Year=movieIn.Year;
                    return;
                }
            }
            return;
        }

        public void DeleteMovie(string name){
            foreach(Movie m in movies) {
                if (m.Name.Equals(name)) {
                    movies.Remove(m);
                    return;
                }
            }
            return;
        }
    }
}