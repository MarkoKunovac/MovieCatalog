using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public MovieTypeEnum Genre { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public static ObservableCollection<Film> getMovie()
        {
            var movie = new ObservableCollection<Film>();
            movie.Add(new Film() { Name = "Avatar", Genre = MovieTypeEnum.Fantasy, Director = "James Cameron", ReleaseDate = new DateTime(2009, 12, 18) });
            movie.Add(new Film() { Name = "Dark Knight", Genre = MovieTypeEnum.Action, Director = "Christopher Nolan", ReleaseDate = new DateTime(2008, 7, 18) });
            movie.Add(new Film() { Name = "Gilmors girls", Genre = MovieTypeEnum.Scifi, Director = "Ivan Peric", ReleaseDate = new DateTime(2018, 1, 1) });
            movie.Add(new Film() { Name = "Scrubs", Genre = MovieTypeEnum.Thriller, Director = "Oliver Sipos", ReleaseDate = new DateTime(2018, 1, 1) });
            return movie;
        }

        public Film()
        {

        }

        public Film(Film film)
        {
            Name = film.Name;
            Genre = film.Genre;
            Director = film.Director;
            ReleaseDate = film.ReleaseDate;
        }
    }
}
