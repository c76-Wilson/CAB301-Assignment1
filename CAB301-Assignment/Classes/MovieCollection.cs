using CAB301_Assignment.Classes.BSTClasses;
using CAB301_Assignment.MovieClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment.Classes
{
    public class MovieCollection
    {
        private BinarySearchTree _Movies;

        public BinarySearchTree Movies
        {
            get { return _Movies; }
            set { _Movies = value; }
        }

        private int _MoviesInCollection;

        public int MoviesInCollection
        {
            get { return _MoviesInCollection; }
            set { _MoviesInCollection = value; }
        }

        public void AddMovie(Movie movie)
        {
            this.Movies.Insert(movie);
            this.MoviesInCollection++;
        }

        public void RemoveMovie(Movie movie)
        {
            this.Movies.Delete(movie);
            this.MoviesInCollection--;
        }

        public Movie[] ConvertToArray()
        {
            return Movies.ConvertToArray(MoviesInCollection);
        }

        public MovieCollection()
        {
            this.Movies = new BinarySearchTree();
        }
    }
}
