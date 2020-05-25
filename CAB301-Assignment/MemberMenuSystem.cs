using CAB301_Assignment.Classes;
using CAB301_Assignment.MovieClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    public partial class DvDRentalSystem
    {
        #region Member Menu

        private static Member MemberLogin()
        {
            Console.Write("Please enter username and password:\r\n" +
                " Username: ");

            Member member = Array.Find(MemberCollection.Members, x => x != null && x.UserName == Console.ReadLine());

            if (member != null)
            {
                int passCode = 0;
                Console.Write(" Password: ");
                if (int.TryParse(Console.ReadLine(), out passCode) && passCode == member.Password)
                {
                    return member;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private static void WriteMemberMenu()
        {
            Console.WriteLine
                (
                "Welcome to the Community Library\r\n" +
                "===========Main Menu===========\r\n" +
                " 1. Display all movies\r\n" +
                " 2. Borrow a movie DVD\r\n" +
                " 3. Return a movie DVD\r\n" +
                " 4. List current borrowed movie DVDs\r\n" +
                " 5. Display top 10 most popular movies\r\n" +
                " 0. Return to main menu\r\n" +
                "===============================\r\n" +
                "\r\n" +
                " Please make a selection (1-5, or 0 to return to main menu):"
                );
        }

        private static void MemberMenu(Member member)
        {
            WriteMemberMenu();
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "0":
                        Console.Clear();
                        return;
                    case "1":
                        DisplayAllMovies();
                        Console.Clear();
                        WriteMemberMenu();
                        break;
                    case "2":
                        BorrowMovie(member);
                        Console.Clear();
                        WriteMemberMenu();
                        break;
                    case "3":
                        ReturnMovie(member);
                        Console.Clear();
                        WriteMemberMenu();
                        break;
                    case "4":
                        ListAllBorrowedMovies(member);
                        Console.Clear();
                        WriteMemberMenu();
                        break;
                    case "5":
                        DisplayTop10Movies();
                        Console.Clear();
                        WriteMemberMenu();
                        break;
                    default:
                        Console.WriteLine(" Please enter a valid selection (1-4, or 0 to return to main menu): ");
                        break;
                }
            }
        }

        private static void DisplayAllMovies()
        {
            // Clear Screen
            Console.Clear();

            // Iterate through each node and print its details
            MovieCollection.Movies.InOrderTraverseWriteDetails();

            // Wait for enter key to return to main menu
            Console.WriteLine("Press Enter to return to member menu... ");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }

        private static void BorrowMovie(Member member)
        {
            // Ask user what the title of the Movie is
            Console.Write("Please enter the title of the movie you want to borrow: ");

            String movieTitle = Console.ReadLine();

            // Check if user has 10 movies
            if (!(member.BorrowedMovies.MoviesInCollection >= 10))
            {
                // Get the movie to borrow if it exists
                Movie movieToBorrow = MovieCollection.Movies.BorrowMovie(new Movie(movieTitle));

                if (movieToBorrow != null)
                {
                    // Check if user already has movie borrowed
                    if (!member.BorrowedMovies.Movies.Search(movieToBorrow))
                    {
                        // Check if there are enough copies
                        if (movieToBorrow.Quantity >= 1)
                        {
                            movieToBorrow.NumberOfBorrows++;
                            movieToBorrow.Quantity--;

                            Movie borrowedMovie = movieToBorrow;
                            borrowedMovie.Quantity = 1;

                            member.BorrowedMovies.AddMovie(borrowedMovie);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There aren't any copies of this movie left!\r\n" +
                                "Press enter to return to member menu... ", movieTitle);

                            while (Console.ReadKey().Key != ConsoleKey.Enter)
                            {

                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You already have this movie borrowed!\r\n" +
                            "Press enter to return to member menu... ", movieTitle);

                        while (Console.ReadKey().Key != ConsoleKey.Enter)
                        {

                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No movie was found with the title: {0}\r\n" +
                        "Press enter to return to member menu... ", movieTitle);

                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {

                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You already have 10 movies borrowed! Please return one before borrowing another.\r\n" +
                    "Press enter to return to member menu... ");

                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {

                }
            }
        }

        private static void ReturnMovie(Member member)
        {
            // Ask user what the title of the Movie is
            Console.Write("Please enter the title of the movie you want to borrow: ");

            String movieTitle = Console.ReadLine();

            // Check if user already has movie borrowed
            if (member.BorrowedMovies.Movies.Search(new Movie(movieTitle)))
            {
                MovieCollection.Movies.ReturnMovie(new Movie(movieTitle));

                member.BorrowedMovies.RemoveMovie(new Movie(movieTitle));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You don't have this movie borrowed!\r\n" +
                    "Press enter to return to member menu... ", movieTitle);

                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {

                }
            }

        }

        private static void ListAllBorrowedMovies(Member member)
        {
            Console.Clear();
            Console.WriteLine("Total Movies Borrowed: {0}\r\n", member.BorrowedMovies.MoviesInCollection);
            member.BorrowedMovies.Movies.InOrderTraverseWriteList();

            Console.WriteLine("Press enter to return to member menu... ");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }

        private static void DisplayTop10Movies()
        {
            Movie[] unsortedArray = MovieCollection.ConvertToArray();

            Movie[] sortedArray = QuickSortSystem.QuickSortArray(unsortedArray);

            Console.WriteLine("Most Borrowed Movies:\r\n");

            for (int i = sortedArray.Length - 1; i >= 0 && i >= sortedArray.Length - 10; i--)
            {
                Console.WriteLine("{0}. {1} \t| Borrowed {2} times", sortedArray.Length - i, sortedArray[i].Title, sortedArray[i].NumberOfBorrows);
            }

            Console.WriteLine("\r\nPlease press enter to return to member menu... ");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }

        #endregion
    }
}
