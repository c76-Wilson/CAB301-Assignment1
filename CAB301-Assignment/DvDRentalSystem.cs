using CAB301_Assignment.Classes.BinarySearchTree;
using CAB301_Assignment.Enums;
using CAB301_Assignment.MovieClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    class DvDRentalSystem
    {
        protected static String StaffUsername = "staff";
        protected static String StaffPassword = "today123";

        public static BinarySearchTree binarySearchTree;

        static void Main(string[] args)
        {
            binarySearchTree = new BinarySearchTree();
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

                }
            }
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

        private static bool StaffLogin()
        {
            Console.Write("Please enter username and password:\r\n" +
                " Username: ");
            if(Console.ReadLine() == StaffUsername)
            {
                Console.Write(" Password: ");
                if (Console.ReadLine() == StaffPassword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static void WriteStaffMenu()
        {
            Console.WriteLine
                (
                "Welcome to the Community Library\r\n" +
                "===========Main Menu===========\r\n" +
                " 1. Add a new movie DVD\r\n" +
                " 2. Remove a movie DVD\r\n" +
                " 3. Register a new member\r\n" +
                " 4. Find a registered member's phone number\r\n" +
                " 0. Return to main menu\r\n" +
                "===============================\r\n" +
                "\r\n" +
                " Please make a selection (1-4, or 0 to return to main menu):"
                );
        }

        private static void StaffMenu()
        {
            WriteStaffMenu();
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "0":
                        Console.Clear();
                        return;
                    case "1":
                        AddNewDVD();
                        Console.Clear();
                        WriteStaffMenu();
                        break;
                    case "2":
                        RemoveDVD();
                        Console.Clear();
                        WriteStaffMenu();
                        break;
                    case "3":
                        RegisterNewMember();
                        Console.Clear();
                        WriteStaffMenu();
                        break;
                    case "4":
                        GetMembersPhoneNumber();
                        Console.Clear();
                        WriteStaffMenu();
                        break;
                    default:
                        Console.WriteLine(" Please enter a valid selection (1-4, or 0 to return to main menu): ");
                        break;
                }
            }
        }

        private static void AddNewDVD()
        {
            Movie newMovie;

            Console.Write("Please enter the movie title: ");
            String title = Console.ReadLine();

            Console.Write("\r\nPlease enter the genre (Drama, Adventure, Family, Action, SciFi, Comedy, Animated, Thriller, Other): ");
            Genre genre;
            if (Enum.TryParse<Genre>(Console.ReadLine(), out genre))
            {

            }
            else
            {
                genre = Genre.Other;
            }

            Console.Write("\r\n1. G\r\n" +
                " 2. PG\r\n" +
                " 3. M15\r\n" +
                " 4. MA14\r\n" +
                "Please enter a rating from the above list: ");

            Rating rating = Rating.G;
            bool choiceMade = false;

            while (!choiceMade)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        rating = Rating.G;
                        choiceMade = true;
                        break;
                    case "2":
                        rating = Rating.PG;
                        choiceMade = true;
                        break;
                    case "3":
                        rating = Rating.M15;
                        choiceMade = true;
                        break;
                    case "4":
                        rating = Rating.MA15;
                        choiceMade = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection (1-4): ");
                        break;
                }
            }

            Console.Write("\r\nPlease enter the actors starring in this movie: ");
            String starring = Console.ReadLine();

            Console.Write("\r\nPlease enter the director: ");
            String director = Console.ReadLine();

            Console.Write("\r\nPlease enter the duration: ");
            String duration = Console.ReadLine();

            Console.Write("\r\nPlease enter the release date (dd/mm/yyyy): ");
            DateTime releaseDate = DateTime.MinValue;
            bool isValidDateTime = false;

            while (!isValidDateTime)
            {
                if (DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate))
                {
                    isValidDateTime = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid date (dd/mm/yyyy): ");
                }
            }

            newMovie = new Movie(title, genre, rating, starring, director, duration, releaseDate);

            binarySearchTree.Insert(newMovie);
        }

        private static void RemoveDVD()
        {

        }

        private static void RegisterNewMember()
        {

        }

        private static void GetMembersPhoneNumber()
        {

        }
    }
}
