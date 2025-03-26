using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesApi.Models;

namespace MoviesApi.Services {
    public class MovieService : IMovieService {
        private IMovieRepositority _repo;
        public MovieService(IMovieRepositority repo){
            _repo = repo;
        }
        
        public IEnumerable<Movie> GetMovies() {
            IEnumerable<Movie> myList = _repo.GetAll();
            // sort list
            return myList;
        }

        public Movie GetMoviesByName(string name){
            return _repo.GetMovieByName(name);
        }
        public Movie GetMovieByYear(int year){
            IEnumerable<Movie> myList = _repo.GetAll();
            foreach(Movie m in myList) {
                if (m.Year==year) {
                    return m;
                }
            }
            return null;
        }
        public void Create(Movie m){
            _repo.InsertMovie(m);
        }
        public void UpdateMovie(string name, Movie m){
            _repo.UpdateMovie(name, m);
        }
        public void DeleteMovie(string name){
            _repo.DeleteMovie(name);
        }

        public IEnumerable<Movie> GetMoviesByName()
        {
            throw new NotImplementedException();
        }
    }
}