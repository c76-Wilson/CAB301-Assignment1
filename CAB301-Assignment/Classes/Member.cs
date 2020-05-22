using CAB301_Assignment.MovieClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment.Classes
{
    public class Member
    {
        private String _FullName;

        public String FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        private String _Address;

        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private String _PhoneNumber;

        public String PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        private MovieCollection _BorrowedMovies;

        public MovieCollection BorrowedMovies
        {
            get { return _BorrowedMovies; }
            set { _BorrowedMovies = value; }
        }

        public Member(String fullName, String address, String phoneNumber)
        {
            this.FullName = fullName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }
    }
}
