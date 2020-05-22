using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    class DvDRentalSystem
    {
        private static String StaffUsername = "staff";
        private static String StaffPassword = "today123";

        static void Main(string[] args)
        {
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
