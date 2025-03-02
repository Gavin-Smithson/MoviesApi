using Microsoft.AspNetCore.SignalR;

namespace MoviesApi.Models {
    public class Movie {
        public String Name {get; set;}
        public String Genre {get; set;}
        public int Year {get; set;}
        
        public override string ToString() {
            return $"{Name}, {Genre}, {Year}";
        }
    }
}