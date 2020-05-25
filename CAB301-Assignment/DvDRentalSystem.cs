using CAB301_Assignment.Classes;
using CAB301_Assignment.Classes.BSTClasses;
using CAB301_Assignment.Enums;
using CAB301_Assignment.MovieClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    public partial class DvDRentalSystem
    {
        // Global variable for maximum members in a rental system (done instead of hardcoding the value in the constructor of the MemberCollection)
        protected static int MaxMembers = 1;

        protected static String StaffUsername = "staff";
        protected static String StaffPassword = "today123";

        public static MovieCollection MovieCollection;
        public static MemberCollection MemberCollection;

        public static void Main(string[] args)
        {
            RunRentalSystem();
        }

        private static void RunRentalSystem()
        {
            MovieCollection = new MovieCollection();
            MemberCollection = new MemberCollection(MaxMembers);

            TestSetup();

            while (true)
            {
                switch (WriteWelcome())
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        if (StaffLogin())
                        {
                            Console.Clear();
                            StaffMenu();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect Username or Password!\r\n");
                            Console.ResetColor();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Member member = MemberLogin();
                        if (member != null)
                        {
                            Console.Clear();
                            MemberMenu(member);
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect Username or Password!\r\n");
                            Console.ResetColor();
                        }
                        break;
                }
            }
        }

        // Method so i dont have to enter details every time...
        private static void TestSetup()
        {
            //Temporary add movies to collection
            MovieCollection.Movies.Insert(new Movie("Pulp Fiction", Genre.Action, Rating.MA15, "Vincent Vega, Samuel L Jackson, Uma Thurman", "Quentin Tarantino", "2 hours", new DateTime(1994, 11, 24), 5));
            MovieCollection.MoviesInCollection++;
            MovieCollection.Movies.Insert(new Movie("Inglorious Bastards", Genre.Drama, Rating.MA15, "Christoph Waltz, Brad Pitt, Melanie Laurent", "Quentin Tarantino", "3 hours", new DateTime(2009, 8, 3), 4));
            MovieCollection.MoviesInCollection++;
            MovieCollection.Movies.Insert(new Movie("Django Unchained", Genre.Action, Rating.MA15, "Leonardo DiCaprio, Samuel L Jackson, Christoph Waltz", "Quentin Tarantino", "2 hours", new DateTime(2012, 1, 24), 3));
            MovieCollection.MoviesInCollection++;
            MovieCollection.Movies.Insert(new Movie("Reservoir Dogs", Genre.Action, Rating.MA15, "Michael Madsen, Tim Roth, Steve Buscemi", "Quentin Tarantino", "2 hours", new DateTime(1992, 7, 30), 2));
            MovieCollection.MoviesInCollection++;

            //Temporary add user
            MemberCollection.AddMember(new Member("John Smith", "SmithJohn", 1234, "123 Fake Street", "0404040404"));
        }

        private static int WriteWelcome()
        {
            Console.WriteLine
                (
                "Welcome to the Community Library\r\n" +
                "===========Main Menu===========\r\n" +
                " 1. Staff Login\r\n" +
                " 2. Member Login\r\n" +
                " 0. Exit\r\n" +
                "===============================\r\n" +
                "\r\n" +
                " Please make a selection (1-2, or 0 to exit):"
                );

            while (true) {
                switch (Console.ReadLine())
                {
                    case "0":
                        return 0;
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    default:
                        Console.WriteLine(" Please enter a valid selection (1-2, or 0 to exit): ");
                        break;
                }
            }
        }

        

        
    }
}
