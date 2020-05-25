using CAB301_Assignment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment.MovieClasses
{
    public class Movie : IComparable
    {
        private String _Title;

        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private Genre _Genre;

        public Genre Genre
        {
            get { return _Genre; }
            set { _Genre = value; }
        }

        private Rating _Rating;

        public Rating Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }

        private String _Starring;

        public String Starring
        {
            get { return _Starring; }
            set { _Starring = value; }
        }

        private String _Director;

        public String Director
        {
            get { return _Director; }
            set { _Director = value; }
        }

        private String _Duration;

        public String Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }

        private DateTime _ReleaseDate;

        public DateTime ReleaseDate
        {
            get { return _ReleaseDate; }
            set { _ReleaseDate = value; }
        }

        private int _Quantity;

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private int _NumberOfBorrows;

        public int NumberOfBorrows
        {
            get { return _NumberOfBorrows; }
            set { _NumberOfBorrows = value; }
        }

        public int CompareTo(object obj)
        {
            //Check if comparable object is a movie, if not throw an error
            if (obj is Movie)
            {
                Movie movieToCompare = (Movie)obj;
                // Compare movie titles
                return this.Title.CompareTo(movieToCompare.Title);
            }
            else
            {
                throw new Exception("Object to compare is not a Movie!");
            }
        }

        public Movie(string title, Genre genre, Rating rating, string starring, string director, string duration, DateTime releaseDate, int quantity)
        {
            Title = title;
            Genre = genre;
            Rating = rating;
            Starring = starring;
            Director = director;
            Duration = duration;
            ReleaseDate = releaseDate;
            Quantity = quantity;
            NumberOfBorrows = 0;
        }

        // Movie constructor with just title for searching
        public Movie(String title)
        {
            this.Title = title;
        }

        public Movie()
        {

        }
    }
}
