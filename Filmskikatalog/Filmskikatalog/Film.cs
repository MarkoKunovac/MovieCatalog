using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmskikatalog
{
    public enum MovieTypeEnum
    {
        Action,
        Fantasy,
        Scifi,
        Thriller
    }
    public class Film
    {
        public string Name { get; set;}
        public string Genre { get; set; }
        public string Director { get; set; }
        public string ReleaseDate { get; set; } 
        public static List<Film> getMovie()
        {
            var movie = new List<Film>();
            movie.Add(new Film() { Name = "Avatar", Genre = "Fantasy", Director = "James Cameron", ReleaseDate = "12/18/2009 12:00:00 AM" });
            movie.Add(new Film() { Name = "Dark Knight", Genre = "Action", Director = "Christopher Nolan", ReleaseDate = "7/18/2008 12:00:00 AM" });
            movie.Add(new Film() { Name = "Gilmors girls", Genre = "Sci-Fi", Director = "Ivan Peric", ReleaseDate = "1/1/2018 12:00:00 AM"});
            movie.Add(new Film() { Name = "Scrubs", Genre = "Family", Director = "Oliver Sipos", ReleaseDate = "1/1/2019 12:00:00 AM" });
            return movie;
        }
    }
}
