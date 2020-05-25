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
            
            while (true)
            {
                Console.Clear();
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

                            Console.WriteLine("Press enter to return to main menu... ");

                            while (Console.ReadKey().Key != ConsoleKey.Enter)
                            {

                            }
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

                            Console.WriteLine("Press enter to return to main menu... ");

                            while (Console.ReadKey().Key != ConsoleKey.Enter)
                            {

                            }
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

        

        
    }
}
