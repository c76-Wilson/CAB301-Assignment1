﻿using CAB301_Assignment.Enums;
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

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public Movie(string title, Genre genre, Rating rating, string starring, string director, string duration, DateTime releaseDate)
        {
            Title = title;
            Genre = genre;
            Rating = rating;
            Starring = starring;
            Director = director;
            Duration = duration;
            ReleaseDate = releaseDate;
        }
    }
}
