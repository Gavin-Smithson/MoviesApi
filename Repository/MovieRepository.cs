
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MoviesApi.Models;

namespace MoviesApi.Repository {

    public class MovieRepository : IMovieRepositority {
        private static readonly List<Movie> movies = new List<Movie>(10)
        {
        new Movie {Name="Ice Age", Genre="Kids", Year=2002},
        new Movie {Name="The Godfather", Genre="Drama", Year=1972},
        new Movie {Name="The Dark Knight", Genre="Action", Year=2008}
        };

        private MySqlConnection _connetion;
        public MovieRepository() {
            string connectionString="server=localhost;user=csci330user;password=csci330pass;database=entertainment";
            _connetion = new MySqlConnection(connectionString);
            _connetion.Open();
        }


        ~MovieRepository() {
            _connetion.Close();
        }

        public IEnumerable<Movie> GetAll(){
            var statement = "select * From Movies";
            var command = new MySqlCommand(statement, _connetion);
            var results = command.ExecuteReader();
            
            List<Movie> newList =  new List<Movie>();
            while (results.Read()){
                Movie m = new Movie {
                    Name = (string) results[1],
                    Year = (int) results[2],
                    Genre = (string) results[3].ToString()
                };
                newList.Add(m);
            }
            results.Close();
            return newList;
        }

        public Movie GetMovieByName(string name) {
            Movie m = null;
            var statement = "select * From Movies Where Name = @newName";
            var command = new MySqlCommand(statement, _connetion);
            command.Parameters.AddWithValue("@newName", name);
            
            var results = command.ExecuteReader();
            if (results.Read()) {
                m = new Movie {
                    Name = (string) results[1],
                    Year = (int) results[2],
                    Genre = (string) results[3].ToString()
                };

            }
            results.Close();

            return m;
        }

        public void InsertMovie(Movie m){
            var statement = "Insert into Movies (Name, Year, Genre) Values(@N, @Y, @G)";
            var command = new MySqlCommand(statement, _connetion);
            command.Parameters.AddWithValue("@N", m.Name);
            command.Parameters.AddWithValue("@Y", m.Year);
            command.Parameters.AddWithValue("@G", m.Genre);

            int result = command.ExecuteNonQuery();
            
            return;
        }

        public void UpdateMovie(string name, Movie movieIn){
            var statement = "Update Movies Set Name=@updateName, Year=@updateYear, Genre = @updateGenre WHERE name = @updateKey";
            var command = new MySqlCommand(statement, _connetion);
            command.Parameters.AddWithValue("@updateName", movieIn.Name);
            command.Parameters.AddWithValue("@updateYear", movieIn.Year);
            command.Parameters.AddWithValue("@updateGenre", movieIn.Genre);
            command.Parameters.AddWithValue("@updateKey", name);

            int result = command.ExecuteNonQuery();
            return;
        }

        public void DeleteMovie(string name){
            
            return;
        }
    }
}