using CAB301_Assignment.Classes.BSTClasses;
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

        public MovieCollection()
        {
            this.Movies = new BinarySearchTree();
        }
    }
}
