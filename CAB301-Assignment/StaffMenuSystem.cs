using CAB301_Assignment.Classes;
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
    public partial class DvDRentalSystem
    {
        #region Staff Menu

        private static bool StaffLogin()
        {
            Console.Write("Please enter username and password:\r\n" +
                " Username: ");
            if (Console.ReadLine() == StaffUsername)
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
                "===========Staff Menu===========\r\n" +
                " 1. Add a new movie DVD\r\n" +
                " 2. Remove a movie DVD\r\n" +
                " 3. Register a new member\r\n" +
                " 4. Find a registered member's phone number\r\n" +
                " 0. Return to main menu\r\n" +
                "================================\r\n" +
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
            Console.Clear();

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

            Console.Write("\r\nPlease enter the rating (G, PG, M15+, MA15+): ");

            Rating rating = Rating.G;
            bool choiceMade = false;

            while (!choiceMade)
            {
                switch (Console.ReadLine())
                {
                    case "G":
                        rating = Rating.G;
                        choiceMade = true;
                        break;
                    case "PG":
                        rating = Rating.PG;
                        choiceMade = true;
                        break;
                    case "M15":
                    case "M15+":
                    case "M":
                        rating = Rating.M15;
                        choiceMade = true;
                        break;
                    case "MA15":
                    case "MA15+":
                    case "MA":
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

            while (!DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate))
            {
                Console.WriteLine("Please enter a valid date (dd/mm/yyyy): ");
            }

            Console.Write("\r\nPlease enter the quantity of DVD's: ");
            int quantity = 0;

            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Please enter a valid number: ");
            }

            newMovie = new Movie(title, genre, rating, starring, director, duration, releaseDate, quantity);

            MovieCollection.AddMovie(newMovie);

            Console.Clear();

            Console.WriteLine("{0} added to the system.\r\n" +
                    "Press enter to return to staff menu... ", title);

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }

        private static void RemoveDVD()
        {
            Console.Clear();

            Console.Write("Please enter the name of the DVD you want to delete: ");

            // Movie to delete
            Movie deleteMovie = new Movie();
            deleteMovie.Title = Console.ReadLine();

            MovieCollection.RemoveMovie(deleteMovie);

            Console.Clear();

            Console.WriteLine("{0} removed from the system.\r\n" +
                    "Press enter to return to staff menu... ", deleteMovie.Title);

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }

        private static void RegisterNewMember()
        {
            Console.Clear();

            // Get full name of member and make username from it
            Console.Write("\r\nPlease enter the first name of the member: ");
            String firstName = Console.ReadLine();
            Console.Write("\r\nPlease enter the last name of the member: ");
            String fullName = firstName + " " + Console.ReadLine();
            String userName = fullName.Split(' ').Last() + fullName.Split(' ').First();

            // Get members address
            Console.Write("\r\nPlease enter the members address: ");
            String address = Console.ReadLine();

            Console.Write("\r\nPlease enter the members phone number: ");
            String phoneNumber = Console.ReadLine();

            Console.Write("\r\nPlease have the member enter their 4 digit passcode: ");
            int passCode = 0;

            while (!int.TryParse(Console.ReadLine(), out passCode) || passCode.ToString().Length != 4)
            {
                Console.WriteLine("\r\nPlease enter a valid, 4 digit passcode!");
            }

            Member newMember = new Member(fullName, userName, passCode, address, phoneNumber);
            MemberCollection.AddMember(newMember);

            Console.Clear();

            Console.WriteLine("{0} added to the system. Username is: {1}\r\n" +
                    "Press enter to return to staff menu... ", fullName, userName);

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }

        private static void GetMembersPhoneNumber()
        {
            Console.Clear();

            // Search MemberCollection array for a matching user by full name
            Console.Write("\r\nPlease enter the full name of the user to find their phone number: ");

            String name = Console.ReadLine();

            String phoneNumber = MemberCollection.GetPhoneNumber(name);

            if (phoneNumber == null)
            {
                Console.Clear();

                Console.WriteLine("Couldn't find a user by that name! Press Enter to return to staff menu... ");

                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {

                }
            }
            else
            {
                Console.Clear();

                Console.WriteLine("The phone number associated with {0} is: \r\n\r\n" +
                    "\t{1}\r\n\r\n" +
                    "Press Enter to return to staff menu... ", name, phoneNumber);

                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {

                }
            }
        }

        #endregion
    }
}
